using System.Text;
using RabbitMQ.Client;
using TestApi.Services.Interfaces;

namespace TestApi.Services.Services;

public class ReporterService : IReporterService
{
    public void SendMessage(int status, string message, Exception exc)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.QueueDeclare(queue: "errors", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var body = Encoding.UTF8.GetBytes($"Error {status}:\n   - {message}\n   - {exc}");

        channel.BasicPublish(exchange: "", routingKey: "errors", basicProperties: null, body: body);
    }
}
