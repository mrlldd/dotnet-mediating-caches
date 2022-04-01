using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MediatingCaches.Tests;

public class ServicesBuilderTests
{
    [Fact]
    public void Builds()
    {
        var services = new ServiceCollection();
        services.AddMediatingCaches();
        var sp = services.BuildServiceProvider();
        var mediator = sp.GetService<ICacheMediator>();
        mediator.Should().NotBeNull();
    }
}