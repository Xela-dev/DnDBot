namespace DnDBot.Model;

public class EquipmentCategory : Model
{
    public string name { get; set; }
    public List<ResourceItem> equipment { get; set; }

    public override string ToString()
    {
        var strItems = "- " + listToString("\n- ", equipment.Select(item => item.Name).ToList());
        
        return $"## {name}:\n" +
               $"{strItems}";
    }
}