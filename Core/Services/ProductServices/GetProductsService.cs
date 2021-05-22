using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities;
using Integrations.Spotify.Services;

namespace Core.Services.ProductServices
{
    public interface IGetProductsService
    {
        Product GetProductById(string id);
        List<Product> GetAvailableProducts(int count);
        List<Product> GetAvailableProductsByGenre(int count, string genre);
    }

    public class GetProductsService : IGetProductsService
    {
        private readonly RecordStoreContext _db;
        private readonly ISpotifyAlbumService _albumService;
        private readonly Random random = new Random();

        public GetProductsService(RecordStoreContext db, ISpotifyAlbumService albumService)
        {
            _db = db;
            _albumService = albumService;
        }

        public Product GetProductById(string id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
                throw new Exception("no product with specified Id");

            var albums = _albumService.GetAlbumsBySpotifyIds(new []{product.SpotifyId});
            
            if (albums.Count == 0) return null;
            
            product.Album = albums[0];
            
            return product;
        }

        public List<Product> GetAvailableProducts(int count)
        {
            var allProducts = _db.Products
                .ToList();

            return PopulateAlbums(allProducts, count);
        }

        public List<Product> GetAvailableProductsByGenre(int count, string genre)
        {
            var allProductsByGenre = _db.Products
                .Where(x => x.Genre == genre)
                .ToList();

            return PopulateAlbums(allProductsByGenre, count);
        }

        private List<Product> PopulateAlbums(IReadOnlyList<Product> dbProducts, int count)
        {
            // TODO implement Random
            var products = new List<Product>();

            {
                if (count is > 5 or 0) count = 5;
                for (var i = 0; i < count; i++)
                    products.Add(dbProducts[i]);
            }

            var spotifyIds = products
                .Select(x => x.SpotifyId)
                .ToList();

            var albums = _albumService.GetAlbumsBySpotifyIds(spotifyIds);

            for (var i = 0; i < products.Count; i++)
                products[i].Album = albums[i];

            return products;
        }
    }
}