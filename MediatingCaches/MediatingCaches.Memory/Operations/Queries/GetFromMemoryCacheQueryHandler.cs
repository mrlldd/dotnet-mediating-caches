using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace MediatingCaches.Memory.Operations.Queries;

internal class GetFromMemoryCacheQueryHandler<T> : IRequestHandler<GetFromMemoryCache<T>, T>
{
    private readonly IMemoryCache _memoryCache;

    public GetFromMemoryCacheQueryHandler(IMemoryCache memoryCache)
        => _memoryCache = memoryCache;

    public Task<T> Handle(GetFromMemoryCache<T> request, CancellationToken cancellationToken) 
        => Task.FromResult(_memoryCache.Get<T>(request.Key));
}