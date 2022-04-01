
using Microsoft.Extensions.DependencyInjection;

namespace MediatingCaches;

public interface IMediatingCachesServicesBuilder 
{
    public IServiceCollection Services { get; }
    public IMediatingCachesServicesBuilder AddHandlersFrom(params Type[] types);
}