using API.Models;
using Core.Entities;
using Core.Services.CustomerServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace API.Controllers
{
    [ApiController, Route("[controller]")]
    public sealed class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly string _path;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
            _path = Path.GetFullPath(ToString()!);
        }

        //      5001/customers/{customerId}
        // [Authorize]
        [HttpGet("{customerId}")]
        public CustomerModel GetCustomerById(string customerId)
        {
            if (customerId == null)
                throw new Exception("Invalid User Id");

            var customer = _customerService.GetCustomerById(customerId);

            return MapCustomerModel(customer);
        }

        //      5001/customers
        [HttpPost]
        public void AddCustomer(CustomerInputModel customerInput)
        {
            if (customerInput.CustomerName == null || customerInput.Password == null || customerInput.Email == null)
                throw new Exception("invalid input");

            _customerService.AddCustomer(customerInput.CustomerName, customerInput.Password, customerInput.Email);
        }

        //      5001/customers
        // [Authorize]
        [HttpPatch]
        public void PatchCustomer(CustomerInputModel customerInput)
        {
        }

        //      5001/customers/{customerId}
        // [Authorize]
        [HttpPatch("deactivate/{customerId}")]
        public void DeactivateCustomer(string customerId)
        {
            _customerService.DeactivateCustomer(customerId);
        }

        //      5001/customers/{customerId}
        // [Authorize]
        [HttpPatch("activate/{customerId}")]
        public void ActivateCustomer(string customerId)
        {
            _customerService.ActivateCustomer(customerId);
        }
        
        private static CustomerModel MapCustomerModel(Customer customer)
        {
            return new()
            {
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                WalletBalance = customer.WalletBalance,
                IsActive = customer.IsActive
            };
        }
    }
}
