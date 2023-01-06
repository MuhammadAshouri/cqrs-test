using System.Text;
using RabbitMQ.Client;
using TestApi.Application.Interfaces;

namespace TestApi.Application.Services;

public class ReporterService : IReporterService
{
    private readonly IModel? Channel;

    public ReporterService()
    {
        try
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            Channel = connection.CreateModel();
            Channel.QueueDeclare("errors", false, false, false, null);
        }
        catch
        {
            Console.WriteLine("Error");
        }
    }

    public void SendMessage(int status, string message, Exception exc)
    {
        if (Channel is null) return;
        var body = Encoding.UTF8.GetBytes($"Error {status}:\n   - {message}\n   - {exc}");
        Channel.BasicPublish("", "errors", null, body);
    }
}