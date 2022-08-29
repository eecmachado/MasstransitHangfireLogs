using MasstransitHangfireLogs.Host.DomainEvent.Interfaces;
using MasstransitHangfireLogs.Host.Interface;

namespace MasstransitHangfireLogs.Host.Services;

public class EnqueueService : IEnqueueService
{
    private readonly ILog<EnqueueService> _logger;
    private readonly IDistributeBus _distributeBus;

    public EnqueueService(ILog<EnqueueService> logger, IDistributeBus distributeBus)
    {
        _logger = logger;
        _distributeBus = distributeBus;
    }

    public async Task Handle(int id, CancellationToken cancellationToken)
    {
        _logger.Info($"Handling : {id}");

        await _distributeBus.PublishAsync<ITest>(new
        {
            Id = id,
            Items = new[]
            {
                new { Id = new Random().Next() },
                new { Id = new Random().Next() },
                new { Id = new Random().Next() },
            }
        });
        _logger.Info($"Handled : {id}");
    }
}