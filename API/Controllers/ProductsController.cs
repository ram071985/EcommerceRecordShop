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
        
        //          5001/products   
        [HttpGet]
        public List<ProductModel> GetProducts()
        {
            var count = 5;
            var products = _productsService.GetAvailableProducts(count);

            var productModels = TransformProductsToModels(products);

            return productModels;
        }

        //          5001/products/5   
        [HttpGet("{count:int}")]
        public List<ProductModel> GetProductsByCount(int count)
        {
            var products = _productsService.GetAvailableProducts(count);

            var productModels = TransformProductsToModels(products);

            return productModels;
        }

        //          5001/products/hiphop   
        [HttpGet("{genre}")]
        public List<ProductModel> GetProductsByGenre(string genre)
        {
            if (genre == null)
                throw new Exception("No Genre Specified");

            var count = 5;
            var products = _productsService.GetAvailableProductsByGenre(count, genre);

            var productModels = TransformProductsToModels(products);

            return productModels;
        }

        //          5001/products/hiphop/5   
        [HttpGet("{genre}/{count:int}")]
        public List<ProductModel> GetProductsByGenreByCount(string genre, int count)
        {
            if (genre == null)
                throw new Exception("No Genre Specified");

            var products = _productsService.GetAvailableProductsByGenre(count, genre);

            var productModels = TransformProductsToModels(products);

            return productModels;
        }
        
        //          5001/products/hiphop   
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
    }
}