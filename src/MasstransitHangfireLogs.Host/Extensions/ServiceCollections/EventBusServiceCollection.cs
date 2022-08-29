using MassTransit;
using MassTransit.Definition;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MasstransitHangfireLogs.Host.Configurations;
using MasstransitHangfireLogs.Host.Consumer;
using MasstransitHangfireLogs.Host.EventBus;
using MasstransitHangfireLogs.Host.Interface;

namespace Microsoft.Extensions.DependencyInjection;

public static class EventBusServiceCollection
{
    public static IServiceCollection AddDistributedBus(this IServiceCollection services, IConfiguration configuration)
    {
        var eventBusConfiguration = configuration.GetSection(RabbitMqConfiguration.RabbitMQ).Get<RabbitMqConfiguration>();

        services.AddScoped<IDistributeBus, DistributeBus>();

        services.AddMassTransit(s =>
        {
            s.AddConsumer<TestConsumer>();
            s.AddRabbitMq(eventBusConfiguration);
        });

        var formatter = new KebabCaseEndpointNameFormatter(eventBusConfiguration.Prefix, false);
        services.AddSingleton<IEndpointNameFormatter>(formatter);
        services.AddMassTransitHostedService();
        return services;
    }

    private static void AddRabbitMq(this IServiceCollectionBusConfigurator services, RabbitMqConfiguration configuration)
    {
        services.UsingRabbitMq((context, cfg) =>
        {
            //cfg.UsePublishFilter(typeof(IntegrationEventPublishFilter<>), context);

            cfg.Host(configuration.Host, configure =>
            {
                configure.Username(configuration.Username);
                configure.Password(configuration.Password);
            });

            cfg.ConfigureEndpoints(context);
        });
    }
}