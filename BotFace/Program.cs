// See https://aka.ms/new-console-template for more information

using Bot;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;




var stream = File.AppendText("D:\\history.ds");

var fileTokenProvider = new FileTokenProvider();
var logger = new Logger<ClientSocketWrapper>(new LoggerFactory());

var clientWrapper = new ClientSocketWrapper(logger, fileTokenProvider);
var botService = new DefaultDiscordBotService(stream,clientWrapper);

var client = botService.ClientWrapper;

await client.LoginAsync(TokenType.Bot, client.TokenProvider.ProvideToken());
await client.StartAsync();
await Task.Delay(2000);


botService.SetTargetGuild(305010151587315724);
botService.SetTargetChannel(476894584950226945);
botService.CollectData();
await Task.Delay(-1);
