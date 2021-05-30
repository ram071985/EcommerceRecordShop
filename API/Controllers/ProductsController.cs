using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using Core.Entities;
using Core.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("[controller]")]
    public sealed class ProductsController : Controller
    {
        private readonly string[] _validGenres = {"hiphop", "rock", "punk"};
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        //          5001/products/{customerId}
        [HttpGet("{productId}")]
        public ProductModel GetProductById(string customerId)
        {
            if (customerId == null)
                throw new Exception("id is null");

            var product = _productsService.GetProductById(customerId);

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
        // [Authorize]
        [HttpGet("random")]
        public List<ProductModel> GetProducts()
        {
            var defaultCount = 5;

            var products = _productsService.GetAvailableProducts(defaultCount);

            return MapProductModels(products);
        }

        //          5001/products/random/5   
        // [Authorize]
        [HttpGet("random/{count:int}")]
        public List<ProductModel> GetProductsByCount(int count)
        {
            var products = _productsService.GetAvailableProducts(count);

            return MapProductModels(products);
        }

        //          5001/products/genre/hiphop   
        // [Authorize]
        [HttpGet("genre/{genre}")]
        public List<ProductModel> GetProductsByGenre(string genre)
        {
            if (genre == null || !_validGenres.Contains(genre))
                throw new Exception("Genre either null or invalid");

            var defaultCount = 5;

            var products = _productsService.GetAvailableProductsByGenre(defaultCount, genre);

            return MapProductModels(products);
        }

        //          5001/products/genre/hiphop/5   
        // [Authorize]
        [HttpGet("genre/{genre}/{count:int}")]
        public List<ProductModel> GetProductsByGenreAndCount(string genre, int count)
        {
            if (genre == null || !_validGenres.Contains(genre))
                throw new Exception("Genre either null or invalid");

            var products = _productsService.GetAvailableProductsByGenre(count, genre);

            return MapProductModels(products);
        }

        private List<ProductModel> MapProductModels(IEnumerable<Product> products)
        {
            return products.Select(product => new ProductModel
            {
                Id = product.Id,
                Album = product.Album,
                Price = product.Price,
                QuantityAvailable = product.QuantityAvailable,
                DateAdded = product.DateAdded,
                Genre = product.Genre
            }).ToList();
        }
    }
}
