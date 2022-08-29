using Hangfire.Dashboard;

namespace MasstransitHangfireLogs.Host.Hangfire.Filters;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true;
    }
}