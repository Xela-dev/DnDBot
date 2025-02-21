namespace DnDBot.Model;

public class MagicItem : Model
{
    public string name { get; set; }
    public RarityItem rarity { get; set; }
    public List<string> desc { get; set; }

    public override string ToString()
    {
        var description = listToString("\n", desc);
        
        return $"## {name}\n" +
               $"{rarity.name}\n" +
               $"{description}";
    }
}

public class RarityItem
{
    public string name { get; set; }
}