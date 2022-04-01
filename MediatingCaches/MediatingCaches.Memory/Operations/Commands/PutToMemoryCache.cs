using Microsoft.Extensions.Caching.Memory;

namespace MediatingCaches.Memory.Operations.Commands;

public record PutToMemoryCache<T>(string Key, T Value) : ICacheRequest
{
    public MemoryCacheEntryOptions? Options { get; init; }
}