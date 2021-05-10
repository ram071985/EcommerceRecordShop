using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Services.CartServices;
using Core.Services.SpotifyServices;

namespace Core.Services.OrderServices
{
    public interface IOrdersService
    {
        Order PlaceOrder(string userId);
        List<Order> GetOrdersByUserId(string userId);
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
        public Order PlaceOrder(string userId)
        {
            var cartItems = _cartService.GetCartItemsByUserId(userId);
            
            var order = new Order
            {
                PurchaseDate = DateTime.Now,
                UserId = userId,
                CartItems = cartItems
            };
            
            _cartService.ClearCart(userId);
            
            // TODO subtract order.TotalPrice from user.Balance
            return order;
        }
        
        public List<Order> GetOrdersByUserId(string userId)
        {
            // TODO get user from database by userid
            // return user.Orders
            return new List<Order>();
        }
    }
}