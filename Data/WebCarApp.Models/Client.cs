using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCarApp.Models
{
   public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1,25)]
        public string FirstName { get; set; }
        [Required]
        [Range(1, 25)]
        public string LastName { get; set; }
        [Required]
        
        public string EGN { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
