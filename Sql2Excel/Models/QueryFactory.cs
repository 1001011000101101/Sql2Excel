using System;

namespace Sql2Excel.Models
{
    //This class responsible for one thing - instantiate Query child class by it name
    public class QueryFactory
    {
        public static Query CreateQuery(string DbName, string ConnectionString)
        {
            Type type = Type.GetType($"{typeof(QueryFactory).Namespace}.Query{DbName}");
            Query query = (Query)Activator.CreateInstance(type);
            query.ConnectionString = ConnectionString;
            return query;
        }
    }
}
