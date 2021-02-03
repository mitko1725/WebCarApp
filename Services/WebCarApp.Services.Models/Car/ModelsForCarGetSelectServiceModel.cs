using System;
using System.Collections.Generic;
using System.Text;

namespace WebCarApp.Services.Models.Car
{
   public class ModelsForCarGetServiceModel
    {
        public int Id { get; set; }
        public DateTime ProductionDate { get; set; }
        public string VIN { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public int ModelId { get; set; }
        public int EngineId { get; set; }


    }
}
