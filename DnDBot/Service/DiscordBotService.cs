using Discord;
using Discord.WebSocket;
using DiscordBot.Handlers;

namespace DnDBot.Services
{
    public class DiscordBotService : IHostedService
    {
        private string token;
        
        private readonly DiscordSocketClient client;
        private readonly CommandHandler commandHandler;
        private readonly ILogger<DiscordBotService> logger;

        public DiscordBotService(DiscordSocketClient client, CommandHandler commandHandler, ILogger<DiscordBotService> logger, IConfiguration configuration)
        {
            this.client = client;
            this.commandHandler = commandHandler;
            this.logger = logger;
            token = configuration["DiscordToken"];
            
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("The bot token was not configured correctly in appsettings.json");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            client.Log += LogAsync;

            await commandHandler.InstallCommandsAsync();
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Turn off boot...");
            return client.StopAsync();
        }

        private Task LogAsync(LogMessage logMessage)
        {
            logger.LogInformation(logMessage.ToString());
            return Task.CompletedTask;
        }
    }
}