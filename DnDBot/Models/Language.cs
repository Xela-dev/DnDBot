namespace DnDBot.Model;

public class Language : Model
{
    public string name { get; set; }
    public string type { get; set; }
    public List<string> typical_speakers { get; set; }
    public string desc { get; set; }
    
    public override string ToString()
    {
        var speakers = string.Join(", ", typical_speakers);

        return $"## {name}\n" +
               $"**Type:** {type}\n" +
               $"**Speakers:** {speakers}\n" +
               $"{desc}";
    }
}