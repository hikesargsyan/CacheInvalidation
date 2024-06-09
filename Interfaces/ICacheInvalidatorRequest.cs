using MediatR;

namespace CacheInvalidation.Interfaces;

public interface ICacheInvalidatorRequest<out TResponse> : IRequest<TResponse>
{

    IList<string> CacheInvalidationKeys { get; }
}

