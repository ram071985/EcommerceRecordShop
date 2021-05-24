using System;
using System.Linq;
using Core.DataAccess;
using Core.Entities;

namespace Core.Services.ProductServices
{
    public interface IAdminProductsService
    {
        void AddProduct(string spotifyId, string genre, decimal price);
    }
    
    public class AdminProductsService : IAdminProductsService
    {
        private readonly RecordStoreContext _db;

        public AdminProductsService(RecordStoreContext db)
        {
            _db = db;
        }

        public void AddProduct(string spotifyId, string genre, decimal price)
        {
            var product = _db.Products.FirstOrDefault(x => x.SpotifyId == spotifyId);
            
            if (product != null)
                throw new Exception("you have already added a product with this id");
            
            var newProduct = new Product
            {
                Id = Guid.NewGuid().ToString(),
                SpotifyId = spotifyId,
                Price = price,
                Genre = genre,
                DateAdded = DateTime.Now,
                QuantityAvailable = 30
            };

            _db.Add(newProduct);
            _db.SaveChanges();
        }
    }
}