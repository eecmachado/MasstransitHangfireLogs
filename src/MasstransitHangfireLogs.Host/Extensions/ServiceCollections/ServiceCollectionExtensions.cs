namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceCollections(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddMvcService()
            .AddCorrelationId(configuration)
            .AddHangFire(configuration)
            .AddDistributedBus(configuration);

        return services;
    }
}