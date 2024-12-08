using Builder;


SqlBuilder builder;

var sqlDirector = new SqlDirector();

builder = new PostgreSQLBuilder();
sqlDirector.SQLQueryWithOrderByAsc(builder);
sqlDirector.SQLQueryWithTake(builder);

builder = new MSSQLBuilder();
sqlDirector.SQLQueryWithOrderByAsc(builder);
sqlDirector.SQLQueryWithTake(builder);