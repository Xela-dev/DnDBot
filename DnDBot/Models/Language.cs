using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class Language : Model
{
    private string name;
    private string type;
    private List<string> typicalSpeaker;
    private string description;
    
    public Language(JObject json) => castToInformation(json);
    
    public override string ToString()
    {
        var speakers = string.Join(", ", typicalSpeaker);

        return $"## {name}\n" +
               $"**Type:** {type}\n" +
               $"**Speakers:** {speakers}\n" +
               $"{description}";
    }

    protected override void castToInformation(JObject json)
    {
        name = json["name"].ToString();
        description = json["desc"].ToString();
        type = json["type"].ToString();
        typicalSpeaker = json["typical_speakers"].ToObject<List<string>>();
    }
}