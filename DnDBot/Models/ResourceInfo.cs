using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class ResourceInfo : Model
{
    private string name;
    private List<string> resources;

    public ResourceInfo(string name, JArray json)
    {
        this.name = name;
        resources = json.ToObject<List<string>>();
    }

    public override string ToString()
    {
        var strResource = "- " + string.Join("\n- ", resources);
        return $"**{name}:**\n{strResource}";
    }

    protected override void castToInformation(JObject json)
    { }
}