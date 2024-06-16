using CacheInvalidation.Interfaces;
using MediatR;

namespace CacheInvalidation.Behaviors;

public class CachingBehavior<TRequest, TResponse> :
IPipelineBehavior<TRequest, TResponse>
where TRequest : ICacheableRequest<TResponse>
where TResponse : class

{
    private readonly ICacheService _cacheService;

    public CachingBehavior(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {

        return await _cacheService.GetOrSetAsync($"{typeof(TRequest).Name}.{request.Id}", async () =>
        {
            return await next();
        }, cancellationToken);
    }
}

