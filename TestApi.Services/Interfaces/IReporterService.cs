namespace TestApi.Services.Interfaces;

public interface IReporterService
{
    void SendMessage(int status, string message, Exception exc);
}
