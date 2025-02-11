using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class Skill : Model
{
    public string name { get; set; }
    public List<string> desc { get; set; }
    public ResourceItem ability_score { get; set; }

    public override string ToString()
    {
        var strDesc = listToString("\n", desc);
        
        return $"## {name}\n" +
               $"**Ability Score: ** {ability_score.Name}\n" +
               $"{strDesc}";
    }
}