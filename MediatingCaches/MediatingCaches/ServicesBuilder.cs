using System.Reflection;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace MediatingCaches;

internal class ServicesBuilder : IMediatingCachesServicesBuilder
{
    private readonly ServiceCollection _innerServices;
    private readonly HashSet<Type> _extractTypesFrom = new();
    private Action<MediatRServiceConfiguration> _configureMediator = _ => { };

    public IServiceCollection Services => _innerServices;

    public ServicesBuilder(ServiceCollection innerServices) 
        => _innerServices = innerServices;

    public ICacheMediator Build(IServiceProvider outerServiceProvider)
    {
        var assemblies = _extractTypesFrom.Select(x => x.GetTypeInfo().Assembly).ToArray();
        _innerServices.AddMediatR(_configureMediator, assemblies);
        _innerServices.AddFluentValidation(assemblies);
        var innerServiceProvider = _innerServices.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true
        });
        return new CacheMediator(innerServiceProvider, outerServiceProvider);
    }


    public IMediatingCachesServicesBuilder AddHandlersFrom(params Type[] types)
    {
        _extractTypesFrom.UnionWith(types);
        return this;
    }

    public IMediatingCachesServicesBuilder ConfigureMediator(Action<MediatRServiceConfiguration> configure)
    {
        _configureMediator = configure;
        return this;
    }
}