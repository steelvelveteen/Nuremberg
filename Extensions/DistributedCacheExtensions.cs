
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Nuremberg;

public static class DistributedCacheExtensions
{
    public static async Task SetRecordAsync<T>(this IDistributedCache cache, string recordId, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null)
    {
        // This is the configuration value for this particular entry in the cache. We tell here i.e. how long this item will stay in the cache. This must be set although not technically required. You don't stuff to remain in cache forever
        var options = new DistributedCacheEntryOptions
        {
            // Will give us a default value. Redis will delete this entry after 60 seconds.
            AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
            // Sliding is based upon usage. If it doesn't get used within the unusedExpireTime span, it will be expired
            SlidingExpiration = unusedExpireTime
        };

        // Convert the data to json format
        var jsonData = JsonSerializer.Serialize(data);

        // SetStringAsync(string key, string value,distribCachedEntryOptions)
        await cache.SetStringAsync(recordId, jsonData, options);
    }

    public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
    {
        var jsonData = await cache.GetStringAsync(recordId);

        if (jsonData is null) return default(T);
        return JsonSerializer.Deserialize<T>(jsonData);
    }
}