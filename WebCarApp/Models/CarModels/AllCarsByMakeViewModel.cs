using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCarApp.Services.Models.Car;

namespace WebCarApp.Web.Models.CarModels
{
    public class AllCarsByMakeViewModel
    {
        public IEnumerable<AllCarsByMakeServiceModel> Cars { get; set; }
    }
}
