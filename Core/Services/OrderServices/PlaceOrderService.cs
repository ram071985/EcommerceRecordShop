using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Services.OrderServices
{
    public interface IPlaceOrderService
    {
        Order PlaceOrder(List<PurchasedAlbum> albums);
    }

    public class PlaceOrderService : IPlaceOrderService
    {
        // TODO should return void
        public Order PlaceOrder(List<PurchasedAlbum> albums)
        {
            var order = new Order
            {
                Albums = albums,
                UserId = albums[0].UserId,
                PurchaseDate = DateTime.Now,
                ShippingDate = DateTime.Now.AddDays(2),
            };

            return order;
        }
    }
}