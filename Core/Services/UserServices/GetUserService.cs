using Core.Entities;

namespace Core.Services.UserServices
{
    public interface IGetUserService
    {
        User GetUserByUserId(string userId);
    }

    public class GetUserService : IGetUserService
    {
        public User GetUserByUserId(string userId)
        {
            // TODO get user from database => _dbService.GetUserByUserId
            return new User();
        }
    }
}