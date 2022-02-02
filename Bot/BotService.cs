using Discord;
using Discord.WebSocket;

namespace Bot;

public class DefaultDiscordBotService
{
	private SocketChannel _targetChannel;
	private SocketGuild _targetGuild;

	public ClientSocketWrapper ClientWrapper { get; }
	private StreamWriter _textWriter;

	public DefaultDiscordBotService(StreamWriter textWriter,ClientSocketWrapper wrapper)
	{
		_textWriter = textWriter;
		ClientWrapper = wrapper;
	}


	public void SetTargetChannel(ulong channelId)
	{
		_targetChannel = ClientWrapper.GetChannel(channelId);
		_textWriter.WriteLine("|------------------| " +
		                      $"Channel: {_targetGuild.TextChannels.FirstOrDefault(channel => channel.Id == _targetChannel.Id)?.Name }" +
		                      "|------------------|");

	}

	public void SetTargetGuild(ulong guildId)
	{
		_targetGuild = ClientWrapper.GetGuild(guildId);

		_textWriter.WriteLine($"-------------------------------| Guild:{_targetGuild.Name} |-----------------------------");
	}

	public async void CollectData()
	{
		if (_targetGuild == null)
		{
			throw new MissingFieldException("Set target guild to perform operation");
		}
		if (_targetChannel == null)
		{
			throw new MissingFieldException("Set target channel to perform operation");
		}


		var data = _targetGuild.TextChannels
			.FirstOrDefault(channel => channel.Id == _targetChannel.Id)
			?.GetMessagesAsync(limit:1000000000);

		if (data != null)
			await data.ForEachAsync(messages =>
			{
				foreach (var message in messages)
				{
					_textWriter.WriteLine($"{message.Author} : {message.ToString()} on {message.Timestamp}");
				}

			});

		_textWriter.Close();
	}
}
