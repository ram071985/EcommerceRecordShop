using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using API.Models;
using Core.Entities;
using Core.Services.OrderServices;
using Core.Services.SpotifyServices;
using Core.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class OrderController : Controller
    {
        private readonly IPlaceOrderService _orderService;
        private readonly ISpotifyAlbumService _albumService;
        private readonly string _path;

        public OrderController(
            IPlaceOrderService orderService,
            ISpotifyAlbumService albumService
        )
        {
            _orderService = orderService;
            _albumService = albumService;
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
        public Order PlaceOrder([FromBody] PurchaseInputModel purchaseInputModel)
        {
            Console.WriteLine(purchaseInputModel.UserId);
            Console.WriteLine(purchaseInputModel.Albums[0].Quantity);
            var purchasedAlbums = new List<PurchaseAlbum>();
            purchaseInputModel.Albums.ForEach(album =>
            {
                purchasedAlbums.Add(new PurchaseAlbum
                {
                    Quantity = album.Quantity,
                    PurchasePrice = album.Price,
                    SpotifyId = album.SpotifyId,
                    UserId = purchaseInputModel.UserId
                });
            });
            return _orderService.PlaceOrder(purchasedAlbums, purchaseInputModel.UserId);
        }

        // [Authorize]
        [HttpPatch("{orderNumber}")]
        public void ChangeOrder(string orderNumber, [FromBody] List<AlbumPurchaseInputModel> orders)
        {
            // TODO do we need this endpoint?
        }
    }
}