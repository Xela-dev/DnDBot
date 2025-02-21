namespace DnDBot.Model;

public class Subclass
{
    public string name { get; set; }
    public string subclass_flavor { get; set; }
    public List<string> desc { get; set; }

    public override string ToString()
    {
        var description = string.Join("\n", desc);
        
        return $"## {name}\n" +
               $"**Subclass flavor: **{subclass_flavor}\n" +
               $"{description}";
    }
}