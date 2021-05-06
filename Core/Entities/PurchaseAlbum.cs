namespace Core.Entities
{
    public class PurchaseAlbum
    {
        public short Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public string SpotifyId { get; set; }
        public string UserId { get; set; }
    }
}