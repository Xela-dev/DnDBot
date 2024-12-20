using Discord;
using Discord.WebSocket;
using DiscordBot.Handlers;

namespace DnDBot.Services
{
    public class DiscordBotService : IHostedService
    {
        private string token = "";
        
        private readonly DiscordSocketClient _client;
        private readonly CommandHandler _commandHandler;
        private readonly ILogger<DiscordBotService> _logger;

        public DiscordBotService(DiscordSocketClient client, CommandHandler commandHandler, ILogger<DiscordBotService> logger)
        {
            _client = client;
            _commandHandler = commandHandler;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _client.Log += LogAsync;

            await _commandHandler.InstallCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Turn off boot...");
            return _client.StopAsync();
        }

        private Task LogAsync(LogMessage logMessage)
        {
            _logger.LogInformation(logMessage.ToString());
            return Task.CompletedTask;
        }
    }
}