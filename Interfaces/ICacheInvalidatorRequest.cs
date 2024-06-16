using MediatR;

namespace CacheInvalidation.Interfaces
{
    public interface ICacheInvalidatorRequest<out TResponse> : IRequest<TResponse>
    {
        public Guid Id { get; }
        public IList<string> CacheInvalidationKeys { get; }
    }
}
