using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using API.Helpers;
using Core.Entities;

// Just giving this a whirl. It's from JWT authtication tutorial. - https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api
// I feel like it's a good idea if we start getting JWT auth set up early on. 
namespace Core.Services.AuthenticateServices
{
    public interface IAuthenticateUserService
    {

    }
    public class AuthenticateUserService : IAuthenticateUserService
    {
        // Mock list of entitity user data coming back from database.
        private List<User> _users = new List<User>
        {
            new User { Username = "TEST", Password = "TEST", Email = "TEST"}
        };

        private readonly AppSettings _appSettings;

        public AuthenticateUserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
    }
}
