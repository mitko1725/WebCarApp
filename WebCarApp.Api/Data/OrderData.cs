using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCarApp.Api.Data
{
    public class OrderData
    {

        public bool OrderNumberCheck { get; set; }
        public bool CarId { get; set; }
        public bool ClientId { get; set; }
        public bool PurchaseDate { get; set; }
        public bool OrderStatus { get; set; }
        public bool PurchasePrice { get; set; }
        public Guid OrderNumber{ get; set; }

    }
}
