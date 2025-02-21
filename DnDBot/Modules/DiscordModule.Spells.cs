using Discord.Commands;
using DnDBot.Model;
using Newtonsoft.Json.Linq;

namespace DnDBot.Modules;

public partial class DiscordModule : ModuleBase<SocketCommandContext>
{
    [Command("spell")]
    public async Task GetSpellByName(string name)
    {
        var spell = await service.GetSpellByNameAsync(name);
        await sendMessages(spell.ToString());
    }
    
    [Command("list-spells")]
    public async Task GetSpellsByLevelOrSchool(int level, string school = "")
    {
        var json = await service.GetSpellsByLevelOrSchool(level, school);
        var name = "List of spells " + (string.IsNullOrEmpty(school) ? $"for level {level}" : $"by school {school}");
        var resource = new ResourceInfo(name, JArray.Parse(json));
        
        await sendMessages(resource.ToString());
    }
    
    [Command("list-spells")]
    public async Task GetSpellsByClassAndLevel(string personClass, int level)
    {
        var json = await service.GetSpellsByClassAndLevel(personClass, level);
        var name = $"{personClass}'s spells for level {level}";
        var resource = new ResourceInfo(name, JArray.Parse(json));
        
        await sendMessages(resource.ToString());
    }
}