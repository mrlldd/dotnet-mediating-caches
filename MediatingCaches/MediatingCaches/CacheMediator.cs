using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MediatingCaches;

public class CacheMediator : ICacheMediator
{
    private readonly IServiceProvider _innerServiceProvider;
    private readonly IServiceProvider _outerServiceProvider;
    private readonly IMediator _mediator;

    public CacheMediator(IServiceProvider innerServiceProvider, IServiceProvider outerServiceProvider)
    {
        _innerServiceProvider = innerServiceProvider;
        _outerServiceProvider = outerServiceProvider;
        _mediator = innerServiceProvider.GetRequiredService<IMediator>();
    }

    public Task Send<T>(ICacheRequest<T> request, CancellationToken token = default)
        => _mediator.Send(request, token);

    public Task Publish<TNotification>(TNotification notification, CancellationToken token = default) where TNotification : ICacheNotification 
        => _mediator.Publish(notification, token);
}