using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Services.SpotifyServices;

namespace Core.Services.CartServices
{
    public interface ICartService
    {
        void AddToCart(List<Entities.CartItem> albums, string userId);
        void ClearCart(string userId);
        List<CartItem> GetCartItemsByUserId(string userId);
    }

    public class CartService : ICartService
    {
        private readonly ISpotifyAlbumService _albumService;

        public CartService(ISpotifyAlbumService albumService)
        {
            _albumService = albumService;
        }

        public List<CartItem> GetCartItemsByUserId(string userId)
        {
            return new List<CartItem>();
        }
        
        // TODO should return void
        public void AddToCart(List<CartItem> cartItems, string userId)
        {
            // Add items to cartTable
        }

        public void ClearCart(string userId)
        {
            // _dbService.ClearCart(userId)
        }
    }
}