using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace CryptoPriceTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimerController : ControllerBase

    {
        // gọi một API để bắt đầu đếm thời gian
        [HttpGet("start")]
        public async Task<IActionResult> StartTimer()
        {
            // Gọi service Timer, không cần làm gì thêm vì BackgroundService sẽ chạy tự động
            return Ok("Timer started!");
        }
    }
}
