using CacheInvalidation.Interfaces;
using MediatR;

namespace CacheInvalidation.Behaviors;

public class CacheInvalidationBehavior<TRequest, TResponse> : 
    IPipelineBehavior<TRequest, TResponse> where TResponse : ICacheableRequest

{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        //PRE
        //TODO get from cache and then call next if there is no saved cache or cache is invalid

        return await next();
    
    }
}

