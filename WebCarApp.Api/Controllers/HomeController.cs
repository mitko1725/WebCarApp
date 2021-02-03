using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebCarApp.Api.Data;
using WebCarApp.Api.Models;
using WebCarApp.Services.Interfaces;
using WebCarApp.Services.Models.Car;
using WebCarApp.Services.Models.Clients;
using WebCarApp.Services.Models.Orders;

namespace WebCarApp.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _car;
        private readonly IClientService _client;
        private readonly IOrderService _orders;

        public HomeController(ILogger<HomeController> logger, ICarService car, IClientService client, IOrderService orders)
        {
            _logger = logger;
            _car = car;
            _client = client;
            _orders = orders;
        }
         
        public IActionResult Index()
        {
            FillViewBagWithDataForFirstSelectInView();
            FillViewBagCarData();
            FillViewBagClientData();
            FillViewBagOrderData();
            return View();
        }
        

        [HttpPost]
        public IActionResult CarData(int carId, string carDataId, string carDataPD,
            string carDataVIN, string carDataPrice, string carDataColor, string carDataModelId, string carDataEngineId)
        {

            var getData = _car.FillCarDataForAPI(carId, carDataId, carDataPD,
             carDataVIN, carDataPrice, carDataColor, carDataModelId, carDataEngineId);
           
            return Json(getData);

        }

        [HttpPost]

        public JsonResult ClientData([FromBody] ClientData data)
        {
            try
            {
                int.TryParse(data.ClientId, out int result);
                var clientData = _client.FindById(result);
                ClientDetailsServiceModel filteredData = FilterClientData(data, clientData);

                return Json(filteredData);

            }
            catch (Exception e)
            {
                string wrongData = "Please check data again";
                return Json(new { wrongData });
            }



        }


        [HttpPost]

        public JsonResult OrderData([FromBody] OrderData data)
        {
            try
            {
              var theOrder =  _orders.OrderDataForAPI(data.OrderNumber.ToString(),data.CarId,data.ClientId,data.PurchaseDate,data.OrderStatus,data.OrderNumberCheck,data.PurchasePrice);
                
                return Json(theOrder);

            }
            catch (Exception e)
            {
                string wrongData = "Please check data again";
                return Json(new { wrongData });
            }



        }

        private static ClientDetailsServiceModel FilterClientData(ClientData data, ClientDetailsServiceModel clientData)
        {
            var filteredData = new ClientDetailsServiceModel() { };

            if (data.EGN)
            {
                filteredData.EGN = clientData.EGN;
            }
            if (data.Email)
            {
                filteredData.Email = clientData.Email;
            }
            if (data.FirstName)
            {
                filteredData.FirstName = clientData.FirstName;
            }
            if (data.Id)
            {
                filteredData.Id = clientData.Id;
            }

            if (data.LastName)
            {
                filteredData.LastName = clientData.LastName;
            }
            if (data.PhoneNumber)
            {
                filteredData.PhoneNumber = clientData.PhoneNumber;
            }

            return filteredData;
        }
    
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [NonAction]
        private void FillViewBagWithDataForFirstSelectInView()
        {

            var data = new Dictionary<int, string>()
            {
                { 1,"Cars" },
                { 2,"Clients" },
                { 3,"Orders" }

            };

            ViewBag.SelectData = data.Select(x => new SelectListItem
            {
                Text = x.Value.ToString(),
                Value = x.Key.ToString()
            });

        }


        [NonAction]
        private void FillViewBagCarData()
        {
            var modelDataForCarViewBag = _car.GetCarData();

            ViewBag.SelectCarData = modelDataForCarViewBag.Select(x => new SelectListItem
            {
                Text = x.Id.ToString(),
                Value = x.Id.ToString()
            });

        }

        [NonAction]
        private void FillViewBagClientData()
        {
            var modelDataForClientViewBag = _client.GetClientData();

            ViewBag.SelectClientData = modelDataForClientViewBag.Select(x => new SelectListItem
            {
                Text = x.ID.ToString(),
                Value = x.ID.ToString()
            });

        }
        [NonAction]
        private void FillViewBagOrderData()
        {
            var modelDataForOrderViewBag = _orders.GetOrderData();

            ViewBag.SelectOrderData = modelDataForOrderViewBag.Select(x => new SelectListItem
            {
                Text = x.OrderNumber.ToString(),
                Value = x.OrderNumber.ToString()
            });

        }

    }

}
