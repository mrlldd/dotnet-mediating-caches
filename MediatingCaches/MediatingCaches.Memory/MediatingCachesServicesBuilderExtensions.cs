using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace MediatingCaches.Memory;

public static class MediatingCachesServicesBuilderExtensions
{
    public static IMediatingCachesServicesBuilder WithMemoryCache(this IMediatingCachesServicesBuilder builder)
        => WithMemoryCache(builder, _ => { });

    public static IMediatingCachesServicesBuilder WithMemoryCache(this IMediatingCachesServicesBuilder builder, Action<MemoryCacheOptions> configure)
    {
        builder.Services.AddMemoryCache(configure);
        builder.AddHandlersFrom(typeof(MediatingCachesServicesBuilderExtensions));
        return builder;
    }
}