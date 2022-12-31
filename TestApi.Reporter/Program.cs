using Telegram.Bot;
using TestApi.Reporter.Helpers;

Start:
var botClient = new TelegramBotClient(Consts.Token);

Console.WriteLine($"{DateTime.Now} - Started on @{(await botClient.GetMeAsync()).Username}");
IBotHelper helper = new BotHelper(botClient);
using var rabbit = new RabbitService(helper);
rabbit.Receive();

Console.ReadLine();
Console.Clear();
rabbit.Dispose();
goto Start;
