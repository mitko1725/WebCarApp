using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCarApp.Models
{
   public class Extra
    {
        public int Id { get; set; }
        [Required]
        public string ExtraName { get; set; }
        public ICollection<CarExtras> CarExtras { get; set; } = new HashSet<CarExtras>();
    }
}
