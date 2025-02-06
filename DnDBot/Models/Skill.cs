using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class Skill : Model
{
    private string name;
    private List<ResourceItem> description;
    private string abilityScore;

    public Skill(JObject json) => castToInformation(json);
    
    protected override void castToInformation(JObject json)
    {
        name = json["name"].ToString();
        description = json["desc"]!.ToObject<List<ResourceItem>>();
        abilityScore = json["ability_score"]["name"].ToString();
    }

    public override string ToString()
    {
        var strDesc = listToString("\n", description.Select(desc => desc.Name).ToList());
        
        return $"## {name}\n" +
               $"**Ability Score: ** {abilityScore}\n" +
               $"{strDesc}";
    }
}