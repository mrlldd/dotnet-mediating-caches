using MediatingCaches.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MediatingCaches;

public static class ServiceCollectionExtensions
{
    public static IMediatingCachesServicesBuilder AddMediatingCaches(this IServiceCollection services,
                                                                     params Type[] extractTypesFrom)
        => AddMediatingCaches(services, _ => { }, extractTypesFrom);

    public static IMediatingCachesServicesBuilder AddMediatingCaches(this IServiceCollection services,
                                                                     Action<MediatRServiceConfiguration> configure,
                                                                     params Type[] extractTypesFrom)
    {
        if (!extractTypesFrom.Any())
        {
            throw new MissingAssembliesException();
        }

        var builder = new ServicesBuilder(new ServiceCollection());
        services.AddSingleton(builder.Build);
        return builder
           .ConfigureMediator(configure)
           .AddHandlersFrom(extractTypesFrom);
    }
}