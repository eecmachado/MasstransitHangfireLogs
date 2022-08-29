using MasstransitHangfireLogs.Host.Hangfire.Attributes;

namespace MasstransitHangfireLogs.Host.Interface;

[Log]
public interface IEnqueueService
{
    [Log]
    Task Handle(int id, CancellationToken cancellationToken);
}