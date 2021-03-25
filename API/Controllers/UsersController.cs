using System;
using System.IO;
using API.Models;
using Core.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IAddUserService _addUserService;
        private readonly string _path;

        public UsersController(IAddUserService addUserService)
        {
            _addUserService = addUserService;
            _path = Path.GetFullPath(ToString()!);
        }

        // [Authorize]
        [HttpGet("{username}")]// /users/aliel
        public UserModel Get(string username)
        {
            return new UserModel();
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