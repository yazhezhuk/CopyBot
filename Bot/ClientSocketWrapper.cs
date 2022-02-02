using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

namespace Bot;

public class ClientSocketWrapper : DiscordSocketClient
{
	public ITokenProvider TokenProvider { get; }

	public ClientSocketWrapper(ILogger<ClientSocketWrapper> logger,ITokenProvider tokenProvider)
	{
		Log += (msg) =>
		{
			logger.LogInformation(msg.Message);
			return Task.CompletedTask;
		};

		TokenProvider = tokenProvider;
	}
}
