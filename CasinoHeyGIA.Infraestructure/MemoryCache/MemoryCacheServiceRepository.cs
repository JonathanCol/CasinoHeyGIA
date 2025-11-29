using CasinoHeyGIA.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CasinoHeyGIA.Infraestructure.Redis
{
    public class MemoryCacheServiceRepository(IMemoryCache _cache) : ICacheService
    {
        public void SetAsync(string key, string data, TimeSpan? expiration = null)
        {
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(30),
                Priority = CacheItemPriority.Normal,
                Size = 1 // Si configuraste SizeLimit
            };
            _cache.Set(key, data, cacheOptions);
        }
    }
}
    