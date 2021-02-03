using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCarApp.Models
{
    public enum  OrderStatus
    {
      
        [Display(Name="In Process")]
        In_Process=0,
        Finished=1
    }
}
