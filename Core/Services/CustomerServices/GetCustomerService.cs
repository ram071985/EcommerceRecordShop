using System.Linq;
using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.CustomerServices
{
    public interface IGetCustomerService
    {
        Customer GetCustomerById(string customerId);
    }

    public class GetCustomerService : IGetCustomerService
    {
        private readonly RecordStoreContext _db;

        public GetCustomerService(RecordStoreContext db)
        {
            _db = db;
        }
        
        public Customer GetCustomerById(string customerId)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.Id == customerId); 
            
            return customer;
        }
    }
}