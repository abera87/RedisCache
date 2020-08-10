using System.Threading.Tasks;
using StackExchange.Redis;

namespace BackOffice.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer connectionMultiplexer;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            this.connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            var db = connectionMultiplexer.GetDatabase(); // there are multiple data base in redis cache, default is -1 and this isrepresenting  fierst database
            return await db.StringGetAsync(key);
        }


        public async Task SetCacheValueAsync(string key, string value)
        {
            var db = connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, value);
        }
    }
}