using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class EquipmentCategory : Model
{
    private string name;
    private List<ResourceItem> items;

    public EquipmentCategory(JObject json) => castToInformation(json);
    
    protected override void castToInformation(JObject json)
    {
        name = json["name"].ToString();
        items = json["equipment"].ToObject<List<ResourceItem>>();
    }

    public override string ToString()
    {
        var strItems = "- " + listToString("- ", items.Select(item => item.Name).ToList());
        
        return $"## {name}:\n" +
               $"{strItems}";
    }
}