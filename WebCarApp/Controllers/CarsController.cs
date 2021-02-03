
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCarApp.Services.Interfaces;
using WebCarApp.Services.Models.Car;
using WebCarApp.Models.CarModels;
using WebCarApp.Web.Models.CarModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCarApp.Web;
using System;

using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;
using WebCarApp.Web.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace WebCarApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService car;
        private readonly IFileLogger _logger;
        private readonly IHubContext<CarHub> _carHub;
        public CarsController(ICarService car, IFileLogger logger, IHubContext<CarHub> carHub)
        {
            this.car = car;
            this._logger = logger;
            _carHub = carHub;
        }





        // GET: CarsController
        public IActionResult All(int page = 1)
        {

            try
            {
                var cars = this.car.AllAvaiable(page);
                var totalCars = this.car.TotalAvaiable();
                var maxPage = Math.Ceiling((double)totalCars / 20);

                var model = new AllCarsViewModel
                {
                    Cars = cars,
                    Total = totalCars,
                    CurrentPage = page
                };
                if (page > maxPage)
                {
                    throw new Exception("Max Page is exceeded");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                LogExceptionWithMessage(ex);
                var model = new AllCarsViewModel()
                {
                    CurrentPage = 1,
                    Total = 1
                };

                return View(model);


            }



        }


        public IActionResult AllSold(int page = 1)
        {
            try
            {
                var cars = this.car.AllSold(page);
                var totalCars = this.car.TotalSold();
                var maxPage = Math.Ceiling((double)totalCars / 20);
                var model = new AllCarsViewModel
                {
                    Cars = cars,
                    Total = totalCars,
                    CurrentPage = page
                };
                if (page > maxPage)
                {
                    throw new Exception("Max Page is exceeded");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                LogExceptionWithMessage(ex);
                var model = new AllCarsViewModel()
                {
                    CurrentPage = 1,
                    Total = 1
                };

                return View(model);


            }
        }


        // GET: CarsController/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                var carDetails = car.GetById(id);
                if (carDetails.Make == null)
                {
                    return BadRequest();
                }
                var viewModelForDetails = new DetailsCarsViewModel()
                {
                    Model = carDetails.Model,
                    Make = carDetails.Make,
                    VIN = carDetails.VIN,
                    Color = carDetails.Color,
                    Price = carDetails.Price,
                    Kilowatt = carDetails.Kilowatt,
                    Tranmission = carDetails.Tranmission,
                    FuelType = carDetails.FuelType,
                    HorsePower = carDetails.HorsePower,
                    CubicCentimeters = carDetails.CubicCentimeters,
                    ModelYear = carDetails.ModelYear
                };
                ViewBag.PhotosPath = "https://www.google.com/search?tbm=isch&source=hp&biw=1280&bih=913&ei=fpTTX4HnCoq-aKajqtgD&q=" + viewModelForDetails.Make + " " + viewModelForDetails.Model + " " + viewModelForDetails.ModelYear;
                return View(viewModelForDetails);

            }
            catch (Exception ex)
            {
                var viewModelForDetails = new DetailsCarsViewModel();
                LogExceptionWithMessage(ex);
                return View(viewModelForDetails);
            }
        }

        // GET: CarsController/Create
        public IActionResult Create()
        {
            FillViewBagWithDataForSelectInView();
            return View("Add");
        }




        // POST: CarsController/Create
        [HttpPost]

        public async Task<IActionResult> Add(CreateCarViewModel model, int modelId, int engineId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            try
            {

                var createCarServiceModel = new CreateCarServiceModel()
                {
                    Id = model.Id,
                    ProductionDate = model.ProductionDate,
                    VIN = model.VIN,
                    Price = model.Price,
                    Color = model.Color,
                    ModelId = modelId,
                    EngineId = engineId
                };
                this.car.Create(createCarServiceModel);
                await this._carHub.Clients.All.SendAsync("NewOrder");
                return RedirectToAction("All");
            }
            catch (Exception x)
            {
                LogExceptionWithMessage(x);
                ViewBag.Section = "error";
                FillViewBagWithDataForSelectInView();
                return View();

            }

        }

        public IActionResult Search([FromQuery] string makeName)
        {
            if (string.IsNullOrEmpty(makeName))
            {
                return RedirectToAction("Error", "Home");
            }
            var cars = car.SearchCarByMake(makeName);

            if (cars.Count() == 0)
            {
                return RedirectToAction("Error", "Home");
            }
            var carsViewModel = new AllCarsByMakeViewModel()
            {
                Cars = cars
            };
            return View(carsViewModel);

        }
        [HttpPost]
        public JsonResult CarSearchCheck([FromBody] string makeName)
        {
            var checkCar = car.IsThereCarMake(makeName);
            if (checkCar)
            {
                return Json(new { carName = makeName });
            }
            else
            {
                return Json(new { carName = 0 });
            }

        }
        [NonAction]
        private void LogExceptionWithMessage(Exception ex)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            var test = Request.HttpContext.Connection.RemoteIpAddress;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine($"In Controller: {controllerName} with Action : {actionName}" +
                $" and client IP: {test}");
            sb.AppendLine($"At: {DateTime.UtcNow}");
            sb.AppendLine($"An Exception occured");
            sb.AppendLine($"Exception message: {ex.Message}");

            _logger.WriteErrorLog(sb.ToString());
        }
        [NonAction]
        private void FillViewBagWithDataForSelectInView()
        {
            var modelDataForViewBag = car.ModelsForCarSelect();
            var engineDataForViewBag = car.EnginesForCarSelect();
            ViewBag.SelectModelsData = modelDataForViewBag.Select(x => new SelectListItem
            {
                Text = x.MakeName + " " + x.Name + " " + x.Year.ToString(),
                Value = x.Id.ToString()
            });
            ViewBag.SelectEnginesData = engineDataForViewBag.Select(x => new SelectListItem
            {
                Text = x.CubicCentimeters / 1000 + " " + x.HorsePower + " " + x.Transmisson + " " + x.FuelType,
                Value = x.Id.ToString()
            });
        }
    }
}
