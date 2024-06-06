namespace CacheInvalidation.Interfaces;
public interface ICacheService 
{
    Task<T> GetAsync<T>(string key, CancellationToken ct = default) where T : class;
    Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> setFactory, CancellationToken ct = default) where T : class;
    Task SetAsync<T>(string key, T value, CancellationToken ct = default) where T : class;
    Task RemoveAsync(string key, CancellationToken ct = default);
}
