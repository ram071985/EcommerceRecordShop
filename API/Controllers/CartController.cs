using System;
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

        [HttpGet("{customerId}")]
        public List<CartItem> GetCartItemsByCustomerId(string customerId)
        {
            return _cartService.GetCartItemsByCustomerId(customerId);
        }

        // [Authorize]
        [HttpPost("{customerId}")]
        public void AddToCart(List<CartItemInputModel> cartItemsInput, string customerId)
        {
            if (customerId == null || cartItemsInput.Count == 0)
                throw new Exception(
                    "invalid AddToCart input... check customerId and make sure there is at least 1 cartItem");
                    
            var cartItems = MapCartInputsToItems(cartItemsInput, customerId);
                
            _cartService.AddToCart(cartItems);
        }

        // [Authorize]
        [HttpDelete("{customerId}")]
        public void ClearCart(string customerId)
        {
            if (customerId == null)
                throw new Exception("customerId is null");
                
            _cartService.ClearCart(customerId);
        }
        
        // [Authorize]
        [HttpPatch("{orderNumber}")]
        public void RemoveFromCart(string orderNumber, List<CartItemInputModel> orders)
        {
            // TODO do we need this endpoint?
        }

        private List<CartItem> MapCartInputsToItems(List<CartItemInputModel> cartItemsInput, string customerId)
        {
            var cartItems = new List<CartItem>();
            
            cartItemsInput.ForEach(cartItem =>
                cartItems.Add(new CartItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Quantity = cartItem.Quantity,
                    ProductId = cartItem.ProductId,
                    CustomerId = customerId
                }));
                
            return cartItems;
        }
    }
}