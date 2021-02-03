using System;
using System.Collections.Generic;
using System.Text;
using WebCarApp.Models;

namespace WebCarApp.Services.Models.Orders
{
  public  class CreateOrderServiceModel
    {
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public DateTime PurchaseDate { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public double PurchasePrice { get; set; }
       



    }
}
