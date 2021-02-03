using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCarApp.Data;
using WebCarApp.Models;
using WebCarApp.Services.Interfaces;
using WebCarApp.Services.Models.Orders;
using WebCarApp.Services.Models.Car;
using WebCarApp.Services.Models.Clients;
using System.Globalization;

namespace WebCarApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly CarDbContex data;
        private readonly ICarService _carService;
        private readonly IClientService _clientService;


        public OrderService(CarDbContex data,ICarService carService,IClientService clientService)
        {
            this.data = data;
            _carService = carService;
            _clientService = clientService;
        }

        public IEnumerable<OrderListingServiceModel> AllOrders(int page = 1, string sortOrder = "")
        {

            IQueryable<OrderListingServiceModel> result = null;
            result = MakeSorting(sortOrder);

            return result
              .Skip((page - 1) * 20)
              .Take(20)
             .ToList();
        }

        private IQueryable<OrderListingServiceModel> MakeSorting(string sortOrder)
        {
            IQueryable<OrderListingServiceModel> result;
            switch (sortOrder)
            {
                case "DateSortAsc":
                    result = this.data.Orders
                    .AsNoTracking()
                    .Select(c => new OrderListingServiceModel
                    {
                        OrderNumber = c.OrderNumber,
                        CarId = c.CarId,
                        CarMake = c.Car.Model.Make.Name,
                        CarModel = c.Car.Model.Name,
                        ClientId = c.ClientId,
                        ClientFirstName = c.Client.FirstName,
                        ClientLastName = c.Client.LastName,
                        Purchasedate = c.PurchaseDate,
                        OrderStatus = c.OrderStatus
                    })
                    .OrderBy(s => s.Purchasedate);
                    break;
                case "DateSortDesc":
                    result = result = this.data.Orders
                    .AsNoTracking()
                    .Select(c => new OrderListingServiceModel
                    {
                        OrderNumber = c.OrderNumber,
                        CarId = c.CarId,
                        CarMake = c.Car.Model.Make.Name,
                        CarModel = c.Car.Model.Name,
                        ClientId = c.ClientId,
                        ClientFirstName = c.Client.FirstName,
                        ClientLastName = c.Client.LastName,
                        Purchasedate = c.PurchaseDate,
                        OrderStatus = c.OrderStatus
                    }).OrderByDescending(s => s.Purchasedate);
                    break;

                default:
                    result = result = this.data.Orders
                    .AsNoTracking()
                    .Select(c => new OrderListingServiceModel
                    {
                        OrderNumber = c.OrderNumber,
                        CarId = c.CarId,
                        CarMake = c.Car.Model.Make.Name,
                        CarModel = c.Car.Model.Name,
                        ClientId = c.ClientId,
                        ClientFirstName = c.Client.FirstName,
                        ClientLastName = c.Client.LastName,
                        Purchasedate = c.PurchaseDate,
                        OrderStatus = c.OrderStatus
                    }).OrderBy(s => s.OrderNumber);
                    break;
            }

            return result;
        }

        public IEnumerable<CarsForOrderListingServiceModel> CarsForOrderSelect()
        => this.data.Cars.Select(x => new CarsForOrderListingServiceModel
        {
            CarId = x.Id,
            CarMake = x.Model.Make.Name,
            CarModel = x.Model.Name,
            CarYear = x.Model.Year,
            Color = x.Color,
            VIN = x.VIN,
            HorsePower = x.Engine.HorsePower,
            CubicCentimeters = x.Engine.CubicCentimeters,
            Transmission = x.Engine.Transmission,
            FuelType = x.Engine.FuelType,
            IsSold = x.IsSold,
            CarPrice = x.Price
        })
            .Where(x => x.IsSold == WebCarApp.Models.IsSold.No)
            .AsNoTracking()
            .ToList();

        public IEnumerable<ClientsForOrderListingServiceModel> ClientsForOrderSelect()
        => this.data.Clients.Select(x => new ClientsForOrderListingServiceModel
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            EGN = x.EGN
        })
            .AsNoTracking()
            .ToList();

        public int Total()
       => this.data.Orders.Count();
        public void Create(CreateOrderServiceModel model)
        {
            var car = _carService.GetById(model.CarId);
            var client = _clientService.FindById(model.ClientId);
            if (car == null ||
              client ==null ||
              model.PurchasePrice < 1)
            {
                throw new ArgumentException("Invalid Input Data");
            }
            var order = new Order()
            {
                CarId = model.CarId,
                ClientId = model.ClientId,
                OrderStatus = model.OrderStatus,
                PurchaseDate = model.PurchaseDate,
                PurchasePrice = model.PurchasePrice,
                OrderNumber = Guid.NewGuid()
            };
            this.data.Add(order);
            SellThisCar(model);
            this.data.SaveChanges();

        }

        private void SellThisCar(CreateOrderServiceModel model)
        {
            var findCar = this.data.Cars.Where(x => x.Id == model.CarId).FirstOrDefault();
            findCar.IsSold = IsSold.Yes;
        }

        public FullOrderDetailsServiceModel GetByOrderNumber(string orderNumber)
        {

            var order = this.data.Orders.Where(x => x.OrderNumber.ToString().Contains(orderNumber.Trim())).FirstOrDefault();
            if (order == null)
            {
                throw new ArgumentException("The is no such order with that order Number");
            }
            var car = this.data.Cars.Where(x => x.Id == order.CarId).FirstOrDefault();
            var client = this.data.Clients.Where(x => x.Id == order.ClientId).FirstOrDefault();
            Model modelForCar = this.data.Models.Where(x => x.Id == car.ModelId).FirstOrDefault();
            Make makeForCar = this.data.Makes.Where(x => x.Id == modelForCar.MakeId).FirstOrDefault();
            Engine engineForCar = this.data.Engines.Where(x => x.Id == car.EngineId).FirstOrDefault();
            var fodsm = new FullOrderDetailsServiceModel()
            {
                CarDetails = new FullCarDetailsServiceModel
                {
                    Model = modelForCar.Name,
                    Make = makeForCar.Name,
                    VIN = car.VIN,
                    Color = car.Color,
                    Price = car.Price,
                    Kilowatt = engineForCar.Kilowatt,
                    Tranmission = engineForCar.Transmission,
                    FuelType = engineForCar.FuelType,
                    HorsePower = engineForCar.HorsePower,
                    CubicCentimeters = engineForCar.CubicCentimeters,
                    ModelYear = modelForCar.Year
                },
                ClientDetails = new ClientDetailsServiceModel
                {
                    Id = client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    EGN = client.EGN,
                    Email = client.Email,
                    PhoneNumber = client.PhoneNumber
                },
                PurchaseDate = order.PurchaseDate,
                OrderNumber = order.OrderNumber,
                OrderStatus = order.OrderStatus,
                PurchasePrice = order.PurchasePrice
            };
            return fodsm;


        }

        public OrderPurchasePriceAndDate GetInfoForOrderDetails(string id)
        {
            var car = this.data.Cars.Where(x => x.Id == int.Parse(id)).FirstOrDefault();
            return new OrderPurchasePriceAndDate
            {
                ID = car.Id,
                Price = car.Price,
                PurchaseDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm", DateTimeFormatInfo.InvariantInfo)
            };
        }

        public bool IsThereOrderNumber(string orderNumber)
      => this.data.Orders.Any(x => x.OrderNumber.ToString().ToLower().StartsWith(orderNumber.ToLower().Trim()));



        public  IEnumerable<ModelsForOrderServiceModel> GetOrderData()
        {
            return 
                this.data.Orders
                 .AsNoTracking()
                 .Select(x => new ModelsForOrderServiceModel
                 {
                     OrderNumber = x.OrderNumber,
                     CarId = x.CarId,
                     ClientId = x.ClientId,
                     PurchaseDate = x.PurchaseDate,
                     PurchasePrice = x.PurchasePrice,
                     OrderStatus = x.OrderStatus
                 })
                .ToList();
        }

        public Dictionary<string,string> OrderDataForAPI(string orderNumber,bool carId, bool clinetId, bool purchaseDate, bool orderStatus, bool orderNumberCheck, bool purchasePrice)
        {
            var currentOrder = this.data.Orders.FirstOrDefault(x => x.OrderNumber.ToString() == orderNumber);
            var dict = new Dictionary<string, string>();
            if (currentOrder==null)
            {
                throw new NullReferenceException("Invalid Order Number.");
            }
            var filteredData = new APIOrderDetails();
            if (orderNumberCheck)
            {
                dict["OrderNumber"] = currentOrder.OrderNumber.ToString();
        
            }
            if (carId)
            {
                dict["CarId"] = currentOrder.CarId.ToString();
   
            }
            if (clinetId)
            {
                dict["ClientId"] = currentOrder.CarId.ToString();
           
            }
            if (purchaseDate)
            {
                dict["PurchaseDate"] = currentOrder.CarId.ToString();
         
            }
            if (orderStatus)
            {
                dict["OrderStatus"] = currentOrder.OrderStatus.ToString();
           
            }
            if (purchasePrice)
            {
                dict["PurchasePrice"] = currentOrder.PurchasePrice.ToString();
         
            }
            return dict;

        }
     
    }
}
