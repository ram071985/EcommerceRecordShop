using System;
using System.IO;
using API.Models;
using Core.Entities;
using Core.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

        // [Authorize]
namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class UsersController : Controller
    {
        private readonly IAddUserService _addUserService;
        private readonly IGetUserService _getUserService;
        private readonly string _path;

        public UsersController(
            IAddUserService addUserService,
            IGetUserService getUserService)
        {
            _addUserService = addUserService;
            _getUserService = getUserService;
            _path = Path.GetFullPath(ToString()!);
        }

        // [Authorize]
        [HttpGet("{userId}")]
        public UserModel GetUserByUserId(string userId)
        {
            if (userId == null)
                throw new Exception("Invalid User Id");

            var user = _getUserService.GetUserByUserId(userId);

            return TransformUserToModel(user);
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

        private UserModel TransformUserToModel(User user)
        {
            return new UserModel
            {
                Username = user.Username,
                Email = user.Email,
                WalletBalance = user.WalletBalance
            };
        }
    }
}