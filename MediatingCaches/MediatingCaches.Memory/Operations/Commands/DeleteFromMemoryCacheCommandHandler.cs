using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace MediatingCaches.Memory.Operations.Commands;

internal class DeleteFromMemoryCacheCommandHandler : IRequestHandler<DeleteFromMemoryCache>
{
    private readonly IMemoryCache _memoryCache;

    public DeleteFromMemoryCacheCommandHandler(IMemoryCache memoryCache) 
        => _memoryCache = memoryCache;

    public Task<Unit> Handle(DeleteFromMemoryCache request, CancellationToken cancellationToken)
    {
        _memoryCache.Remove(request.Key);
        return Unit.Task;
    }
}