using MediatR;

namespace CacheInvalidation.Interfaces
{
    public interface ICacheableRequest<out TResponse> : IRequest<TResponse>
    {
        public Guid Id { get; set; }
    }
}
