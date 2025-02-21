using Discord.Commands;
using DnDBot.Model;
using DnDBot.Service;
using Newtonsoft.Json.Linq;

namespace DnDBot.Modules;

public partial class DiscordModule : ModuleBase<SocketCommandContext>
{
    private const int MAX_CHARACTERS = 2000;

    private readonly DnDService service = new();
    
    [Command("race")]
    public async Task GetRaceByName(string name)
    {
        var race = await service.GetRaceByName(name);
        await sendMessages(race.ToString());
    }
    
    [Command("class")]
    public async Task GetClassByName(string name)
    {
        var personClass = await service.GetClassByNameAsync(name);
        await sendMessages(personClass.ToString());
    }

    [Command("subclass")]
    public async Task GetSubclassByName(string name)
    {
        var subclass = await service.GetSubclassByName(name);
        await sendMessages(subclass.ToString());
    }
    
    [Command("list")]
    public async Task GetResourcesByName(string name)
    {
        var json = await service.GetResourcesByPathAsync(name);
        var resource = new ResourceInfo(name, JArray.Parse(json));
        
        await sendMessages(resource.ToString());
    }

    [Command("subrace")]
    public async Task GetSubraceByNameAsync(string name)
    {
        var subrace = await service.GetSubraceByNameAsync(name);
        await sendMessages(subrace.ToString());
    }

    [Command("traits")]
    public async Task<string> GetTraitsByNameAsync(string name)
    {
        var json = await service.GetByTraitsNameAsync(name);
        throw new NotImplementedException();
    }

    [Command("list-subclasses")]
    public async Task GetSubclassByNameClassAsync(string name)
    {
        var json = await service.GetSubclassesByNameClassAsync(name);
        var title = $"Subclasses by class {name}";
        var resource = new ResourceInfo(title, JArray.Parse(json));
        
        await sendMessages(resource.ToString());
    }

    [Command("list-monsters")]
    public async Task GetMonstersByRank(string rank)
    {
        var json = await service.GetMonstersByRankAsync(rank);
        var title = $"Monsters by ranks: {rank}";
        var resource = new ResourceInfo(title, JArray.Parse(json));
        
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