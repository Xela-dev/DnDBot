using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class AbilityScore : Model
{
    private string name;
    private List<string> description;
    private List<ResourceItem> resourceItems;

    public AbilityScore(JObject json) => castToInformation(json);

    protected override void castToInformation(JObject json)
    {
        name = json["full_name"]!.ToString();
        description = json["desc"]!.ToObject<List<string>>();
        resourceItems = json["resources"]!.ToObject<List<ResourceItem>>();
    }

    public override string ToString()
    {
        var strDesc = listToString("\n", description);
        var strSkills = "- " + listToString("- ", resourceItems.Select(item => item.Name).ToList());
        
        return $"## {name}\n" +
               $"{strDesc}\n" +
               $"**skills:\n**" +
               $"{strSkills}";
    }
}