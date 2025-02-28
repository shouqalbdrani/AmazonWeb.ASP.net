using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonWeb.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "UserID is required.")]
        public int UserID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Order status is required.")]
        [RegularExpression("Pending|Processing|Shipped|Completed", ErrorMessage = "Invalid order status.")]
        public string Status { get; set; } = "Pending";
    }
}
