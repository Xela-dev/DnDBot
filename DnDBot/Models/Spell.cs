using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class Spell : Model
{
    private string spellName;
    private int level;
    private string castingTime;
    private string range;
    private string duration;
    private ResourceItem damage;
    private List<string> components;
    private List<string> desc;
    private List<string> descHighLevel;

    public Spell(JObject json) => castToInformation(json);

    protected override void castToInformation(JObject json)
    {
        this.spellName = json["name"].ToString();
        this.level = (int) json["level"];
        this.castingTime = json["casting_time"].ToString();
        this.range = json["range"].ToString();
        this.components = json["components"].ToObject<List<string>>();
        this.duration = json["duration"].ToString();
        this.desc = json["desc"].ToObject<List<string>>();
        this.descHighLevel = json["higher_level"].ToObject<List<string>>();
        this.damage = json["damage"]["damage_type"].ToObject<ResourceItem>();
    }

    public override string ToString()
    {
        var desc = listToString("\\", this.components.ToArray());
        var descHighLevel = listToString("\\", this.descHighLevel.ToArray());
        var components = listToString(", ", this.components.ToArray());
        var damageType = damage.Name;
        var level = this.level == 0 ? "Cantrip" : this.level+" level";
        
        return $"## {spellName}\n" +
               $"{level}\n" +
               $"**Casting Time:** {castingTime}\n" +
               $"**Range:** {range}\n" +
               $"**Damage type:** {damageType} \n" +
               $"**Components:** {components}\n" +
               $"**Duration:** {duration}\n" +
               $"{desc}\n{descHighLevel}";
    }
}