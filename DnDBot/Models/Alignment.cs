namespace DnDBot.Model;

public class Alignment : Model
{
    public string name { get; set; }
    public string desc { get; set; }

    public override string ToString()
    {
        return $"## {name}\n{desc}";
    }
}