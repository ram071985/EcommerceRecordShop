using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Services.SpotifyServices;

namespace Core.Services.OrderServices
{
    public interface IPlaceOrderService
    {
        Order PlaceOrder(List<PurchaseAlbum> albums, string userId);
    }

    public class PlaceOrderService : IPlaceOrderService
    {
        private readonly ISpotifyAlbumService _albumService;

        public PlaceOrderService(ISpotifyAlbumService albumService)
        {
            _albumService = albumService;
        }
        
        // TODO should return void
        public Order PlaceOrder(List<PurchaseAlbum> purchasedAlbums, string userId)
        {
            var products = new List<Product>();
            purchasedAlbums.ForEach(action: distinctAlbum =>
            {
                for (var i = 1; i <= distinctAlbum.Quantity; i++)
                    products.Add(new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        Price = distinctAlbum.PurchasePrice,
                        Album = _albumService.GetAlbumBySpotifyId(distinctAlbum.SpotifyId)
                    });
            });
            var order = new Order
            {
                PurchaseDate = DateTime.Now,
                UserId = userId,
                Products = products
            };
            
            // TODO subtract order.TotalPrice from user.Baslance
            return order;
        }
    }
}