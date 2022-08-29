namespace MasstransitHangfireLogs.Host.Configurations;

public class CorrelationIdConfiguration
{
    public const string CorrelationId = "CorrelationId";

    public string RequestHeader { get; set; }

    public bool AddToLoggingScope { get; set; }

    public bool UpdateTraceIdentifier { get; set; }
}