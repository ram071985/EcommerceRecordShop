using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Services.ProductServices
{
    public interface IGetProductsService
    {
        List<Product> GetAvailableProducts(int count);
        List<Product> GetAvailableProductsByGenre(int count, string genre);
        Product GetProductById(string id);
    }

    public class GetProductsService : IGetProductsService
    {
        private List<Product> Products { get; } = new List<Product>
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
                Price = 23.98M,
                SpotifyId = "3HNnxK7NgLXbDoxRZxNWiR"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                Price = 42.90M,
                SpotifyId = "3ZpoX3ij0YBUeJoGfbVH0Q"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                Price = 31.83M,
                SpotifyId = "1HxsSJHTqeUxDoKN26h8pB"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                Price = 21.13M,
                SpotifyId = "0CA2EVHhRPR5VPV78KZw89"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                Price = 19.42M,
                SpotifyId = "4hkERQVrmM9JQ9g2eie2tL"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                Price = 30.18M,
                SpotifyId = "5fkFWJ9LZizXE4yPenNGuy"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                Price = 18.53M,
                SpotifyId = "30Perjew8HyGkdSmqguYyg"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                Price = 24.76M,
                SpotifyId = "7d9R5yx2cq5nSuzAG8Vd0m"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                Price = 26.31M,
                SpotifyId = "30ly6F6Xl0TKmyBCU50Khv"
            }
        };
        
        public List<Product> GetAvailableProducts(int count)
        {
            // TODO get product list from DB
            var products = new List<Product>();

            if (count > 10) count = 10;
            for (var i = 0; i < count; i++)
            {
                products.Add(Products[i]);
            }

            Console.WriteLine(products.Count);

            return products;
        }

        public List<Product> GetAvailableProductsByGenre(int count, string genre)
        {
            Console.WriteLine(genre);
            // TODO get product list from DB
            var products = new List<Product>();
            
            if (count > 10) count = 10;
            for (var i = 0; i < count; i++)
            {
                products.Add(Products[i]);
            }

            return products;
        }

        public Product GetProductById(string id)
        {
            return new Product
            {
                SpotifyId = "3ZpoX3ij0YBUeJoGfbVH0Q",
                Price = 35.12M,
                Id = id
            };
        }
    }
}