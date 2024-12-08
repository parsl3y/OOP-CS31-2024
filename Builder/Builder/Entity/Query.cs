namespace Builder.Entity;

public class Query
{
    private readonly string _commandText;
    private readonly Dictionary<string, string> _parameters;

    public Query(string commandText)
    {
        _commandText = commandText;
    }

    public string this[string key]
    {
        get => _parameters.ContainsKey(key) ? _parameters[key] : null;
        set => _parameters[key] = value;
    }

    public void CommandText() => Console.WriteLine(_commandText);

    public void CommandParameters()
    {
        foreach (var param in _parameters)
        {
            Console.WriteLine($"{param.Key}: {param.Value}");
        }
    }
}