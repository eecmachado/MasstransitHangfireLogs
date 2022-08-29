using Hangfire;
using MasstransitHangfireLogs.Host.Interface;

namespace MasstransitHangfireLogs.Host.Services;

public class AddOrUpdateService : IAddOrUpdateService
{
    private readonly ILog<AddOrUpdateService> _log;

    public AddOrUpdateService(ILog<AddOrUpdateService> log)
    {
        _log = log;
    }

    public Task Handle()
    {
        var list = Enumerable.Range(1, 3).Select(s => s);

        foreach (var item in list)
        {
            _log.Info($"Enqueuing {item}");
            _ = BackgroundJob.Enqueue<IEnqueueService>(i => i.Handle(item, CancellationToken.None));
            _log.Info($"Enqueued {item}");
        }

        return Task.CompletedTask;
    }
}