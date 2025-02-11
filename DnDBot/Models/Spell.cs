using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class Spell : Model
{
    public string name { get; set; }
    public int level { get; set; }
    public string casting_time { get; set; }
    public string range { get; set; }
    public string duration { get; set; }
    public ResourceItem damage { get; set; }
    public List<string> components { get; set; }
    public List<string> desc { get; set; }
    public List<string> higher_level { get; set; }

    public override string ToString()
    {
        var desc = listToString("\\", this.desc.ToArray());
        var descHighLevel = listToString("\\", higher_level.ToArray());
        var components = listToString(", ", this.components.ToArray());
        var damageType = damage.Name;
        var level = this.level == 0 ? "Cantrip" : this.level+" level";
        
        return $"## {name}\n" +
               $"{level}\n" +
               $"**Casting Time:** {casting_time}\n" +
               $"**Range:** {range}\n" +
               $"**Damage type:** {damageType} \n" +
               $"**Components:** {components}\n" +
               $"**Duration:** {duration}\n" +
               $"{desc}\n{descHighLevel}";
    }
}