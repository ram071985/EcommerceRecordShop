using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using Core.Entities;
using Core.Services.ProductServices;
using Integrations.Spotify.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ProductsController : Controller
    {
        private readonly IAddProductsService _addProductsService;
        private readonly IGetProductsService _productsService;
        private readonly ISpotifyAlbumService _spotifyService;

        public ProductsController(
            IAddProductsService addProductsService,
            IGetProductsService productsService,
            ISpotifyAlbumService spotifyService)
        {
            _addProductsService = addProductsService;
            _productsService = productsService;
            _spotifyService = spotifyService;
        }

        [HttpPost]
        public void AdminAddProducts(ProductInputModel product)
        {
            if (product.SpotifyId == null || product.Genre == null || product.Price == 0)
                throw new Exception("Invalid Product");

            _addProductsService.AddProduct(product.SpotifyId, product.Genre, product.Price);
        }

        //          5001/products/
        [HttpGet("{id}")]
        public ProductModel GetProductById(string id)
        {
            if (id == null)
                throw new Exception("id is null");

            var product = _productsService.GetProductById(id);

            return new ProductModel
            {
                Id = product.Id,
                QuantityAvailable = product.QuantityAvailable,
                Price = product.Price,
                DateAdded = product.DateAdded,
                Album = product.Album
            };
        }

        //          5001/products/random   
        [HttpGet("random")]
        public List<ProductModel> GetProducts()
        {
            var count = 5;

            var products = _productsService.GetAvailableProducts(count);

            var productModels = TransformProductsToModels(products);

            return productModels;
        }

        //          5001/products/random/5   
        [HttpGet("random/{count:int}")]
        public List<ProductModel> GetProductsByCount(int count)
        {
            var products = _productsService.GetAvailableProducts(count);

            var productModels = TransformProductsToModels(products);

            return productModels;
        }

        //          5001/products/genre/hiphop   
        [HttpGet("genre/{genre}")]
        public List<ProductModel> GetProductsByGenre(string genre)
        {
            if (genre == null)
                throw new Exception("No Genre Specified");

            var defaultCount = 5;

            var products = _productsService.GetAvailableProductsByGenre(defaultCount, genre);

            var productModels = TransformProductsToModels(products);

            return productModels;
        }

        //          5001/products/genre/hiphop/5   
        [HttpGet("genre/{genre}/{count:int}")]
        public List<ProductModel> GetProductsByGenreByCount(string genre, int count)
        {
            if (genre == null)
                throw new Exception("No Genre Specified");

            var products = _productsService.GetAvailableProductsByGenre(count, genre);

            var productModels = TransformProductsToModels(products);

            return productModels;
        }

        private List<ProductModel> TransformProductsToModels(IEnumerable<Product> products)
        {
            var productModels = products.Select(product =>
                new ProductModel
                {
                    Id = product.Id,
                    Album = product.Album,
                    Price = product.Price,
                    QuantityAvailable = product.QuantityAvailable,
                    DateAdded = product.DateAdded
                });

            return productModels.ToList();
        }
    }
}