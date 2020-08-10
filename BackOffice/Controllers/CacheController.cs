using System.Threading.Tasks;
using BackOffice.DBContext;
using BackOffice.Services;
using BackOffice.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CacheController : ControllerBase
    {
        private readonly ICacheService cacheService;
        public CacheController(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetCacheValue(string key)
        {
            var value = await cacheService.GetCacheValueAsync(key);
            return string.IsNullOrEmpty(value) ? (IActionResult)NotFound() : Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> SetCacheValue([FromBody] NewCacheEntryRequest request)
        {
            await cacheService.SetCacheValueAsync(request.Key, request.Value);
            return Ok();
        }
    }
}