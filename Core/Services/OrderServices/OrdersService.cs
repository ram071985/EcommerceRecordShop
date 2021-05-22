using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities;
using Core.Services.CartServices;
using Integrations.Spotify.Services;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.OrderServices
{
    public interface IOrdersService
    {
        Order PlaceOrder(string customerId);
        List<Order> GetOrdersByCustomerId(string customerId);
    }

    public class OrdersService : IOrdersService
    {
        private readonly ISpotifyAlbumService _albumService;
        private readonly ICartService _cartService;
        private readonly RecordStoreContext _db;

        public OrdersService(
            ISpotifyAlbumService albumService,
            ICartService cartService,
            RecordStoreContext db)
        {
            _albumService = albumService;
            _cartService = cartService;
            _db = db;
        }

        public Order PlaceOrder(string customerId)
        {
            var customer = _db.Customers
                .Include(x => x.CartItems)
                .FirstOrDefault(x => x.Id == customerId);

            if (customer == null)
                throw new Exception("no customer found with that Id");

            customer.CartItems
                .ForEach(cartItem => cartItem.Product = _db.Products
                    .FirstOrDefault(product => product.Id == cartItem.ProductId));

            var order = new Order
            {
                CustomerId = customerId,
                PurchaseDate = DateTime.Now,
                ShippingDate = DateTime.Now.AddDays(3),
                CanReturnBy = DateTime.Now.AddDays(30),
                OrderItems = customer.CartItems.ConvertAll(cartItem =>
                    new OrderItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        CustomerId = cartItem.CustomerId,
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                    })
            };

            customer.WalletBalance -= order.OrderTotalPrice;

            _cartService.ClearCart(customerId);

            _db.Add(order);
            _db.SaveChanges();

            return order;
        }

        public List<Order> GetOrdersByCustomerId(string customerId)
        {
            var orders = _db.Orders
                .Where(order => order.CustomerId == customerId)
                .Include(x => x.OrderItems)
                .ToList();

            // var albumIds = orders;

            return orders;
        }
    }
}