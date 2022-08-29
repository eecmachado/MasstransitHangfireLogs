using CorrelationId.DependencyInjection;
using MasstransitHangfireLogs.Host.Configurations;

namespace Microsoft.Extensions.DependencyInjection;

public static class CorrelationIdServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationId(this IServiceCollection services, IConfiguration configuration)
    {
        var correlationIdConfiguration = configuration.GetSection(CorrelationIdConfiguration.CorrelationId).Get<CorrelationIdConfiguration>();

        services.AddDefaultCorrelationId(opt =>
        {
            opt.RequestHeader = correlationIdConfiguration.RequestHeader;
            opt.AddToLoggingScope = correlationIdConfiguration.AddToLoggingScope;
            opt.UpdateTraceIdentifier = correlationIdConfiguration.UpdateTraceIdentifier;
        });

        return services;
    }
}