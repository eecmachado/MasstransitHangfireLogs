using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasstransitHangfireLogs.Host.Controllers;

[AllowAnonymous]
public class HomeController : ControllerBase
{
    public ActionResult Index() => new RedirectResult("~/hangfire-test");
}