using Discord;
using Discord.WebSocket;
using DiscordBot.Handlers;

namespace DnDBot
{
    public class DiscordBotService : IHostedService
    {
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

            // Inicjalizacja handlera komend
            await _commandHandler.InstallCommandsAsync();

            // Logowanie do Discorda
            var token = "YOUR_DISCORD_BOT_TOKEN"; // Zamień na poprawny token
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Wyłączanie bota Discord...");
            return _client.StopAsync();
        }

        private Task LogAsync(LogMessage logMessage)
        {
            _logger.LogInformation(logMessage.ToString());
            return Task.CompletedTask;
        }
    }
}