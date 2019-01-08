using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql2Excel.Models
{
    //Close for modification and open for extension
    interface IAppSettingsReader
    {
        Task<AppSettings> ExecuteAsync();
    }
}
