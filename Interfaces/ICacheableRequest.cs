using MediatR;

namespace CacheInvalidation.Interfaces;

public interface ICacheableRequest<out TResponse> : IRequest<TResponse>;

