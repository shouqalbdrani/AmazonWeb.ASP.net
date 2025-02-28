using Microsoft.AspNetCore.Mvc;
using AmazonWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonWeb.Controllers
{
    [Route("Orders")]
    public class OrderController : Controller
    {
        private static readonly List<Order> orders = new()
        {
            new Order { OrderID = 1, UserID = 1, OrderDate = DateTime.Now.AddDays(-2), Status = "Completed" },
            new Order { OrderID = 2, UserID = 1, OrderDate = DateTime.Now.AddDays(-1), Status = "Shipped" },
            new Order { OrderID = 3, UserID = 2, OrderDate = DateTime.Now, Status = "Processing" }
        };

        [HttpGet("PlaceOrder")]
        public IActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost("PlaceOrder")]
        public IActionResult PlaceOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderID = orders.Count + 1;
                order.OrderDate = DateTime.Now;
                orders.Add(order);
                return RedirectToAction("OrderHistory", new { userId = order.UserID });
            }
            return View(order);
        }

        [HttpGet("OrderHistory/{userId:int}")]
        public IActionResult OrderHistory(int userId)
        {
            var userOrders = orders.Where(o => o.UserID == userId).ToList();
            if (userOrders.Count == 0)
            {
                return NotFound($"No orders found for user {userId}");
            }
            return View(userOrders);
        }
    }
}
