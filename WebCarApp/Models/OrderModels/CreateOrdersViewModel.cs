using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCarApp.Models;

namespace WebCarApp.Web.Models.OrderModels
{
    public class CreateOrdersViewModel
    {
        
        public DateTime PurchaseDate { get; set; }
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public OrderStatus OrderStatus{ get; set; }
        public double PurchasePrice{ get; set; }


    }
}
