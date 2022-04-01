namespace MediatingCaches.Memory.Operations.Commands;

public record DeleteFromMemoryCache(string Key) : ICacheRequest;