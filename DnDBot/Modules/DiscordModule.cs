using Discord.Commands;
using DnDBot.Service;
using Newtonsoft.Json;

namespace DnDBot.Modules;

public class DiscordModule : ModuleBase<SocketCommandContext>
{
    private readonly DnDService service = new ();
    
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
    
    [Command("spell")]
    public async Task GetSpellByName(string name)
    {
        var json = await service.GetSpellByNameAsync(name);
        await sendFormattedJsonText(json);
    }
    
    [Command("language")]
    public async Task GetLanguageByName(string name)
    {
        var json = await service.GetLanguagesByNameAsync(name);
        await sendFormattedJsonText(json);
    }
    
    [Command("resource")]
    public async Task GetResourcesByName(string name)
    {
        var json = await service.GetResourcesByPathAsync(name);
        await sendFormattedJsonText(json);
    }

    private async Task sendFormattedJsonText(string json)
    {
        if (String.IsNullOrEmpty(json)) return;
        
        string formattedJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json), Formatting.Indented);
        
        await ReplyAsync("```json" +
                         $"\n{formattedJson}" +
                         "```");
    }
}