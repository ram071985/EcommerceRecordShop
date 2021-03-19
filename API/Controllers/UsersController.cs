using System;
using System.Collections.Generic;
using System.IO;
using API.Models;
using Core.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class UsersController : Controller
    {
        private readonly IAddUserService _addUserService;
        private readonly string _path;

        public UsersController(
            IAddUserService addUserService
        )
        {
            _addUserService = addUserService;
            _path = Path.GetFullPath(ToString()!);
        }

        // [Authorize]
        [HttpGet("{username}")]
        public UserModel Get(string username)
        {
            return new UserModel();
        }

        // [Authorize]
        [HttpGet]
        [Route("{orders}/{username}")]
        public List<object> GetOrders(string username)
        {
            // TODO should return List<Order>()
            return new List<object>();
        }

        [HttpPost]
        public void AddUser(UserInputModel userInput)
        {
            if (userInput.Username == null || userInput.Password == null || userInput.Email == null)
                throw new Exception("invalid input");
            
            _addUserService.Add(userInput.Username, userInput.Password, userInput.Email);
        }

        // [Authorize]
        [HttpPatch]
        public void PatchUser(UserInputModel userInput)
        {
        }

        // [Authorize]
        [HttpDelete("{username}")]
        public void DeleteUser(string username)
        {
        }
    }
}