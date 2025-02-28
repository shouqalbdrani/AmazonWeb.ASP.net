using AmazonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AmazonWeb.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
    
        private static List<Product> products = new()
        {
            new Product { ProductID = 1, Name = "Laptop", Category = "Electronics", Price = 2000.99M, StockQuantity = 10 },
            new Product { ProductID = 2, Name = "Smartphone", Category = "Electronics", Price = 999.99M, StockQuantity = 20 },
            new Product { ProductID = 3, Name = "Headphones", Category = "Accessories", Price = 150.75M, StockQuantity = 50 }
        };

        
        [HttpGet("")]
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(userId))
            {

                return RedirectToAction("Login", "User");
            }

            return View(products); 
        }
    }
}
