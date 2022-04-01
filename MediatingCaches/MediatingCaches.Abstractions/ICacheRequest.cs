using MediatR;

namespace MediatingCaches;

public interface ICacheRequest<out T> : IRequest<T>
{
    
}

public interface ICacheRequest : ICacheRequest<Unit>
{
    
}