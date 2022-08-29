namespace MasstransitHangfireLogs.Host.DomainEvent.Interfaces;

public interface ITest
{
    public int Id { get; set; }
    
    public ITestItems[] Items { get; set; }
}