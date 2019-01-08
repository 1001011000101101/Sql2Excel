using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Sql2Excel.Models
{
    //Close for modification and open for extension
    public abstract class Query
    {
        public string ConnectionString { get; set; }
        public abstract Task<IEnumerable<dynamic>> ExecuteAsync(string Sql, DynamicParameters DynamicParameters = null);
    }
}
