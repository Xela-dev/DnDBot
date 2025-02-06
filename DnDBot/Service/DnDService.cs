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
    
    public Task<string> GetRaceByName(string name)
    {
        return apiService.GetItemByNameAsync("races", name);
    }
    
    public Task<string> GetClassByNameAsync(string name)
    {
        return apiService.GetStrItemByNameAsync("classes", name);
    }
    
    public Task<string> GetSubraceByNameAsync(string name)
    {
        return apiService.GetStrItemByNameAsync("subraces", name);
    }
    
    public Task<string> GetByTraitsNameAsync(string name)
    {
        return apiService.GetStrItemByNameAsync("traits", name);
    }
    
    public Task<string> GetSpellByNameAsync(string name)
    {
        return apiService.GetStrItemByNameAsync("spells", name);
    }
    
    public Task<string> GetAlignmentByNameAsync(string alignmentOrder, string morality = "")
    {
        var name = $"{alignmentOrder}" + (string.IsNullOrEmpty(morality) ? $"-{morality}" : string.Empty);
        return apiService.GetStrItemByNameAsync("ability-scores", name);
    }

    public async Task<string> GetAbilityScoreByNameAsync(string name)
    {
        return await apiService.GetItemByNameAsync("ability-scores", name);
    }

    public async Task<string> GetSkillByIndexAsync(string index)
    {
        return await apiService.GetItemByNameAsync("skills", index);
    }
    
    public async Task<string> GetLanguagesByNameAsync(string name)
    {
        return await apiService.GetItemByNameAsync("languages", name);
    }

    public async Task<string> GetEquipmentCategoryByNameAsync(string name)
    {
        return await apiService.GetItemByNameAsync("equipment-categories", name);
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