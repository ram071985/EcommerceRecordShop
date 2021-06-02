using System;
using System.Linq;
using API.Models;
using Core.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("[controller]")]
    public sealed class AdminController : Controller
    {
        private readonly IAdminProductsService _adminProductsService;
        private readonly IAdminProductSeedService _seedService;
        private readonly string[] _validGenres = {"hiphop", "rock", "punk"};

        public AdminController(
            IAdminProductsService adminProductsService,
            IAdminProductSeedService seedService)
        {
            _adminProductsService = adminProductsService;
            _seedService = seedService;
        }
        
        //          5001/admin/seed
        [HttpGet("seed")]
        public void AdminSeedProducts()
        {
            _seedService.SeedDatabase();
        }

        //          5001/admin/add
        [HttpPost("add")]
        public void AdminAddProducts(ProductInputModel product)
        {
            if (product.SpotifyId == null || product.Genre == null || product.Price == 0)
                throw new Exception("Invalid Product");
            
            if (!_validGenres.Contains(product.Genre))
                throw new Exception("Unsupported genre");
            
            _adminProductsService.AddProduct(product.SpotifyId, product.Genre, product.Price);
        }
    }
}
