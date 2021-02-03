using System;
using System.Collections.Generic;
using System.Text;
using WebCarApp.Models;
using WebCarApp.Services.Models.Car;
using WebCarApp.Services.Models.Clients;

namespace WebCarApp.Services.Models.Orders
{
 public   class FullOrderDetailsServiceModel
    {
        public FullCarDetailsServiceModel CarDetails { get; set; }

        public ClientDetailsServiceModel ClientDetails { get; set; }

        public DateTime PurchaseDate { get; set; }

        public Guid OrderNumber { get; set; }


        public OrderStatus OrderStatus { get; set; }
        public double PurchasePrice { get; set; }
    }
}
