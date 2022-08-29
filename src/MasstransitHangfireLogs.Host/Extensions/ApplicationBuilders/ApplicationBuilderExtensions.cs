using Serilog;

namespace Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseApplicationBuilder(this IApplicationBuilder app)
    {
        app
            .UseHttpsRedirection()
            .UseSerilogRequestLogging()
            .UseRouting()
            .UseAuthorization()
            .UseHangFire()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

        return app;
    }
}