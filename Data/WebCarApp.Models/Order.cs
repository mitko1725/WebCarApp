using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCarApp.Models
{
    /// <summary>
/// HOLDS Orders FROM CARS AND CLIENTS 
/// </summary>
   public class Order
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
        [Required]
        public Guid OrderNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public double PurchasePrice { get; set; }
    }
}
