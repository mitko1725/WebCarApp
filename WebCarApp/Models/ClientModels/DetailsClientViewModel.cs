using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCarApp.Services.Models.Clients;

namespace WebCarApp.Web.Models.ClientModels
{
    public class DetailsClientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EGN { get; set; }
        public IEnumerable<ClientOrdersServiceModel> AllOrders { get; set; }

        public bool HasOrders => AllOrders.Count() != 0 ;
    }
}
