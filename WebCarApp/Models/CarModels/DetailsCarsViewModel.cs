using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCarApp.Models;

namespace WebCarApp.Web.Models.CarModels
{
    public class DetailsCarsViewModel
    {
        public string Model { get; set; }

        public string Make { get; set; }
        public string VIN { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int Kilowatt { get; set; }
        public Transmission Tranmission { get; set; }
        public FuelType FuelType { get; set; }
        public int HorsePower { get; set; }
        public double CubicCentimeters { get; set; }

        public int ModelYear { get; set; }
    }
}
