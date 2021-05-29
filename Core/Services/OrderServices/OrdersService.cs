using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities;
using Core.Services.CartServices;
using Core.Services.CustomerServices;
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
        private readonly ICustomerService _customerService;
        private readonly RecordStoreContext _db;

        public OrdersService(
            ISpotifyAlbumService albumService,
            ICartService cartService,
            ICustomerService customerService,
            RecordStoreContext db)
        {
            _albumService = albumService;
            _cartService = cartService;
            _customerService = customerService;
            _db = db;
        }

        public Order PlaceOrder(string customerId)
        {
            if (!_customerService.CustomerIsActive(customerId))
                throw new Exception("customer is not active");
                
            var customer = _db.Customers
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
                throw new Exception("no customer found with that Id");

            if (customer.CartItems?.Count == 0 || customer.CartItems == null)
                throw new Exception("there are no items in the customer's cart");

            customer.CartItems
                .ForEach(cartItem => cartItem.Product = _db.Products
                    .FirstOrDefault(product => product.Id == cartItem.ProductId));

            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = customerId,
                PurchaseDate = DateTime.Now,
                ShippingDate = DateTime.Now.AddDays(3),
                CanReturnBy = DateTime.Now.AddDays(30),
                OrderItems = customer.CartItems.ConvertAll(cartItem =>
                    new OrderItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        Product = _db.Products
                            .FirstOrDefault(product => product.Id == cartItem.ProductId)
                    })
            };

            order.TotalOrderPrice = order.OrderItems
                .Sum(item => item.Product?.Price * item.Quantity) ?? 0;

            customer.WalletBalance -= order.TotalOrderPrice;

            var productsToUpdate = order.OrderItems.Select(x => x.Product).ToList();

            for (var i = 0; i < productsToUpdate.Count; i++)
                productsToUpdate[i].QuantityAvailable -= order.OrderItems[i].Quantity;

            _cartService.ClearCart(customerId);

            _db.Add(order);
            _db.AddRange(order.OrderItems);
            _db.Update(customer);
            _db.UpdateRange(productsToUpdate);

            PopulateAlbums(new List<Order> {order});

            return order;
        }

        public List<Order> GetOrdersByCustomerId(string customerId)
        {
            if (!_customerService.CustomerIsActive(customerId))
                throw new Exception("customer is not active");
                
            var dbOrders = _db.Orders
                .Where(order => order.CustomerId == customerId)
                .Include(order => order.OrderItems)
                .ToList();

            var orders = PopulateAlbums(dbOrders);

            orders.ForEach(order =>
                order.TotalOrderPrice = order.OrderItems
                    .Sum(item => item.Product.Price * item.Quantity));

            return orders;
        }

        private List<Order> PopulateAlbums(List<Order> orders)
        {
            foreach (var order in orders)
            {
                order.OrderItems.ForEach(item =>
                    item.Product = _db.Products
                        .FirstOrDefault(product => product.Id == item.ProductId));

                var spotifyIds = order.OrderItems
                    .Select(item => item.Product.SpotifyId)
                    .ToList();

                var albums = _albumService.GetAlbumsBySpotifyIds(spotifyIds);

                for (var i = 0; i < order.OrderItems.Count; i++)
                    order.OrderItems[i].Product.Album = albums[i];
            }

            return orders;
        }
    }
}