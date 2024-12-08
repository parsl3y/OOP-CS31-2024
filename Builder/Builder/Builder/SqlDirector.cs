using Builder.Entity;

namespace Builder;

public class SqlDirector
{
    public void SQLQueryWithOrderByAsc(SqlBuilder sqlBuilder)
    {
        var query = sqlBuilder.Select<User>()
            .OrderBy("RegistrationDate")
            .Build();

        query.CommandText();
        query.CommandParameters();
    }

    public void SQLQueryWithTake(SqlBuilder sqlBuilder)
    {
        var query = sqlBuilder.Select<User>()
            .OrderBy("RegistrationDate")
            .Take(10)
            .Build();

        query.CommandText();
        query.CommandParameters();
    }
}