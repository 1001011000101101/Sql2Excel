using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Configuration;
using System.Xml.Linq;

namespace Sql2Excel.Models
{
    //Responsible for only one thing - contains application settings
    struct AppSettings
    {
        public string ReportsFolder;
        public string FilesFolder;
        public List<(string Query, string[] Servers)> PlacesQueries;
        public List<(string ReportName, string ReportSysName, string Query, string[] Servers)> ReportQueries;
        public List<(string SysName, string Name, string ConnectionString, string DbName)> Servers;
        public List<Server> ServersDataSource;
    }
}
