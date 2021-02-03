using System;
using System.Collections.Generic;
using System.Text;
using WebCarApp.Models;

namespace WebCarApp.Services.Models.Clients
{
   public class ClientOrdersServiceModel
    {
     
        public string OrderNumber { get; set; }
        public string  CarMake { get; set; }
        public string CarModel { get; set; }
        public DateTime PurchaseDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

    }
}
