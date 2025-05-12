namespace CryptoPriceTracker.API.Services
{
    public class TimerService : BackgroundService
    {
        private int _counter = 0;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _counter++;
                Console.WriteLine($"Timer:{_counter}");
                await Task.Delay(1000);
            }
        }
    }
}
