using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCarApp.Models;

namespace WebCarApp.Web.Models.CarModels
{
    public class CreateCarViewModel
    {
        public int Id { get; set; }
        public DateTime ProductionDate { get; set; }
        public string VIN { get; set; }

        public double Price { get; set; }
        public string Color { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }
    }
}
