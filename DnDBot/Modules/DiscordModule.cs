using Discord.Commands;
using DnDBot.Model;
using DnDBot.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        var race = new Race(JObject.Parse(json));
        
        await ReplyAsync(race.toString());
    }
    
    [Command("class")]
    public async Task GetClassByName(string name)
    {
        var json = await service.GetClassByNameAsync(name);
        var personClass = new PersonClass(JObject.Parse(json));
        
        await ReplyAsync(personClass.toString());
    }
    
    [Command("spell")]
    public async Task GetSpellByName(string name)
    {
        var json = await service.GetSpellByNameAsync(name);
        var spell = new Spell(JObject.Parse(json));
        
        await ReplyAsync(spell.toString());
    }
    
    [Command("language")]
    public async Task GetLanguageByName(string name)
    {
        var json = await service.GetLanguagesByNameAsync(name);
        var language = new Language(JObject.Parse(json));
        
        await ReplyAsync(language.toString());
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