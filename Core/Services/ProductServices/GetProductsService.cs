using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Services.ProductServices
{
    public interface IGetProductsService
    {
        List<Product> GetAvailableProducts();
    }

    public class GetProductsService : IGetProductsService
    {
        public List<Product> GetAvailableProducts()
        {
            // TODO get product list from DB
            var products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Price = 22.56M,
                    SpotifyId = "5qkWpkGMULLVnSHb3Sej4X"
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Price = 22.83M,
                    SpotifyId = "3HNnxK7NgLXbDoxRZxNWiR"
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Price = 42.90M,
                    SpotifyId = "3ZpoX3ij0YBUeJoGfbVH0Q"
                }
            };
            // TODO ^^^^ change this to call something like _dbServices.GetProducts from db
            // TODO May need to make a GetProductsByGenre Service

            return products;
        }
        public List<Product> GetAvailableProductsByGenre(string genre, int productAmount)
        {
            // TODO get product list from DB
            var products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Price = 22.56M,
                    SpotifyId = "5qkWpkGMULLVnSHb3Sej4X"
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Price = 22.83M,
                    SpotifyId = "3HNnxK7NgLXbDoxRZxNWiR"
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Price = 42.90M,
                    SpotifyId = "3ZpoX3ij0YBUeJoGfbVH0Q"
                }
            };
            // TODO ^^^^ change this to call something like _dbServices.GetProducts from db
            // TODO May need to make a GetProductsByGenre Service

            return products;
        }
    }
}