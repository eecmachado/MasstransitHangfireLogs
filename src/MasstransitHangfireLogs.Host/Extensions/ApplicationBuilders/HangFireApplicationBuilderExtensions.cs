using Hangfire;
using MasstransitHangfireLogs.Host.Hangfire.Filters;
using MasstransitHangfireLogs.Host.Interface;

namespace Microsoft.AspNetCore.Builder;

public static class HangFireApplicationBuilderExtensions
{
    public static IApplicationBuilder UseHangFire(this IApplicationBuilder app)
    {
        GlobalConfiguration.Configuration.UseSerilogLogProvider();

        app
            .UseHangfireDashboard("/hangfire-test", new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthorizationFilter() }
            })
            .ConfigureAddOrUpdate();

        return app;
    }

    private static IApplicationBuilder ConfigureAddOrUpdate(this IApplicationBuilder app)
    {
        RecurringJob.AddOrUpdate<IAddOrUpdateService>(task => task.Handle(), Cron.Daily(23), TimeZoneInfo.Local);

        return app;
    }
}