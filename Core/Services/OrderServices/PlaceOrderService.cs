using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Services.OrderServices
{
    public interface IPlaceOrderService
    {
        Order PlaceOrder(List<Product> albums);
    }

    public class PlaceOrderService : IPlaceOrderService
    {
        // TODO should return void
        public Order PlaceOrder(List<Product> products)
        {
            // TODO var user = [get user from database]
            // user.WalletBalance -= order.TransactionPrice
            var order = new Order
            {
                Products = products,
                PurchaseDate = DateTime.Now,
                ShippingDate = DateTime.Now.AddDays(2),
            };

            return order;
        }
    }
}