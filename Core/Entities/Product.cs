namespace Core.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name => Album.Name;
        public decimal Price { get; set; }
        public string SpotifyId { get; set; }
        public Album Album { get; set; }
    }
}