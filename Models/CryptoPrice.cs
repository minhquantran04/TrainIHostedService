namespace CryptoPriceTracker.API.Models
{
    public class CryptoPrice
    {
        public string Symbol { get; set; } = "";
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
