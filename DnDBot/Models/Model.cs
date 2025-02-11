namespace DnDBot.Model;

public abstract class Model
{
    private protected string listToString(string separator, IList<string> list)
    {
        return string.Join(separator, list);
    }
}