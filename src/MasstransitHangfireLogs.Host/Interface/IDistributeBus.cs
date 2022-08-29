namespace MasstransitHangfireLogs.Host.Interface;

public interface IDistributeBus
{
    Task PublishAsync<T>(object message, CancellationToken cancellationToken = default) where T : class;
}