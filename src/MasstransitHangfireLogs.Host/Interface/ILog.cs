namespace MasstransitHangfireLogs.Host.Interface;

public interface ILog<T>
{
    void Info(string? message);

    void Warning(string? message);

    void Error(Exception exception, string? message);
}