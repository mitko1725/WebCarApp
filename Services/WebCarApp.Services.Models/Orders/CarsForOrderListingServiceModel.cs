using System;
using System.Collections.Generic;
using System.Text;
using WebCarApp.Models;

namespace WebCarApp.Services.Models.Orders
{
   public class CarsForOrderListingServiceModel
    {
        public int CarId { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }

        public int HorsePower { get; set; }

        public double CubicCentimeters{ get; set; }
        public Transmission  Transmission{ get; set; }
        public FuelType  FuelType { get; set; }
        public IsSold IsSold{ get; set; }
        public double CarPrice { get; set; }

    }
}
