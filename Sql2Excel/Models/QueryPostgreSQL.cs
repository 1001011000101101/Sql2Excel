using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using System.Reflection;

namespace Sql2Excel.Models
{
    //This class responsible for one thing - execute query to PostgreSQL
    class QueryPostgreSQL : Query
    {
        public QueryPostgreSQL()
        {
        }

        public QueryPostgreSQL(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public override async Task<IEnumerable<dynamic>> ExecuteAsync(string Sql, DynamicParameters DynamicParameters = null)
        {
            IEnumerable<dynamic> rows = null;

            return await Task.Run(() =>
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    rows = connection.Query<dynamic>(Sql, DynamicParameters).ToArray();
                }

                return rows;
            });
        }
    }
}
