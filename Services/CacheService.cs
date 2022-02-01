using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Nuremberg.Interfaces;

namespace Nuremberg.Services;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;
    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> Get<T>(string key)
    {
        var value = await _cache.GetStringAsync(key);

        if (value != null)
        {
            return JsonSerializer.Deserialize<T>(value);
        }

        return default;
    }

    public async Task<T> Set<T>(string key, T value)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60),
            SlidingExpiration = TimeSpan.FromMinutes(10)
        };

        await _cache.SetStringAsync(key, JsonSerializer.Serialize(value));

        return value;
    }
}