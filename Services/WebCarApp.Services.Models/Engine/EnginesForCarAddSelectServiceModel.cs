using System;
using System.Collections.Generic;
using System.Text;
using WebCarApp.Models;

namespace WebCarApp.Services.Models.Engine
{
   public class EnginesForCarAddSelectServiceModel
    {
        public int Id { get; set; }
        public int HorsePower { get; set; }
        public double CubicCentimeters { get; set; }
        public Transmission  Transmisson { get; set; }
        public FuelType  FuelType { get; set; }
    }
}
