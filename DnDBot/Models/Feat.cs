namespace DnDBot.Model;

public class Feat
{
    public string name { get; set; }
    public List<Prerequisites> prerequisites { get; set; }
    public List<string> desc { get; set; }

    public override string ToString()
    {
        var description = string.Join("\n", desc);

        return $"## {name}\n" +
               $"\n" +
               $"{description}";
    }

    private string getPrerequisites(List<Prerequisites> pr)
    {
        List<string> result = new();
        
        foreach (var prerequisite in prerequisites)
            result.Add($"{prerequisite.ability_score.Name}+{prerequisite.minimum_score}");
        
        return string.Join(", ", result) + "\n";
    }
}

public class Prerequisites
{
    public int minimum_score { get; set; }
    public ResourceItem ability_score { get; set; }
}