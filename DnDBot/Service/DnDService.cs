using DnDBot.Model;

namespace DnDBot.Service;

public class DnDService
{
    private ApiService apiService; 
    
    public DnDService() => apiService = new ();
    
    public Task<string> GetBackgroundByNameAsync(string name)
    {
        return apiService.GetItemByNameAsync("backgrounds", name);
    }
    
    public Task<Race> GetRaceByName(string name)
    {
        return apiService.GetItemByNameAsync<Race>("races", name);
    }
    
    public Task<PersonClass> GetClassByNameAsync(string name)
    {
        return apiService.GetItemByNameAsync<PersonClass>("classes", name);
    }

    public Task<Subclass> GetSubclassByName(string name)
    {
        return apiService.GetItemByNameAsync<Subclass>("subclasses", name);
    }

    public Task<string> GetSubclassesByNameClassAsync(string name)
    {
        return GetResourceByNameClass("subclasses", name);
    }
    
    public Task<string> GetProficienciesByNameClassAsync(string name)
    {
        return GetResourceByNameClass("proficiencies", name);
    }
    
    public Task<string> GetFeatsByNameClassAsync(string name)
    {
        return GetResourceByNameClass("features", name);
    }
    
    public Task<Subrace> GetSubraceByNameAsync(string name)
    {
        return apiService.GetItemByNameAsync<Subrace>("subraces", name);
    }
    public Task<string> GetByTraitsNameAsync(string name)
    {
        return apiService.GetItemByNameAsync("traits", name);
    }

    #region Spells
    
    public Task<Spell> GetSpellByNameAsync(string name)
    {
        return apiService.GetItemByNameAsync<Spell>("spells", name);
    }
    
    public async Task<string> GetSpellsByLevelOrSchool(int level, string school = "")
    {
        var path = $"spells?level={level}" + (string.IsNullOrEmpty(school) ? $"&school={school}" : string.Empty);
        var resouces = await apiService.GetResourcesByPathAsync(path);
        return resouces;
    }

    public async Task<string> GetSpellsByClassAndLevel(string personClass, int level)
    {
        var path = $"classes/{personClass}/levels/{level}/spells";
        var resouces = await apiService.GetResourcesByPathAsync(path);
        return resouces;
    }
    
    public async Task<string> GetSpellsByNameClassAsync(string name)
    {
        return await GetResourceByNameClass("spells", name);
    }
    
    #endregion
    
    public async Task<Alignment> GetAlignmentByNameAsync(string name)
    {
        return await apiService.GetItemByNameAsync<Alignment>("alignments", name);
    }

    public async Task<AbilityScore> GetAbilityScoreByNameAsync(string name)
    {
        return await apiService.GetItemByNameAsync<AbilityScore>("ability-scores", name);
    }
    
    public async Task<MagicItem> GetMagicItemByNameAsync(string name)
    {
        return await apiService.GetItemByNameAsync<MagicItem>("magic-items", name);
    }

    public async Task<Feat> GetFeatByNameAsync(string name)
    {
        return await apiService.GetItemByNameAsync<Feat>("feats", name);
    }
    
    public async Task<Skill> GetSkillByIndexAsync(string index)
    {
        return await apiService.GetItemByNameAsync<Skill>("skills", index);
    }
    
    public async Task<Language> GetLanguagesByNameAsync(string name)
    {
        return await apiService.GetItemByNameAsync<Language>("languages", name);
    }

    public async Task<EquipmentCategory> GetEquipmentCategoryByNameAsync(string name)
    {
        return await apiService.GetItemByNameAsync<EquipmentCategory>("equipment-categories", name);
    }

    public async Task<string> GetMonstersByRankAsync(string rank)
    {
        return await apiService.GetItemByNameAsync("monsters", rank.Replace(",", "%2C"));
    }
    
    public async Task<string> GetResourcesByPathAsync(string path)
    {
        var resouces = await apiService.GetResourcesByPathAsync(path);
        return resouces;
    }

    private async Task<string> GetResourceByNameClass(string typeResorce, string name)
    {
        var index = $"{name}/classes";
        var resource = await apiService.GetItemByNameAsync<string>(typeResorce, index);
        return resource;
    }
}