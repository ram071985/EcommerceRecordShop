using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Services.CartServices;
using Core.Services.SpotifyServices;

namespace Core.Services.OrderServices
{
    public interface IOrdersService
    {
        Order PlaceOrder(string customerId);
        List<Order> GetOrdersByCustomerId(string userId);
    }

    public class OrdersService : IOrdersService
    {
        private readonly ISpotifyAlbumService _albumService;
        private readonly ICartService _cartService;

        public OrdersService(
            ISpotifyAlbumService albumService,
            ICartService cartService)
        {
            _albumService = albumService;
            _cartService = cartService;
        }
        
        // TODO return void
        public Order PlaceOrder(string customerId)
        {
            var cartItems = _cartService.GetCartItemsByCustomerId(customerId);
            
            var order = new Order
            {
                PurchaseDate = DateTime.Now,
                CustomerId = customerId,
                CartItems = cartItems
            };
            
            _cartService.ClearCart(customerId);
            
            // TODO subtract order.TotalPrice from user.Balance
            return order;
        }
        
        public List<Order> GetOrdersByCustomerId(string userId)
        {
            // TODO get user from database by userid
            // return user.Orders
            return new List<Order>();
        }
    }
}