using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public class ResourceInfo : Model
{
    private string name;
    private List<string> resources;

    public ResourceInfo(string name, JArray json)
    {
        this.name = name[0].ToString().ToUpper() + name.Substring(1);
        resources = json.ToObject<List<string>>();
    }

    public override string ToString()
    {
        var strResource = resources.Count > 0 ? "- " + string.Join("\n- ", resources) : "**empty**";
        return $"**{name}:**\n{strResource}";
    }

    protected override void castToInformation(JObject json)
    { }
}