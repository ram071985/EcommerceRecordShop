using System;
using System.IO;
using API.Models;
using Core.Entities;
using Core.Services.CustomerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

        // [Authorize]
namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        // [Authorize]
        [HttpGet("{customerId}")]
        public CustomerModel GetCustomerById(string customerId)
        {
            if (customerId == null)
                throw new Exception("Invalid User Id");

            var customer = _getCustomerService.GetCustomerById(customerId);

            return MapCustomerToModel(customer);
        }
        
        [HttpPost]
        public void AddCustomer(CustomerInputModel customerInput)
        {
            if (customerInput.CustomerName == null || customerInput.Password == null || customerInput.Email == null)
                throw new Exception("invalid input");
            
            _addCustomerService.Add(customerInput.CustomerName, customerInput.Password, customerInput.Email);
        }

        // [Authorize]
        [HttpPatch]
        public void PatchUser(CustomerInputModel customerInput)
        {
        }

        // [Authorize]
        [HttpDelete("{customerName}")]
        public void DeleteUser(string customerName)
        {
        }

        private CustomerModel MapCustomerToModel(Customer customer)
        {
            return new CustomerModel
            {
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                WalletBalance = customer.WalletBalance
            };
        }
    }
}