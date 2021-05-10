using System;
using System.Collections.Generic;
using API.Models;
using Core.Entities;
using Core.Services.ProductServices;
using Core.Services.SpotifyServices;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ProductsController : Controller
    {
        private readonly IGetProductsService _productsService;
        private readonly ISpotifyAlbumService _spotifyService;

        public ProductsController(
            IGetProductsService productsService,
            ISpotifyAlbumService spotifyService)
        {
            _productsService = productsService;
            _spotifyService = spotifyService;
        }

        [HttpGet("{count}")]
        public List<ProductModel> GetProducts(int? count)
        {
            var productCount = ParseCount(count);

            var products = _productsService.GetAvailableProducts(productCount);

            var productModels = TransformProductsToModels(products);

            return productModels;
        }

        [HttpGet("{genre}/{count}")]
        public List<ProductModel> GetProductsByGenre(string genre, int? count)
        {
            if (genre == null)
                throw new Exception("No Genre Specified");

            var productCount = ParseCount(count);

            var products = _productsService.GetAvailableProductsByGenre(productCount, genre);

            var productModels = TransformProductsToModels(products);

            return productModels;
        }

        private List<ProductModel> TransformProductsToModels(List<Product> products)
        {
            var productModels = new List<ProductModel>();

            products.ForEach(product =>
                productModels.Add(new ProductModel
                {
                    Album = _spotifyService.GetAlbumBySpotifyId(product.SpotifyId),
                    Price = product.Price
                }));

            return productModels;
        }

        private int ParseCount(int? count)
        {
            if (count == null)
                return 10;

            return (int) count;
        }
    }
}