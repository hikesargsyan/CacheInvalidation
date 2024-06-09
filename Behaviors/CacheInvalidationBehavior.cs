using CacheInvalidation.Interfaces;
using MediatR;

namespace CacheInvalidation.Behaviors;

public class CacheInvalidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheInvalidatorRequest<TResponse>

{
    private readonly ICacheService _cacheService;

    public CacheInvalidationBehavior(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {

        await _cacheService.RemoveAsync(request.CacheInvalidationKeys.FirstOrDefault(), cancellationToken);
        return await next();
    }
}

