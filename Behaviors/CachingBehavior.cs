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
        //TODO edit request.ToString() part to take request params as well

        return await _cacheService.GetOrSetAsync(typeof(TRequest).Name.ToString(), async () =>
        {
            return await next();
        }, cancellationToken);
    }
}

