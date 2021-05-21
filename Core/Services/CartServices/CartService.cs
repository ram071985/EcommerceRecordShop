using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities;
using Core.Services.SpotifyServices;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.CartServices
{
    public interface ICartService
    {
        void AddToCart(string customerId, List<CartItem> newCartItems);
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
                .Include(x => x.Product).ToList();

            var albumIds = cartItems.Select(item => item.Product.SpotifyId);
            var albums = _albumService.GetAlbumsBySpotifyIds(albumIds);

            for (var i = 0; i < cartItems.Count; i++)
                cartItems[i].Album = albums[i];

            return cartItems;
        }

        public void AddToCart(string customerId, List<CartItem> newCartItems)
        {
            var currentCartItems = _db.CartItems
                .Where(x => x.CustomerId == customerId)
                .Include(x => x.Product)
                .ToList();

            var itemsToAdd = new List<CartItem>();
            var itemsToUpdate = new List<CartItem>();
            newCartItems.ForEach(newItem =>
            {
                if (currentCartItems.Any(current => current.ProductId == newItem.ProductId))
                {
                    var updatedItem = currentCartItems.Find(x => x.ProductId == newItem.ProductId);
                    if (updatedItem == null) return;
                    updatedItem.Quantity += newItem.Quantity;
                    itemsToUpdate.Add(updatedItem);
                }
                else
                    itemsToAdd.Add(newItem);
            });

            if (itemsToUpdate.Count > 0)
                _db.UpdateRange(itemsToUpdate);

            _db.AddRange(itemsToAdd);
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