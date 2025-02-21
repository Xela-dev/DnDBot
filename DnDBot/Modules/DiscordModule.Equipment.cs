using Discord.Commands;

namespace DnDBot.Modules;

public partial class DiscordModule : ModuleBase<SocketCommandContext>
{
    [Command("type-equipment")]
    public async Task GetEquipmentCategoryByNameAsync(string name)
    {
        var equipmentCategory = await service.GetEquipmentCategoryByNameAsync(name);
        await sendMessages(equipmentCategory.ToString());
    }
    
    [Command("magic-item")]
    public async Task GetMagicItemByNameAsync(string name)
    {
        var magicItem = await service.GetMagicItemByNameAsync(name);
        await sendMessages(magicItem.ToString());
    }
}