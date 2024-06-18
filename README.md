# Cache Invalidation

Simple .NET 8 Minimal API cache invalidation solution based on [Mediatr](https://github.com/jbogard/MediatR) pipeline behaviors.
Only works with requests including item id which should be cached or cache invalidated based on request.

* [CachingBehavior](https://github.com/hikesargsyan/cache_invalidation/blob/main/Behaviors/CachingBehavior.cs) caches [ICacheableRequest](https://github.com/hikesargsyan/cache_invalidation/blob/main/Interfaces/ICacheableRequest.cs) requests by id.
* [CacheInvalidationBehavior](https://github.com/hikesargsyan/cache_invalidation/blob/main/Behaviors/CacheInvalidationBehavior.cs) invalidates cache using CacheInvalidationKeys specified in [ICacheInvalidatorRequest](https://github.com/hikesargsyan/cache_invalidation/blob/main/Interfaces/ICacheInvalidatorRequest.cs) request.

Example: [GetWeatherForecast](https://github.com/hikesargsyan/cache_invalidation/tree/main/WeatherForecast/Queries/GetWeatherForecast), [RefreshWeatherForecast](https://github.com/hikesargsyan/cache_invalidation/tree/main/WeatherForecast/Commands/RefreshWeatherForecast)
