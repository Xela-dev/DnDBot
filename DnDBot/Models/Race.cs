using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class Race : Model
{
    private string name;
    private string size;
    private string age;
    private string speed;
    private string alignment;
    private string abilityBonuses;
    private string languages;
    private List<string> traits;
    private List<string> subraces;

    public Race(JObject json) => castToInformation(json);

    protected override void castToInformation(JObject json)
    {
        name = json["name"].ToString();
        size = json["size"].ToString();
        age = json["age"].ToString();
        speed = json["speed"].ToString();
        alignment = json["alignment"].ToString();
        languages = json["language_desc"].ToString();
        
        setAbilityBonuses(json);
        setTraits(json);
    }

    private void setAbilityBonuses(JObject json)
    {
        foreach (var token in json["ability_bonuses"])
            abilityBonuses += token["ability_score"]["name"].ToString() + $"+{(int)token["bonus"]}, ";
        
        abilityBonuses = abilityBonuses.Substring(0, abilityBonuses.Length - 2);
    }
    
    private void setTraits(JObject json) =>
        traits = json["traits"].Select(t => t["name"].ToString()).ToList();
    
    public override string ToString()
    {
        var strTraits = "- " + listToString("\n- ", this.traits);
        
        return $"## {name}\n" +
               $"**Ability Scores:** {abilityBonuses}\n" +
               $"**Size:** {size}\n" +
               $"**Speed:** {speed}\n" +
               $"**Age.** {age}\n" +
               $"**Alignment.** {alignment}\n" +
               $"**Traits:**\n" +
               $"{strTraits}\n" +
               $"**Languages.** {languages}";
    }
}