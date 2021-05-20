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
    public sealed class OrdersController : Controller
    {
        private readonly IOrdersService _orderService;
        private readonly string _path;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
            _path = Path.GetFullPath(ToString()!);
        }

        // [Authorize]
        [HttpGet("get/{customerId}")]
        public List<Order> GetOrdersByUserId(string customerId)
        {
            if (customerId == null)
                throw new Exception("Invalid User Id");

            return _orderService.GetOrdersByCustomerId(customerId);
        }

        // [Authorize]
        [HttpGet("place/{customerId}")]
        public Order PlaceOrder(string customerId)
        {
            if (customerId == null)
                throw new Exception("Invalid User Id");

            return _orderService.PlaceOrder(customerId);
        }

        // [Authorize]
        [HttpPatch("{orderNumber}")]
        public void ChangeOrder(string orderNumber)
        {
            // TODO do we need this endpoint?
        }
    }
}