using System;
using System.Collections.Generic;
using System.Text;
using WebCarApp.Models;
using WebCarApp.Services.Models.Make;
using WebCarApp.Services.Models.Model;

namespace WebCarApp.Services.Models.Car
{
  public  class CarListingServiceModel
    {
        public int Id { get; set; }

        public string Model{ get; set; }

        public string Make { get; set; }

        public int HorsePower { get; set; }
        public double CubicCentimeters { get; set; }

        public int ModelYear { get; set; }
        public IsSold IsSold{ get; set; }

    }
}
