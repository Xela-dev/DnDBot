using Newtonsoft.Json.Linq;

namespace DnDBot.Model;

public abstract class Model
{
    public abstract string toString();
    protected abstract void castToInformation(JObject json);

    private protected string listToString(string separator, IList<string> list)
    {
        return string.Join(separator, list);
    }
}