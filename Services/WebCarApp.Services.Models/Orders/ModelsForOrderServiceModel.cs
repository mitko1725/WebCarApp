using System;
using System.Collections.Generic;
using System.Text;
using WebCarApp.Models;

namespace WebCarApp.Services.Models.Orders
{
   public class ModelsForOrderServiceModel
    {
        public Guid OrderNumber { get; set; }
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double  PurchasePrice { get; set; }
        public OrderStatus OrderStatus { get; set; }

    }
}
