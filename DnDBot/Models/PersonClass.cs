using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class PersonClass : Model
{
    public string name { get; set; }
    public int hit_die { get; set; }
    public List<ProficiencyOptionalChoice> proficiency_choices { get; set; }
    public List<ResourceItem> proficiencies { get; set; }
    public List<ResourceItem> saving_throws { get; set; }
    public List<StartingEquipment> starting_equipment { get; set; }
    public List<StartingEquipmentOption> starting_equipment_options { get; set; }

    public override string ToString()
    {
        string equipmnent = listToString(", ",starting_equipment.Select(s => s.equipment.Name).ToList());
        string equipmentOption = listToString(", ", starting_equipment_options.Select(s => s.desc).ToList());
        string strEquipment = $"**Starting Equipment: **" + equipmnent + (equipmentOption != null ? $", Choose A or B: {equipmentOption}\n" : "\n");
        
        string proficiencyChoices = proficiency_choices != null ? listToString(", ", proficiency_choices.Select(prof => prof.desc).ToList()) : null;
        string proficiency = listToString(", ", proficiencies.Select(prof => prof.Name).ToList());
        string strProficiency = $"**Weapon Proficiencies: **" + proficiency + (proficiencyChoices != null ? $"\n**Skill Proficiencies:** {proficiencyChoices}\n" : "\n");

        var strSavingThrows = listToString(", ", saving_throws.Select(res => res.Name).ToList());

        return $"## {name}\n" +
               $"**Hit Point Die:** 1d{hit_die}\n" +
               $"**Saving Throw Proficiencies:** {strSavingThrows}\n" +
               $"{strProficiency}" + $"{strEquipment}";
    }
}

public class ProficiencyOptionalChoice
{
    public string desc { get; set; }
    public int choose { get; set; }
    public string type { get; set; }
    public From from { get; set; }
}

public class From
{
    public string option_set_type { get; set; }
    public List<Option> options { get; set; }
    public EquipmentCategory equipment_category { get; set; }
}

public class Option
{
    public string option_type { get; set; }
    public ResourceItem item { get; set; }
    public int? count { get; set; }
    public ResourceItem? of { get; set; }
    public Choice? choice { get; set; }
}

public class Choice
{
    public string desc { get; set; }
    public int choose { get; set; }
    public string type { get; set; }
    public From from { get; set; }
}

public class StartingEquipment
{
    public ResourceItem equipment { get; set; }
    public int quantity { get; set; }
}

public class StartingEquipmentOption
{
    public string desc { get; set; }
    public int choose { get; set; }
    public string type { get; set; }
    public From from { get; set; }
}