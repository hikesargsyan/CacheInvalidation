using CacheInvalidation.Interfaces;
using MediatR;

namespace CacheInvalidation.Behaviors;

public class CacheInvalidatingBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheInvalidatorRequest<TResponse>

{
    private readonly ICacheService _cacheService;

    public CacheInvalidatingBehavior(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        foreach (var key in request.CacheInvalidationKeys)
        {
            await _cacheService.RemoveAsync(key, cancellationToken);
        }

        return await next();
    }
}

