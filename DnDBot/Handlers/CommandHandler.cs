﻿using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBot.Handlers;

public class CommandHandler
{
    private readonly DiscordSocketClient client;
    private readonly CommandService commands;
    
    public CommandHandler(DiscordSocketClient client, CommandService commands)
    {
        this.commands = commands;
        this.client = client;
    }
    
    public async Task InstallCommandsAsync()
    {
        client.MessageReceived += HandleCommandAsync;
        
        await commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), 
                                        services: null);
    }

    private async Task HandleCommandAsync(SocketMessage messageParam)
    {
        var message = messageParam as SocketUserMessage;
        
        if (message == null) return;
        
        int argPos = 0;
        
        if (!(message.HasCharPrefix('!', ref argPos) || 
            message.HasMentionPrefix(client.CurrentUser, ref argPos)) ||
            message.Author.IsBot)
            return;
        
        var context = new SocketCommandContext(client, message);
        
        await commands.ExecuteAsync(
            context: context, 
            argPos: argPos,
            services: null);
    }
}
