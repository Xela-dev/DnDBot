using System.Text.Json;
using Discord.Commands;
using DnDBot.Service;

namespace DiscordBot.Modules;

public class DnDModule : ModuleBase<SocketCommandContext>
{
    private readonly DnDService service = new ();
    
    [Command("spell")]
    public async Task GetSpellByName(string name)
    {
        var json = await service.GetSpellByNameAsync(name);
        await sendFormattedJsonText(json);
    }
    
    [Command("background")]
    public async Task GetBackgroundByName(string name)
    {
        var json = await service.GetBackgroundByNameAsync(name);
        await sendFormattedJsonText(json);
    }
    
    [Command("race")]
    public async Task GetRaceByName(string name)
    {
        var json = await service.GetRaceByName(name);
        await sendFormattedJsonText(json);
    }
    
    [Command("class")]
    public async Task GetClassByName(string name)
    {
        var json = await service.GetClassByNameAsync(name);
        await sendFormattedJsonText(json);
    }
    
    

    private async Task sendFormattedJsonText(string json)
    {
        if (String.IsNullOrEmpty(json)) return;
        
        var jsonDocument = JsonDocument.Parse(json);
        string formattedJson = JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        
        await ReplyAsync("```json" +
                         $"\n{formattedJson}" +
                         "```");
    }
}