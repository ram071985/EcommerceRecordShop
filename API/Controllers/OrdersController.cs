using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using API.Models;
using Core.Entities;
using Core.Services.OrderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class OrderController : Controller
    {
        private readonly IOrdersService _orderService;
        private readonly string _path;

        public OrderController(IOrdersService orderService)
        {
            _orderService = orderService;
            _path = Path.GetFullPath(ToString()!);
        }

        [Authorize]
        [HttpGet("{userId}")]
        public List<Order> GetOrdersByUserId(string userId)
        {
            if (userId == null)
                throw new Exception("Invalid User Id");

            return _orderService.GetOrdersByCustomerId(userId);
        }

        // [Authorize]
        [HttpPost]
        public Order PlaceOrder(CustomerIdInput customerIdInput)
        {
            if (customerIdInput.CustomerId == null)
                throw new Exception("Invalid User Id");

            return _orderService.PlaceOrder(customerIdInput.CustomerId);
        }

        // [Authorize]
        [HttpPatch("{orderNumber}")]
        public void ChangeOrder(string orderNumber)
        {
            // TODO do we need this endpoint?
        }
    }
}