using CorrelationId.Abstractions;
using MassTransit;
using MasstransitHangfireLogs.Host.Interface;

namespace MasstransitHangfireLogs.Host.EventBus;

public class DistributeBus : IDistributeBus
{
    private readonly ICorrelationContextAccessor _contextAccessor;
    private readonly ILog<DistributeBus> _log;
    private readonly IPublishEndpoint _publishEndpoint;

    public DistributeBus(ILog<DistributeBus> log, IPublishEndpoint publishEndpoint, ICorrelationContextAccessor contextAccessor)
    {
        _log = log;
        _publishEndpoint = publishEndpoint;
        _contextAccessor = contextAccessor;
    }

    public async Task PublishAsync<T>(object message, CancellationToken cancellationToken = default)
        where T : class
    {
        _log.Info($"publishing: {message}");
        try
        {
            await _publishEndpoint.Publish<T>(new
                {
                    __CorrelationId = _contextAccessor.CorrelationContext.CorrelationId,
                    __RequestId = InVar.Id,
                    __Timestamp = InVar.Timestamp,
                    message
                },
                cancellationToken);
        }
        catch (Exception e)
        {
            _log.Error(e, "crashed");
            throw;
        }
        
        _log.Info($"published: {message}");
    }
}