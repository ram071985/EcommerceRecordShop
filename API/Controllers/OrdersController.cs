using System;
using System.Collections.Generic;
using System.IO;
using API.Models;
using Core.Entities;
using Core.Services.OrderServices;
using Core.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly IPlaceOrderService _orderService;
        private readonly string _path;

        public OrdersController(
            IPlaceOrderService orderService
        )
        {
            _orderService = orderService;
            _path = Path.GetFullPath(ToString()!);
        }

        [Authorize]
        [HttpGet("{username}")]
        public string GetOrdersByUsername(string username)
        {
            // TODO should return List<Order>()
            return username;
        }

        // [Authorize]
        [HttpPost]
        public void PlaceOrder(List<AlbumPurchaseInputModel> purchasedAlbums)
        {
            var albums = new List<PurchasedAlbum>();
            purchasedAlbums.ForEach(distinctAlbum =>
            {
                if (distinctAlbum.AlbumName == null ||
                    distinctAlbum.ArtistName == null ||
                    distinctAlbum.Quantity < 1 ||
                    distinctAlbum.PurchasePrice == 0 ||
                    distinctAlbum.UserId == 0)
                    throw new Exception("invalid album");
                
                for (var i = 1; i <= distinctAlbum.Quantity; i++)
                    albums.Add(new PurchasedAlbum
                    {
                        ArtistName = distinctAlbum.ArtistName,
                        AlbumName = distinctAlbum.AlbumName,
                        PurchasePrice = distinctAlbum.PurchasePrice,
                        UserId = distinctAlbum.UserId,
                    });
            });

            _orderService.PlaceOrder(albums);
        }

        // [Authorize]
        [HttpPatch("{orderNumber}")]
        public void ChangeOrder(string orderNumber, [FromBody] List<AlbumPurchaseInputModel> orders)
        {
            // TODO do we need this endpoint?
        }
    }
}