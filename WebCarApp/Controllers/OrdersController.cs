using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCarApp.Services.Interfaces;
using WebCarApp.Services.Models.Orders;
using WebCarApp.Web.Models.OrderModels;
using WebCarApp.Models;

namespace WebCarApp.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IClientService _client;
        private readonly ICarService _car;
        private readonly IOrderService _order;
        private readonly IFileLogger _logger;

        public OrdersController(IClientService client, ICarService car, IOrderService order,IFileLogger logger)
        {
            _client = client;
            _car = car;
            _order = order;
            _logger = logger;
        }

        public IActionResult Index(int page = 1, string sortOrder = "")
        {
            try
            {
                var totalOrders = _order.Total();
                var orders = _order.AllOrders(page, sortOrder);
                var maxPage = Math.Ceiling((double)totalOrders / 20);
                if (page > maxPage)
                {
                    throw new Exception("Max Page is exceeded");
                }
                var model = new AllOrdersViewModel
                {
                    Orders = orders,
                    Total = totalOrders,
                    CurrentPage = page,
                    SortOrder = sortOrder
                };

                return View(model);
            }
            catch (Exception ex)
            {
                var model = new AllOrdersViewModel()
                {
                    CurrentPage = 1,
                    Total = 1
                };
                LogExceptionWithMessage(ex);
                return View(model);

            }

        }


        public IActionResult Add()
        {
            FillViewBagWithDataForSelectInView();
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateOrdersViewModel model, int carId, int clientId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            try
            {
            var createOrder = new CreateOrderServiceModel()
            {
                CarId = carId,
                ClientId = clientId,
                OrderStatus = OrderStatus.In_Process,
                PurchaseDate = model.PurchaseDate,
                PurchasePrice = model.PurchasePrice

            };
            _order.Create(createOrder);
            return RedirectToAction("Index");


            }
            catch (Exception ex)
            {
                LogExceptionWithMessage(ex);
                ViewBag.Section = ex.Message;
                FillViewBagWithDataForSelectInView();
                return View();


            }
        }

        public IActionResult Details(string orderNumber)
        {
            try
            {
            var orderDetails = _order.GetByOrderNumber(orderNumber);
            if (orderDetails.OrderNumber == null)
            {
                return BadRequest();
            }
            var viewModelForDetails = new OrderDetailsViewModel()
            {
                CarDetails = orderDetails.CarDetails,
                ClientDetails = orderDetails.ClientDetails,
                PurchaseDate = orderDetails.PurchaseDate,
                PurchasePrice = orderDetails.PurchasePrice,
                OrderNumber = orderDetails.OrderNumber,
                OrderStatus = orderDetails.OrderStatus
            };

            return View(viewModelForDetails);

            }
            catch (Exception ex)
            {

                LogExceptionWithMessage(ex);
                return RedirectToAction("Index", "Orders");
            }
        }

        public IActionResult Search(string orderNumber)
        {
        
            try
            {
            var orderDetails = _order.GetByOrderNumber(orderNumber);

            var viewModelForDetails = new OrderDetailsViewModel()
            {
                CarDetails = orderDetails.CarDetails,
                ClientDetails = orderDetails.ClientDetails,
                PurchaseDate = orderDetails.PurchaseDate,
                PurchasePrice = orderDetails.PurchasePrice,
                OrderNumber = orderDetails.OrderNumber,
                OrderStatus = orderDetails.OrderStatus
            };
            return View("Details", viewModelForDetails);

            }
            catch (Exception ex)
            {
                LogExceptionWithMessage(ex);
              
                return RedirectToAction("Index","Orders");

            }
        }

        [HttpPost]
        public JsonResult OrderPriceInfo([FromBody] string id)
        {
            // to do with json data 

            var orderDetails = _order.GetInfoForOrderDetails(id);
            return Json(new { idNumber = orderDetails.ID, price = orderDetails.Price, date = orderDetails.PurchaseDate });
        }


        [HttpPost]
        public JsonResult OrderSearchCheck([FromBody] string orderNumber)
        {
            var checkOrder = _order.IsThereOrderNumber(orderNumber);
            if (checkOrder)
            {
                return Json(new { theOrderNumber = orderNumber });
            }
            else
            {
                return Json(new { theOrderNumber = 0 });
            }

        }

        [NonAction]
        private void FillViewBagWithDataForSelectInView()
        {
            var carDataForViewBag = _order.CarsForOrderSelect();
            var clientDataForViewBag = _order.ClientsForOrderSelect();
            ViewBag.SelectCarsData = carDataForViewBag.Select(x => new SelectListItem
            {
                Text = x.CarMake + " " + x.CarModel + " " + x.CarYear.ToString() + " " + x.Color + " With Engine: " + (x.CubicCentimeters / 1000).ToString()
                + " " + x.HorsePower + " " + x.Transmission + " " + x.FuelType + " And Price: " + x.CarPrice,
                Value = x.CarId.ToString()
            });
            ViewBag.SelectClientsData = clientDataForViewBag.Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName + " " + x.EGN,
                Value = x.Id.ToString()
            });
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
