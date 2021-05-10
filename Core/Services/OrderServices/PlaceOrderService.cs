using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Services.SpotifyServices;

namespace Core.Services.OrderServices
{
    public interface IPlaceOrderService
    {
        Order PlaceOrder(List<CartItem> albums, string userId);
    }

    public class PlaceOrderService : IPlaceOrderService
    {
        private readonly ISpotifyAlbumService _albumService;

        public PlaceOrderService(ISpotifyAlbumService albumService)
        {
            _albumService = albumService;
        }
        
        // TODO should return void
        public Order PlaceOrder(List<CartItem> purchasedAlbums, string userId)
        {
            var order = new Order
            {
                PurchaseDate = DateTime.Now,
                UserId = userId,
                PurchasedAlbums = purchasedAlbums
            };
            
            // TODO subtract order.TotalPrice from user.Balance
            return order;
        }
    }
}