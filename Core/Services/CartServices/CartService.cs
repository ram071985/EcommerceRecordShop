using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Services.SpotifyServices;

namespace Core.Services.CartServices
{
    public interface ICartService
    {
        void AddToCart(List<Entities.CartItem> albums, string userId);
    }

    public class CartService : ICartService
    {
        private readonly ISpotifyAlbumService _albumService;

        public CartService(ISpotifyAlbumService albumService)
        {
            _albumService = albumService;
        }

        // TODO should return void
        public void AddToCart(List<CartItem> cartItems, string userId)
        {
        }
    }
}