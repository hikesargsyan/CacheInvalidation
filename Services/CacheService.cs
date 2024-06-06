using Newtonsoft.Json;
using CacheInvalidation.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace CacheInvalidation.Services;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;

    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<T> GetAsync<T>(string key, CancellationToken ct = default) where T : class
    {
        string cachedValue = await _distributedCache.GetStringAsync(key, ct);

        if (cachedValue == null)
        {
            return null;
        }

        try
        {
            return JsonConvert.DeserializeObject<T>(cachedValue);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> setFactory, CancellationToken ct = default) where T : class
    {
        T cachedValue = await GetAsync<T>(key, ct);

        if (cachedValue != null)
        {
            return cachedValue;
        }

        cachedValue = await setFactory();
        await SetAsync(key, cachedValue, ct);

        return cachedValue;
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken ct = default) where T : class
    {
        string cachedValue = JsonConvert.SerializeObject(
            value, 
            Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
        );
        
        await _distributedCache.SetStringAsync(key, cachedValue, ct);
    }

    public async Task RemoveAsync(string key, CancellationToken ct = default)
    {
        await _distributedCache.RemoveAsync(key, ct);
    }
}