using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class Race : Model
{
    public string name { get; set; }
    public string size { get; set; }
    public string age { get; set; }
    public string speed { get; set; }
    public string alignment { get; set; }
    public List<AbilityBonuses> ability_bonuses { get; set; }
    public string language_desc { get; set; }
    public List<ResourceItem> traits { get; set; }
    public List<ResourceItem> subraces { get; set; }

    public override string ToString()
    {
        var ability = setStrAbilityBonuses();
        var strTraits = "- " + listToString("\n- ", traits.Select(t => t.Name).ToList());
        
        return $"## {name}\n" +
               $"**Ability Scores:** {ability}\n" +
               $"**Size:** {size}\n" +
               $"**Speed:** {speed}\n" +
               $"**Age.** {age}\n" +
               $"**Alignment.** {alignment}\n" +
               $"**Traits:**\n" +
               $"{strTraits}\n" +
               $"**Languages.** {language_desc}";
    }
    
    private string setStrAbilityBonuses()
    {
        string abilityBonusesStr = "";
        
        foreach (var ability in ability_bonuses)
            abilityBonusesStr += ability.ability_score.Name + $"+{ability.bonus}, ";

        return abilityBonusesStr.Substring(0, abilityBonusesStr.Length - 2);
    }
}

public class AbilityBonuses
{
    public int bonus { get; set; }
    public ResourceItem ability_score { get; set; }
}