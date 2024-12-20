namespace DnDBot.Model;

public class Feature
{
    public int Count { get; set; }
    public List<ResourceItem> Results { get; set; }
}

public class ResourceItem
{
    public string Index { get; set; }
    public string Name { get; set; }
    public int? Level { get; set; }
    public string Url { get; set; }
}