using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class UsersController : Controller
    {
        private readonly string _path;

        public UsersController(
        )
        {
            _path = Path.GetFullPath(ToString()!);
        }

        // [Authorize]
        [HttpGet("{username}")]
        public UserModel Get(string username)
        {
            // Temp
            return new UserModel();
        }

        // [Authorize]
        [HttpGet("{username}")]
        [Route("{orders}")]
        public List<object> GetOrders(string username)
        {
            // TODO should return List<Order>()
            return new List<object>();
        }

        [HttpPost]
        public void AddUser(UserInputModel userInput)
        {
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