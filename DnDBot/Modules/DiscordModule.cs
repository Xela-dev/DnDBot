using Discord.Commands;
using DnDBot.Model;
using DnDBot.Service;
using Newtonsoft.Json.Linq;

namespace DnDBot.Modules;

public class DiscordModule : ModuleBase<SocketCommandContext>
{
    private const int MAX_CHARACTERS = 2000;
    
    private readonly DnDService service = new ();
    
    [Command("background")]
    public async Task GetBackgroundByName(string name)
    {
        var json = await service.GetBackgroundByNameAsync(name);
        //await sendFormattedJsonText(json);
    }
    
    [Command("race")]
    public async Task GetRaceByName(string name)
    {
        var json = await service.GetRaceByName(name);
        var race = new Race(JObject.Parse(json));
        
        await sendMessages(race.ToString());
    }
    
    [Command("class")]
    public async Task GetClassByName(string name)
    {
        var json = await service.GetClassByNameAsync(name);
        var personClass = new PersonClass(JObject.Parse(json));
        
        await sendMessages(personClass.ToString());
    }
    
    [Command("spell")]
    public async Task GetSpellByName(string name)
    {
        var json = await service.GetSpellByNameAsync(name);
        var spell = new Spell(JObject.Parse(json));
        
        await sendMessages(spell.ToString());
    }
    
    [Command("language")]
    public async Task GetLanguageByName(string name)
    {
        var json = await service.GetLanguagesByNameAsync(name);
        var language = new Language(JObject.Parse(json));
        
        await sendMessages(language.ToString());
    }
    
    [Command("resource")]
    public async Task GetResourcesByName(string name)
    {
        var json = await service.GetResourcesByPathAsync(name);
        var resource = new ResourceInfo(name, JArray.Parse(json));
        
        await sendMessages(resource.ToString());
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

    private async Task sendMessages(string text)
    {
        if (String.IsNullOrEmpty(text)) return;

        var splitMessage = this.splitMessage(text);

        foreach (var message in splitMessage)
            await ReplyAsync(message);
    }
    
    private List<string> splitMessage(string message)
    {
        var result = new List<string>();

        while (message.Length > MAX_CHARACTERS)
        {
            int breakIndex = message.LastIndexOf('\n', MAX_CHARACTERS);
            
            if (breakIndex == -1)
                breakIndex = message.LastIndexOf(' ', MAX_CHARACTERS);
            
            if (breakIndex == -1)
                breakIndex = MAX_CHARACTERS;
            
            string part = message.Substring(0, breakIndex).TrimEnd();
            string remainder = message.Substring(breakIndex).TrimStart();
            
            if (remainder.StartsWith("- ") && !part.EndsWith("\n"))
            {
                int newBreakIndex = message.LastIndexOf('\n', breakIndex);
                if (newBreakIndex != -1)
                {
                    breakIndex = newBreakIndex;
                    part = message.Substring(0, breakIndex).TrimEnd();
                    remainder = message.Substring(breakIndex).TrimStart();
                }
            }

            result.Add(part);
            message = remainder;
        }
        
        if (message.Length > 0)
            result.Add(message);

        return result;
    }
}