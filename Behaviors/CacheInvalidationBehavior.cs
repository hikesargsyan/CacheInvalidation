using MediatR;

namespace CacheInvalidation.Behaviors
{
    public class CacheInvalidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
        )
        {
            return await next();
        }
    }
}
