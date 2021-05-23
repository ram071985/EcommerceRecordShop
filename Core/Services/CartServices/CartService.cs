using Core.DataAccess;
using Core.Entities;
using Integrations.Spotify.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services.CartServices
{
    public interface ICartService
    {
        List<CartItem> GetCartItemsByCustomerId(string customerId);
        void AddToCart(string customerId, List<CartItem> newCartItems);
        void ClearCart(string customerId);
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
            var cartItems = _db.CartItems
                .Where(x => x.CustomerId == customerId)
                .Include(x => x.Product)
                .ToList();

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
                var itemToUpdate = currentCartItems
                    .Find(item => item.ProductId == newItem.ProductId);
                if (itemToUpdate == null)
                {
                    itemsToAdd.Add(newItem);
                    return;
                }

                itemToUpdate.Quantity += newItem.Quantity;
                itemsToUpdate.Add(itemToUpdate);
            });

            if (itemsToUpdate.Count > 0)
                _db.UpdateRange(itemsToUpdate);

            if (itemsToAdd.Count > 0)
                _db.AddRange(itemsToAdd);

            _db.SaveChanges();
        }

        public void ClearCart(string customerId)
        {
            var cartItems = _db.CartItems
                .Where(item => item.CustomerId == customerId);

            _db.CartItems.RemoveRange(cartItems);
            _db.SaveChanges();
        }
    }
}