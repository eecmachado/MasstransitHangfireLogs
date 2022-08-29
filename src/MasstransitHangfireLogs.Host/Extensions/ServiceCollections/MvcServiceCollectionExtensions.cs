using CorrelationId;
using CorrelationId.Abstractions;
using MasstransitHangfireLogs.Host.Interface;
using MasstransitHangfireLogs.Host.Logs;
using MasstransitHangfireLogs.Host.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Extensions.DependencyInjection;

public static class MvcServiceCollectionExtensions
{
    public static IServiceCollection AddMvcService(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddNewtonsoftJson(opt => opt.Configure());

        services
            .AddResponseCompression(opt =>
            {
                opt.Providers.Add<BrotliCompressionProvider>();
                opt.EnableForHttps = true;
            });

        services.AddScoped<ICorrelationContextAccessor>(d =>
        {
            var contextAccessor = new CorrelationContextAccessor();
            contextAccessor.CorrelationContext = new CorrelationContext(Guid.NewGuid().ToString(), "test");
            return contextAccessor;
        });

        services.AddScoped(typeof(ILog<>), typeof(Log<>));
        services.AddScoped<IAddOrUpdateService, AddOrUpdateService>();
        services.AddScoped<IEnqueueService, EnqueueService>();


        return services;
    }

    private static void Configure(this MvcNewtonsoftJsonOptions opt)
    {
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        opt.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
    }
}