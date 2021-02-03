using System;
using System.Collections.Generic;
using System.Text;

namespace WebCarApp.Models
{
   public class CarExtras
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int ExtraId { get; set; }
        public Extra Extra { get; set; }
    }
}
