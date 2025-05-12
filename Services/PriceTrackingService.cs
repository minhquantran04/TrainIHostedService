using Microsoft.Extensions.Hosting;
using CryptoPriceTracker.API.Models;
namespace CryptoPriceTracker.API.Services
{
    public class PriceTrackingService : BackgroundService

    {
        private readonly CryptoPriceService _priceService;
        //list coin to sale
        private readonly string[] _symbols = { "bitcoins", "dogecoin" };
        // Bộ nhớ tạm để lưu lịch sử giá coin
        private static List<CryptoPrice> _log = new();
        public PriceTrackingService(CryptoPriceService priceService)
        {
            _priceService = priceService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //loop for when stop
            while (!stoppingToken.IsCancellationRequested)
            {
                // Tạo danh sách các task (mỗi coin 1 task riêng - chạy song song)
                var tasks = _symbols.Select(async symbol =>
                {// Gọi API để lấy giá của từng coin
                    var price = await _priceService.GetPriceAsync(symbol);
                    if (price.HasValue)
                    {
                        var data = new CryptoPrice
                        {
                            Symbol = symbol,
                            Price = price.Value,
                            Timestamp = DateTime.Now

                        };

                        // Lưu lại vào danh sách log
                        _log.Add(data);
                        Console.WriteLine($"{data.Timestamp:HH:mm:ss} - {data.Symbol}: ${data.Price}");
                    }
                });
                // Đợi tất cả các task hoàn tất (gọi API cho các coin)
                await Task.WhenAll(tasks);

                // Chờ 1 phút trước khi chạy lại (có thể chỉnh trong tương lai bằng appsettings)
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }


        }
    }
}
