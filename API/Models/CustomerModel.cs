namespace API.Models
{
    public class CustomerModel
    {
        public string CustomerName { get; init; }
        public string Email { get; init; }
        public decimal WalletBalance { get; init; }
        public bool IsActive { get; set; }
    }
}