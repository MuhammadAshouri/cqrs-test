using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TestApi.Reporter.Helpers;

public class RabbitService : IDisposable
{
    private readonly IModel Channel;
    private readonly IBotHelper Bot;

    public RabbitService(IBotHelper bot)
    {
        Bot = bot;
        var factory = new ConnectionFactory { HostName = "localhost" }; 
        var connection = factory.CreateConnection(); 
        Channel = connection.CreateModel();
        Channel.QueueDeclare("errors");
    }

    public void Receive()
    {
        var consumer = new EventingBasicConsumer(Channel);
        consumer.Received += async (_, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            await Bot.SendMessage(message);
        };
        Channel.BasicConsume(queue: "errors", autoAck: true, consumer: consumer);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Channel.Dispose();
    }
}
