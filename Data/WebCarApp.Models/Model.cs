using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCarApp.Models
{
  public  class Model
    {
        public int  Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string  Name { get; set; }
        
        [Range(1950,2050)]
        public int Year { get; set; }

        public int MakeId { get; set; }
        public Make Make { get; set; }
        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        
    }
}
