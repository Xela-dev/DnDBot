using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.Handlers;
using DnDBot.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new DiscordSocketConfig
{
    GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
});

builder.Services.AddSingleton<DiscordSocketClient>();
builder.Services.AddSingleton<CommandService>();
builder.Services.AddSingleton<CommandHandler>();
builder.Services.AddHostedService<DiscordBotService>();

var app = builder.Build();

app.Run();