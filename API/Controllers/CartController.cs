using System.Collections.Generic;
using System.IO;
using API.Models;
using Core.Entities;
using Core.Services.CartServices;
using Microsoft.AspNetCore.Mvc;
using CartItem = Core.Entities.CartItem;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly string _path;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
            _path = Path.GetFullPath(ToString()!);
        }

        // [Authorize]
        [HttpPost]
        public void AddToCart([FromBody] List<CartItemInputModel> cartItems, string userId)
        {
            var cart = new List<CartItem>();
            
            cartItems.ForEach(album =>
                cart.Add(new CartItem
                {
                    Quantity = album.Quantity,
                    PurchasePrice = album.Price,
                    SpotifyId = album.SpotifyId,
                    UserId = userId
                }));
                
            _cartService.AddToCart(cart, userId);
        }

        // [Authorize]
        [HttpPatch("{orderNumber}")]
        public void RemoveFromCart(string orderNumber, [FromBody] List<CartItemInputModel> orders)
        {
            // TODO do we need this endpoint?
        }
    }
}