using System;
using System.Collections.Generic;
using System.Text;

namespace WebCarApp.Services.Models.Clients
{
   public class ClientDetailsServiceModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EGN { get; set; }
    }
}
