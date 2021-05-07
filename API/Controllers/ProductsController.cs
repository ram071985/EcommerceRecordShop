using System.Collections.Generic;
using System.Linq;
using API.Models;
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

        public ProductsController(IGetProductsService productsService, ISpotifyAlbumService spotifyService)
        {
            _productsService = productsService;
            _spotifyService = spotifyService;
        }

        [HttpGet]
        public List<ProductModel> GetAlbums()
        {
            var products = _productsService.GetAvailableProducts();
            
            var productModels = new List<ProductModel>();
            
            products.ForEach(product =>
                productModels.Add(new ProductModel
                {
                    Album = _spotifyService.GetAlbumBySpotifyId(product.SpotifyId),
                    Price = product.Price
                })
            );
            
            return productModels;
        }
    }
}
