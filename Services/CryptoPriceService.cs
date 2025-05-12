using System.Net.Http.Json;
namespace CryptoPriceTracker.API.Services
{
    public class CryptoPriceService
    {
        private readonly HttpClient _httpClient;

        // Constructor khởi tạo HttpClient để tái sử dụng trong các lần gọi API
        public CryptoPriceService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Gọi API từ CoinGecko để lấy giá USD của một đồng tiền mã hóa.
        /// </summary>
        /// <param name="symbol">Tên đồng coin theo định danh của CoinGecko, ví dụ: bitcoin, ethereum</param>
        /// <returns>Giá trị hiện tại (decimal) hoặc null nếu thất bại</returns>
        public async Task<decimal?> GetPriceAsync(string symbol)
        {
            try

            {
                {
                    // API đơn giản từ CoinGecko, trả về giá theo đơn vị USD
                    var url = $"https://api.coingecko.com/api/v3/simple/price?ids={symbol}&vs_currencies=usd";
                    // Gọi API và parse JSON về Dictionary<string, Dictionary<string, decimal>>
                    var response = await _httpClient.GetFromJsonAsync<Dictionary<string, Dictionary<string, decimal>>>(url);
                    if (response != null && response.ContainsKey(symbol))
                    {
                        return response[symbol]["usd"];//return to usd unit   
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
