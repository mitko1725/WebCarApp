using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCarApp.Services.Interfaces;
using WebCarApp.Services.Models.Clients;
using WebCarApp.Web.Models.CarModels;
using WebCarApp.Web.Models.ClientModels;

namespace WebCarApp.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService client;
        private readonly IFileLogger _logger;
        public ClientsController(IClientService client, IFileLogger logger)
        {
            this.client = client;
            _logger = logger;
        }


        public IActionResult All(int page = 1, string sortOrder = "")
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }
            try
            {
                var totalClients = this.client.Total();

                var clients = client.AllClients(page, sortOrder);
                var maxPage = Math.Ceiling((double)totalClients / 20);
                var model = new AllClientsViewModel
                {
                    Clients = clients,
                    Total = totalClients,
                    CurrentPage = page,
                    SortOrder = sortOrder
                };
                if (page > maxPage)
                {
                    throw new Exception("Max Page is exceeded");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                var model = new AllClientsViewModel()
                {
                    CurrentPage = 1,
                    Total = 1
                };
                LogExceptionWithMessage(ex);
                return View(model);
            }

        }

        public IActionResult Create()
        {

            return View("Add");
        }

        // POST: CarsController/Create
        [HttpPost]

        public IActionResult Add(CreateClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }
            try
            {
            var createModel = new CreateClientServiceModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EGN = model.EGN,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };
            this.client.Create(createModel);
            return this.RedirectToAction("All");

            }
            catch (Exception ex)
            {
                LogExceptionWithMessage(ex);
                ViewBag.Section = "error";
                return View();
            }
        }

        public IActionResult Details([FromQuery] string egn)
        {
            try
            {
            var clientDetails = client.FindByEGN(egn);
          
           
            var clientOrders = client.FindAllOrders(clientDetails.Id);
            var viewModelForDetails = new DetailsClientViewModel()
            {
                Id = clientDetails.Id,
                FirstName = clientDetails.FirstName,
                LastName = clientDetails.LastName,
                EGN = clientDetails.EGN,
                Email = clientDetails.Email,
                PhoneNumber = clientDetails.PhoneNumber,
                AllOrders = clientOrders
            };

            return View(viewModelForDetails);

            }
            catch (Exception ex)
            {
                LogExceptionWithMessage(ex);
                return RedirectToAction("All");

            }

        }

        public IActionResult Edit(int id)
        {
            try
            {

            var clientDetails = client.FindById(id);
            if (clientDetails.Id == 0)
            {
                return BadRequest();
            }
            var viewModelForDetails = new DetailsClientViewModel()
            {
                Id = clientDetails.Id,
                FirstName = clientDetails.FirstName,
                LastName = clientDetails.LastName,
                EGN = clientDetails.EGN,
                Email = clientDetails.Email,
                PhoneNumber = clientDetails.PhoneNumber
            };

            return View(viewModelForDetails);
            }
            catch (Exception ex)
            {
                LogExceptionWithMessage(ex);
                ViewBag.Section = "error";
                return RedirectToAction("All");
              
            }

        }
        [HttpPost]
        public IActionResult Edit(DetailsClientViewModel model)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
            var updateDetails = new EditClientServiceModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EGN = model.EGN,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };
            this.client.Edit(updateDetails);

            return RedirectToAction("Details", new { egn = updateDetails.EGN });

            }
            catch (Exception ex)
            {
              
                LogExceptionWithMessage(ex);
                ViewBag.Section = ex.Message;
                return View();

            }
            // EGN VALIDATION IS INSIDE SERVICE

        }


        [HttpPost]
        public JsonResult ClientSearchCheck([FromBody] string egn)
        {
            var checkClient = client.IsThereClient(egn);
            if (checkClient)
            {
                return Json(new { clientEgn = egn });
            }
            else
            {
                return Json(new { clientEgn = 0 });
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



    }
}
