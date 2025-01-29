using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class PersonClass : Model
{
    private string name;
    private string hitDie;
    private List<string> proficiencyChoices;
    private List<string> proficiency;
    private string savingThrows;
    private string equipment;
    private List<string> equipmentOption;


    public PersonClass(JObject json) => castToInformation(json);


    public override string toString()
    {
        string equipmentOption = this.equipmentOption != null ? listToString(", ", this.equipmentOption) : null;
        string proficiencyChoices = this.proficiencyChoices != null ? listToString(", ", this.proficiencyChoices) : null;
        string proficiency = listToString(", ", this.proficiency);
        
        //TODO: fix equipment
        string strEquipment = equipment + (equipmentOption != null ? $"\n{equipmentOption}\n" : "\n");
        string strProficiency = proficiency + (proficiencyChoices != null ? $"\n{proficiencyChoices}\n" : "\n");
        
        return $"## {name}\n" +
               $"**Hit Point Die:** {hitDie}\n" +
               $"**Saving Throw Proficiencies:** {savingThrows}\n" +
               $"**Skill Proficiencies:** {strProficiency}\n" +
               $"**Equipment:** {strEquipment}";
    }

    protected override void castToInformation(JObject json)
    {
        name = json["name"].ToString();
        hitDie = $"1d{(int)json["hit_die"]}";
        setProficiencyChoices(json);
        setProficiencyClass(json);
        setSavingThrows(json);
        setEquipment(json);
    }
    
    private void setEquipmentOption(JObject json) =>
        equipmentOption = json["starting_equipment_options"].Select(eq => eq["desc"].ToString()).ToList();

    private void setSavingThrows(JObject json) =>
        savingThrows = listToString(", ",json["saving_throws"].Select(s => s["name"].ToString()).ToList());
    
    private void setEquipment(JObject json) =>
        equipment = listToString(", ",json["starting_equipment"].Select(s => s["equipment"]["name"].ToString()).ToList());

    private void setProficiencyClass(JObject json)
    {
        proficiency = json["proficiencies"].Select(pro => pro["name"].ToString()).ToList();
        int countSavingThrows = json["saving_throws"].Count();
        proficiency.RemoveRange(proficiency.Count - countSavingThrows, countSavingThrows);
    }

    private void setProficiencyChoices(JObject json)
    {
        proficiencyChoices = new();

        foreach (var proficiency in json["proficiency_choices"])
        {
            var prof = proficiency["desc"].ToString();
            proficiencyChoices.Add(prof);
        }
    }
}