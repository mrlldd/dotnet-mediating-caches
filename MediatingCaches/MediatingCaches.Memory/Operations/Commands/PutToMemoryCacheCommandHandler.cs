using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace MediatingCaches.Memory.Operations.Commands;

internal class PutToMemoryCacheCommandHandler<T> : IRequestHandler<PutToMemoryCache<T>>
{
    private readonly IMemoryCache _memoryCache;

    public PutToMemoryCacheCommandHandler(IMemoryCache memoryCache) 
        => _memoryCache = memoryCache;

    public Task<Unit> Handle(PutToMemoryCache<T> request, CancellationToken cancellationToken)
    {
        _memoryCache.Set(request.Key, request.Value, request.Options);
        return Unit.Task;
    }
}