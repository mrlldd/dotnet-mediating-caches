namespace MediatingCaches.Memory.Operations.Queries;

public record GetFromMemoryCache<T>(string Key) : ICacheRequest<T>;