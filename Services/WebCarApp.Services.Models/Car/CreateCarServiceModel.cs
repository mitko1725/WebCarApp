using System;
using System.Collections.Generic;
using System.Text;
using WebCarApp.Models;
namespace WebCarApp.Services.Models.Car
{
 public   class CreateCarServiceModel
    {
        public int Id { get; set; }
        public DateTime ProductionDate { get; set; }
        public string VIN { get; set; }
       
        public double Price { get; set; }
      

        public string Color { get; set; }
        /// <summary>
        /// This is my Model Entity
        /// </summary>
        public int ModelId { get; set; }
        public int EngineId { get; set; }
        
    }
}
