using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities;
using Integrations.Spotify.Services;

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
        private readonly RecordStoreContext _db;
        private readonly ISpotifyAlbumService _albumService;
        private readonly Random random = new Random();

        public GetProductsService(RecordStoreContext db, ISpotifyAlbumService albumService)
        {
            _db = db;
            _albumService = albumService;
        }
        
        public List<Product> GetAvailableProducts(int count)
        {
            // TODO implement Random
            var allProducts = _db.Products
                .ToList();

            var products = new List<Product>();
            if (count > 5) count = 5;
            for (var i = 0; i < count; i++)
                products.Add(allProducts[i]);

            var spotifyIds = products
                .Select(x => x.SpotifyId)
                .ToList();
                
            var albums = _albumService.GetAlbumsBySpotifyIds(spotifyIds);
            
            for (var i = 0; i < products.Count; i++)
                products[i].Album = albums[i];

            return products;
        }

        public List<Product> GetAvailableProductsByGenre(int count, string genre)
        {
            // TODO implement Random
            var allProductsByGenre = _db.Products
                .Where(x => x.Genre == genre)
                .ToList();

            var products = new List<Product>();
            if (count > 5) count = 5;
            for (var i = 0; i < count; i++)
                products.Add(allProductsByGenre[i]);

            var spotifyIds = products
                .Select(x => x.SpotifyId)
                .ToList();

            var albums = _albumService.GetAlbumsBySpotifyIds(spotifyIds);

            for (var i = 0; i < products.Count; i++)
                products[i].Album = albums[i];

            return products;
        }

        public Product GetProductById(string id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
        
        private List<Product> Products { get; } = new()
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
    }
}