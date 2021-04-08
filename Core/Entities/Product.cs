namespace Core.Entities
{
    public class Product
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SpotifyId { get; set; }
        public Album Album { get; set; }
    }
}