using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCarApp.Models;
using WebCarApp.Services.Models.Car;
using WebCarApp.Services.Models.Clients;

namespace WebCarApp.Web.Models.OrderModels
{
    public class OrderDetailsViewModel
    {
        public FullCarDetailsServiceModel CarDetails { get; set; }

        public ClientDetailsServiceModel ClientDetails { get; set; }

        public DateTime PurchaseDate { get; set; }

        public Guid OrderNumber { get; set; }


        public OrderStatus OrderStatus { get; set; }
        public double PurchasePrice { get; set; }
    }
}
