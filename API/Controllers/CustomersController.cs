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
        private readonly IAddCustomerService _addCustomerService;
        private readonly IGetCustomerService _getCustomerService;
        private readonly string _path;

        public CustomersController(
            IAddCustomerService addCustomerService,
            IGetCustomerService getCustomerService)
        {
            _addCustomerService = addCustomerService;
            _getCustomerService = getCustomerService;
            _path = Path.GetFullPath(ToString()!);
        }

        //      5001/customers/{customerId}
        // [Authorize]
        [HttpGet("{customerId}")]
        public CustomerModel GetCustomerById(string customerId)
        {
            if (customerId == null)
                throw new Exception("Invalid User Id");

            var customer = _getCustomerService.GetCustomerById(customerId);

            return MapCustomerModel(customer);
        }
        
        //      5001/customers
        [HttpPost]
        public void AddCustomer(CustomerInputModel customerInput)
        {
            if (customerInput.CustomerName == null || customerInput.Password == null || customerInput.Email == null)
                throw new Exception("invalid input");
            
            _addCustomerService.Add(customerInput.CustomerName, customerInput.Password, customerInput.Email);
        }

        //      5001/customers
        // [Authorize]
        [HttpPatch]
        public void PatchCustomer(CustomerInputModel customerInput)
        {
        }

        //      5001/customers/{customerId}
        // [Authorize]
        [HttpDelete("{customerId}")]
        public void DeleteCustomer(string customerId)
        {
        }

        private static CustomerModel MapCustomerModel(Customer customer)
        {
            return new()
            {
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                WalletBalance = customer.WalletBalance
            };
        }
    }
}