using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql2Excel.Models
{
    //This class responsible for one thing - represent the reportType
    class ReportType
    {
        public string Name { get; set; }
        public string SysName { get; set; }

        public ReportType (string Name, string SysName)
        {
            this.Name = Name;
            this.SysName = SysName;
        }
    }
}
