using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class AbilityScore : Model
{
    public string name { get; set; }
    public List<string> desc { get; set; }
    public List<ResourceItem> skills { get; set; }

    public override string ToString()
    {
        var strDesc = listToString("\n", desc);
        var strSkills = "- " + listToString("\n- ", skills.Select(item => item.Name).ToList());
        
        return $"## {name}\n" +
               $"{strDesc}\n" +
               $"**\nSkills:\n**" +
               $"{strSkills}";
    }
}