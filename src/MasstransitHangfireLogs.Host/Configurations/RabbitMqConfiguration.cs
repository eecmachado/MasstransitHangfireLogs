namespace MasstransitHangfireLogs.Host.Configurations;

public class RabbitMqConfiguration
{
    public const string RabbitMQ = "RabbitMq";

    public string Prefix { get; set; }

    public string Host { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }
}