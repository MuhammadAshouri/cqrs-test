using Telegram.Bot;

namespace TestApi.Reporter.Helpers;

public class BotHelper : IBotHelper
{
    private readonly ITelegramBotClient Client;

    public BotHelper(ITelegramBotClient client) => Client = client;

    public async Task SendMessage(string message) => await Client.SendTextMessageAsync(Consts.AdminId, $"Time: {DateTime.UtcNow}" + message);
}
