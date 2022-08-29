using MassTransit;
using MasstransitHangfireLogs.Host.DomainEvent.Interfaces;
using MasstransitHangfireLogs.Host.Interface;

namespace MasstransitHangfireLogs.Host.Consumer;

public class TestConsumer : IConsumer<ITest>
{
    private readonly ILog<TestConsumer> _log;

    public TestConsumer(ILog<TestConsumer> log)
    {
        _log = log;
    }
    
    public Task Consume(ConsumeContext<ITest> context)
    {
        _log.Info($"consuming: {context.Message.Id}");
        
        _log.Info($"consumed: {context.Message.Id}");
        
        return Task.CompletedTask;
    }
}