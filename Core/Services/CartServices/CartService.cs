using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Services.ProductServices;
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
        private readonly IGetProductsService _productsService;

        public CartService(ISpotifyAlbumService albumService,IGetProductsService productsService)
        {
            _albumService = albumService;
            _productsService = productsService;
        }

        public List<CartItem> GetCartItemsByUserId(string userId)
        {
            var cartItems = new List<CartItem>
            {
                new CartItem
                {
                    Quantity = 2,
                    UserId = userId,
                    Album = _albumService.GetAlbumBySpotifyId("5qkWpkGMULLVnSHb3Sej4X"),
                    Product = _productsService.GetProductById("1")
                },
                new CartItem
                {
                    Quantity = 1,
                    UserId = userId,
                    Album = _albumService.GetAlbumBySpotifyId("3ZpoX3ij0YBUeJoGfbVH0Q"),
                    Product = _productsService.GetProductById("1")
                }
            };
            
            return cartItems;
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