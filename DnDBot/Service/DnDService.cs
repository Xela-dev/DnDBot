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
    
    public Task<Subrace> GetSubraceByNameAsync(string name)
    {
        return apiService.GetItemByNameAsync<Subrace>("subraces", name);
    }
    
    public Task<string> GetByTraitsNameAsync(string name)
    {
        return apiService.GetItemByNameAsync("traits", name);
    }
    
    public Task<Spell> GetSpellByNameAsync(string name)
    {
        return apiService.GetItemByNameAsync<Spell>("spells", name);
    }
    
    public Task<string> GetAlignmentByNameAsync(string alignmentOrder, string morality = "")
    {
        var name = $"{alignmentOrder}" + (string.IsNullOrEmpty(morality) ? $"-{morality}" : string.Empty);
        return apiService.GetItemByNameAsync("ability-scores", name);
    }

    public async Task<AbilityScore> GetAbilityScoreByNameAsync(string name)
    {
        return await apiService.GetItemByNameAsync<AbilityScore>("ability-scores", name);
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
    
    public async Task<string> GetResourcesByPathAsync(string path)
    {
        var resouces = await apiService.GetResourcesByPathAsync(path);
        return resouces;
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
}