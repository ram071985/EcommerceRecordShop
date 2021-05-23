using API.Models;
using Core.Entities;
using Core.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace API.Controllers
{
    [ApiController, Route("[controller]")]
    public sealed class OrdersController : Controller
    {
        private readonly IOrdersService _orderService;
        private readonly string _path;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
            _path = Path.GetFullPath(ToString()!);
        }

        //      5001/orders/get/{customerId}
        // [Authorize]
        [HttpGet("get/{customerId}")]
        public List<Order> GetOrdersByUserId(string customerId)
        {
            if (customerId == null)
                throw new Exception("Invalid User Id");

            
            return _orderService.GetOrdersByCustomerId(customerId);
        }

        //      5001/orders/place/{orderNumber}
        // [Authorize]
        [HttpGet("place/{customerId}")]
        public Order PlaceOrder(string customerId)
        {
            if (customerId == null)
                throw new Exception("Invalid User Id");

            return _orderService.PlaceOrder(customerId);
        }
        
        //      5001/orders/{orderNumber}
        // [Authorize]
        [HttpPatch("{orderNumber}")]
        public void ReturnItem(string orderNumber, List<ReturnInputModel> orderInputs)
        {
            
        }
    }
}