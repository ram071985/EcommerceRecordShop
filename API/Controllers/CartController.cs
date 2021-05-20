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
        public void AddToCart(List<CartItemInputModel> cartItemsInput, string userId)
        {
            var cartItems = TransformCartInputsToCartItems(cartItemsInput, userId);
                
            _cartService.AddToCart(cartItems, userId);
        }

        [HttpDelete("{userId}")]
        public void ClearCart(string userId)
        {
            _cartService.ClearCart(userId);
        }
        
        // [Authorize]
        [HttpPatch("{orderNumber}")]
        public void RemoveFromCart(string orderNumber, List<CartItemInputModel> orders)
        {
            // TODO do we need this endpoint?
        }

        private List<CartItem> TransformCartInputsToCartItems(List<CartItemInputModel> cartItemsInput, string userId)
        {
            var cartItems = new List<CartItem>();
            
            cartItemsInput.ForEach(cartItem =>
                cartItems.Add(new CartItem
                {
                    Quantity = cartItem.Quantity,
                    // should remove purchase price and spotifyId from cartItem class => replaced with ProductId
                    ProductId = cartItem.ProductId,
                    CustomerId = userId
                }));
                
            return cartItems;
        }
    }
}