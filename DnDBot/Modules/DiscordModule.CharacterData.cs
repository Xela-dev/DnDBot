using Discord.Commands;

namespace DnDBot.Modules;

public partial class DiscordModule : ModuleBase<SocketCommandContext>
{
    [Command("ability-score")]
    public async Task GetAbilityScoreByNameAsync(string name)
    {
        var abilityScore = await service.GetAbilityScoreByNameAsync(name);
        await sendMessages(abilityScore.ToString());
    }
    
    [Command("alignment")]
    public async Task GetAlignmentByName(string name)
    {
        var alignment = await service.GetAlignmentByNameAsync(name);
        await sendMessages(alignment.ToString());
    }
    
    [Command("background")]
    public async Task GetBackgroundByName(string name)
    {
        var json = await service.GetBackgroundByNameAsync(name);
        throw new NotImplementedException();
    }
    
    [Command("language")]
    public async Task GetLanguageByName(string name)
    {
        var language = await service.GetLanguagesByNameAsync(name);
        await sendMessages(language.ToString());
    }
    
    [Command("skill")]
    public async Task GetSkillByIndexAsync(string index)
    {
        var skill = await service.GetSkillByIndexAsync(index);
        await sendMessages(skill.ToString());
    }
}