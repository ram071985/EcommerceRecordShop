using System;
using System.Collections.Generic;

namespace Core.Services.ProductServices
{
    internal class ProductSeedItem
    {
        public string Genre { get; init; }
        public string SpotifyId { get; init; }
    }

    public interface IAdminProductSeedService
    {
        void SeedDatabase();
    }

    public class AdminProductSeedService : IAdminProductSeedService
    {
        private readonly IAdminProductsService _adminProductsService;
        private static readonly Random Random = new();

        public AdminProductSeedService(IAdminProductsService adminProductsService)
        {
            _adminProductsService = adminProductsService;
        }

        public void SeedDatabase()
        {
            _productSeeds.ForEach(seed =>
                _adminProductsService
                    .AddProduct(seed.SpotifyId, seed.Genre, 20.00M + (decimal) Random.NextDouble() * 6));
        }

        private readonly List<ProductSeedItem> _productSeeds = new()
        {
            new ProductSeedItem
            {
                Genre = "hiphop",
                SpotifyId = "5qkWpkGMULLVnSHb3Sej4X"
            },
            new ProductSeedItem
            {
                Genre = "hiphop",
                SpotifyId = "3HNnxK7NgLXbDoxRZxNWiR"
            },
            new ProductSeedItem
            {
                Genre = "hiphop",
                SpotifyId = "1RmcAYmGiRHFBjhgkrg3AA"
            },
            new ProductSeedItem
            {
                Genre = "hiphop",
                SpotifyId = "4hkERQVrmM9JQ9g2eie2tL"
            },
            new ProductSeedItem
            {
                Genre = "hiphop",
                SpotifyId = "2HTbQ0RHwukKVXAlTmCZP2"
            },
            new ProductSeedItem
            {
                Genre = "hiphop",
                SpotifyId = "39xHAZmTUSQJyXt6ebpjKT"
            },
            new ProductSeedItem
            {
                Genre = "hiphop",
                SpotifyId = "1gPqbxhs90kppgOVxGOPzd"
            },
            new ProductSeedItem
            {
                Genre = "hiphop",
                SpotifyId = "3YPK0bNOuayhmSrs0sIIBR"
            },
            new ProductSeedItem
            {
                Genre = "rock",
                SpotifyId = "30Perjew8HyGkdSmqguYyg"
            },
            new ProductSeedItem
            {
                Genre = "rock",
                SpotifyId = "0CA2EVHhRPR5VPV78KZw89"
            },
            new ProductSeedItem
            {
                Genre = "rock",
                SpotifyId = "30ly6F6Xl0TKmyBCU50Khv"
            },
            new ProductSeedItem
            {
                Genre = "rock",
                SpotifyId = "0GJH6shkenNdqkpGdsY8aa"
            },
            new ProductSeedItem
            {
                Genre = "rock",
                SpotifyId = "5B4PYA7wNN4WdEXdIJu58a"
            },
            new ProductSeedItem
            {
                Genre = "rock",
                SpotifyId = "24E6rDvGDuYFjlGewp4ntF"
            },
            new ProductSeedItem
            {
                Genre = "punk",
                SpotifyId = "7d9R5yx2cq5nSuzAG8Vd0m"
            },
            new ProductSeedItem
            {
                Genre = "punk",
                SpotifyId = "6Z8BYH27wINoUk4QMUx7gh"
            },
            new ProductSeedItem
            {
                Genre = "punk",
                SpotifyId = "5nO5x1Qgnf7zwmO83qrHRn"
            },
            new ProductSeedItem
            {
                Genre = "punk",
                SpotifyId = "1AiVqGWu6HcyLYuB0BMvcS"
            },
            new ProductSeedItem
            {
                Genre = "punk",
                SpotifyId = "5yBYSnmpRANjb99msqeCee"
            },
            new ProductSeedItem
            {
                Genre = "punk",
                SpotifyId = "2RNTBrSO8U8XjjEj9RVvZ5"
            }
        };
    }
}