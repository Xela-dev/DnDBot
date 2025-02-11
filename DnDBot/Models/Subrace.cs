using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class Subrace : Model
{
    public string name { get; set; }
    public ResourceItem race  { get; set; }
    public string desc { get; set; }
    public List<AbilityBonuses> ability_bonuses { get; set; }
    public List<ResourceItem> starting_proficiencies { get; set; }
    public ProficiencyOptionalChoice language_options { get; set; }
    public List<ResourceItem> racial_traits { get; set; }

    public override string ToString()
    {
        var strAbility = setStrAbilityBonuses();
        var strProficiency = starting_proficiencies.IsNullOrEmpty() ? "" 
            : "- " + listToString("\n- ", starting_proficiencies.Select(pro => pro.Name).ToList());
        var strLanguage = language_options.from.options.IsNullOrEmpty() ? ""
            : "- " + listToString("\n- ", language_options.from.options.Select(lan => lan.item.Name).ToList());
        var traits = "- " + listToString("\n- ", racial_traits.Select(trait => trait.Name).ToList());
        
        return $"## {name}\n" +
               $"**Ability Scores:** {strAbility}\n" +
               $"**Race:** {race.Name}\n" +
               $"{desc}\n" +
               $"**Weapon Proficiencies:** {strProficiency}\n" +
               $"**Language options:** {strLanguage}\n" +
               $"**Racial traits:**  {traits}";
    }
    
    private string setStrAbilityBonuses()
    {
        string abilityBonusesStr = "";
        
        foreach (var ability in ability_bonuses)
            abilityBonusesStr += ability.ability_score.Name + $"+{ability.bonus}, ";

        return abilityBonusesStr.Substring(0, abilityBonusesStr.Length - 2);
    }
}