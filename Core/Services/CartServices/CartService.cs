using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities;
using Core.Services.ProductServices;
using Core.Services.SpotifyServices;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.CartServices
{
    public interface ICartService
    {
        void AddToCart(IEnumerable<CartItem> albums);
        void ClearCart(string customerId);
        List<CartItem> GetCartItemsByCustomerId(string customerId);
    }

    public class CartService : ICartService
    {
        private readonly RecordStoreContext _db;
        private readonly ISpotifyAlbumService _albumService;

        public CartService(
            RecordStoreContext db,
            ISpotifyAlbumService albumService)
        {
            _db = db;
            _albumService = albumService;
        }

        public List<CartItem> GetCartItemsByCustomerId(string customerId)
        {
            var cartItems = _db.CartItems.Where(x => x.CustomerId == customerId)
                .Include(x => x.Product);

            foreach (var item in cartItems)
                item.Album = _albumService.GetAlbumBySpotifyId(item.Product.SpotifyId);
                
            return cartItems.ToList();
        }

        public void AddToCart(IEnumerable<CartItem> cartItems)
        {
            _db.AddRange(cartItems);
            _db.SaveChanges();
        }

        public void ClearCart(string customerId)
        {
            var cartItems = _db.CartItems.Where(x => x.CustomerId == customerId);
            _db.CartItems.RemoveRange(cartItems);
            _db.SaveChanges();
        }
    }
}