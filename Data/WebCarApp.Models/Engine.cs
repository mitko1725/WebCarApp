using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCarApp.Models
{
   public class Engine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public int HorsePower { get; set; }
        [Required]
    
        public int Kilowatt { get; set; }
        [Required]
        public double CubicCentimeters { get; set; }
        [Required] 

        public Transmission Transmission { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
