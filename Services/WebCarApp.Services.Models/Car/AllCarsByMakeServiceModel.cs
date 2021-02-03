using System;
using System.Collections.Generic;
using System.Text;

namespace WebCarApp.Services.Models.Car
{
public    class AllCarsByMakeServiceModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Make { get; set; }

        public int HorsePower { get; set; }
        public double CubicCentimeters { get; set; }

        public int ModelYear { get; set; }
    }
}
