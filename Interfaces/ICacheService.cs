namespace CacheInvalidation.Interfaces;
public interface ICacheService
{
    public Task<T> GetAsync<T>(string key, CancellationToken ct = default) where T : class;
    public Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> setFactory, CancellationToken ct = default) where T : class;
    public Task SetAsync<T>(string key, T value, CancellationToken ct = default) where T : class;
    public Task RemoveAsync(string key, CancellationToken ct = default);
}
