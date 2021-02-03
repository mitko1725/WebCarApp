

using System;
using WebCarApp.Models;
using WebCarApp.Services.Models.Car;
using WebCarApp.Services.Models.Clients;

namespace WebCarApp.Services.Models.Orders
{
  public  class OrderListingServiceModel
    {
        public Guid OrderNumber { get; set; }
        public int CarId { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        

        public int ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }


        public DateTime Purchasedate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        


    }
}
