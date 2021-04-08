using System.Collections.Generic;
using Core.Entities;
using Core.Services.OrderServices;
using NUnit.Framework;

namespace RecordStore.Tests.Core.Services.OrderServices
{
    [TestFixture]
    public class PlaceOrderServiceTests
    {
        private PlaceOrderService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PlaceOrderService();
        }
        
        [Test]
        public void PlaceOrder_WhenCalled_CreatesCorrectOrderObject()
        {
            var targetUserId = 10;
            // var purchasedAlbums = new List<PurchasedAlbum>
            // {
            //     new PurchasedAlbum
            //     {
            //         AlbumName = "Ready to Die", ArtistName = "Notorious BIG", PurchasePrice = 13.78M, UserId = 10
            //     },
            //     new PurchasedAlbum
            //     {
            //         AlbumName = "Infamous", ArtistName = "Mobb Deep", PurchasePrice = 17.72M, UserId = 10
            //     },
            //     new PurchasedAlbum
            //     {
            //         AlbumName = "Capital Punishment", ArtistName = "Big Pun", PurchasePrice = 33.58M, UserId = 10
            //     },
            //     new PurchasedAlbum
            //     {
            //         AlbumName = "Hardcore", ArtistName = "Lil Kim", PurchasePrice = 23.58M, UserId = 10
            //     }
            // };
            //
            // var transactionPrice = 0M;
            // purchasedAlbums.ForEach(action: album => transactionPrice += album.PurchasePrice);
            // var order = _sut.PlaceOrder(purchasedAlbums);
            //
            // Assert.That(order.TransactionPrice, Is.EqualTo(transactionPrice));
            // Assert.That(order.Albums.Count, Is.EqualTo(4));
            // Assert.That(order.UserId, Is.EqualTo(targetUserId));
        }
    }
}