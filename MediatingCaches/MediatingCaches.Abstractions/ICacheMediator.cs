
namespace MediatingCaches;

public interface ICacheMediator
{
    Task Send<T>(ICacheRequest<T> request, CancellationToken token = default);
    
    Task Publish<TNotification>(TNotification notification, CancellationToken token = default) where TNotification : ICacheNotification;
}