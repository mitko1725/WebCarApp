 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCarApp.Models
{
  public  class Car
    {
        public int Id { get; set; }
        public DateTime  ProductionDate { get; set; }
        [Required]
        [MaxLength(17)]
        public string VIN{ get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        [Required]
        [MaxLength(30)]

        public string Color { get; set; }
        [Required]
        public IsSold IsSold { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int EngineId { get; set; }
        public Engine Engine { get; set; }
        public ICollection<CarExtras> CarExtras { get; set; } = new HashSet<CarExtras>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();




    }
}
