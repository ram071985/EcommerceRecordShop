using System;
using API.Models;
using Core.Entities;
using Core.Services.CartServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace API.Controllers
{
    [ApiController, Route("[controller]/{customerId}")]
    public sealed class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly string _path;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
            _path = Path.GetFullPath(ToString()!);
        }

        //      5001/cart/{customerId}
        // [Authorize]
        [HttpGet]
        public List<CartItem> GetCartItemsByCustomerId(string customerId)
        {
            return _cartService.GetCartItemsByCustomerId(customerId);
        }

        //      5001/cart/{customerId}
        // [Authorize]
        [HttpPost]
        public void AddToCart(List<CartItemInputModel> cartItemsInput, string customerId)
        {
            if (customerId == null || cartItemsInput.Count == 0)
                throw new Exception("invalid AddToCart => customerId or List of cartInputModel invalid");

            var cartItems = MapCartItems(cartItemsInput, customerId);

            _cartService.AddToCart(customerId, cartItems);
        }

        //      5001/cart/{customerId}
        // [Authorize]
        [HttpDelete]
        public void ClearCart(string customerId)
        {
            if (customerId == null)
                throw new Exception("customerId is null");

            _cartService.ClearCart(customerId);
        }

        //      5001/cart/{customerId}
        // [Authorize]
        [HttpPatch]
        public void RemoveFromCart(string customerId, List<CartRemoveInputModel> itemsToRemove)
        {
        }

        private static List<CartItem> MapCartItems(IEnumerable<CartItemInputModel> cartItemsInput, string customerId)
        {
            var cartItems = cartItemsInput
                .Select(inputModel => new CartItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Quantity = inputModel.Quantity,
                    ProductId = inputModel.ProductId,
                    CustomerId = customerId
                })
                .ToList();

            return cartItems;
        }
    }
}