using System;
using System.Collections.Generic;
using System.Text;

namespace WebCarApp.Services.Models.Clients
{
   public class CreateClientServiceModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
