using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities;
using Core.Services.CartServices;
using Core.Services.CustomerServices;
using Core.Services.SpotifyServices;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.OrderServices
{
    public interface IOrdersService
    {
        Order PlaceOrder(string customerId);
        List<Order> GetOrdersByCustomerId(string userId);
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
        
        // TODO return void
        public Order PlaceOrder(string customerId)
        {
            var customer = _db.Customers
                .Include(x => x.CartItems)
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.Id == customerId);

            if (customer == null)
                throw new Exception("no customer found with that Id");
                
            customer.CartItems
                .ForEach(item => item.Product = _db.Products
                .FirstOrDefault(x => x.Id == item.ProductId));
                
            var order = new Order
            {
                PurchaseDate = DateTime.Now,
                CustomerId = customerId,
                CartItems = customer.CartItems
            };
            
            customer.WalletBalance -= order.OrderTotalPrice;
            
            _cartService.ClearCart(customerId);
            
            _db.Add(order);
            _db.SaveChanges();
            
            return order;
        }
        
        public List<Order> GetOrdersByCustomerId(string userId)
        {
            // TODO get user from database by userid
            // return user.Orders
            return new List<Order>();
        }
    }
}