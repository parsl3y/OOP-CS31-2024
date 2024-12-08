using Builder.Entity;

namespace Builder;

public class MSSQLBuilder : SqlBuilder
{
    public MSSQLBuilder()
    {
        _query = new Query("\n MSSQL Command\n");
    }

    public override SqlBuilder Select<T>()
    {
        _query["SELECT"] = "*";
        _query["FROM"] = typeof(T).Name;
        return this;
    }

    public override SqlBuilder OrderBy(string orderByColumnName)
    {
        _query["ORDER BY"] = $"{orderByColumnName} ASC";
        return this;
    }
    
    public override SqlBuilder Take(int count)
    {
        _query["SELECT"] = $"TOP {count} *";
        return this;
    }
}