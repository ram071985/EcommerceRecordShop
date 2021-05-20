using Core.Entities;

namespace Core.Services.CustomerServices
{
    public interface IGetCustomerService
    {
        Customer GetCustomerById(string userId);
    }

    public class GetCustomerService : IGetCustomerService
    {
        public Customer GetCustomerById(string userId)
        {
            // TODO get user from database => _dbService.GetUserByUserId
            return new Customer();
        }
    }
}