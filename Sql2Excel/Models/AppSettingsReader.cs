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
    //This class responsible for one thing - load application settings
    class AppSettingsReader : IAppSettingsReader
    {
        public async Task<AppSettings> ExecuteAsync()
        {
            AppSettings appSettings;
            appSettings.ReportQueries = new List<(string ReportName, string ReportSysName, string Query, string[] Servers)>();
            appSettings.Servers = new List<(string SysName, string Name, string ConnectionString, string DbName)>();
            appSettings.ServersDataSource = new List<Server>();

            return await Task.Run(() =>
            {
                System.Configuration.AppSettingsReader appSettingsReader = new System.Configuration.AppSettingsReader();
                appSettings.ReportsFolder = (string)appSettingsReader.GetValue("ReportsFolder", typeof(string));
                appSettings.FilesFolder = (string)appSettingsReader.GetValue("FilesFolder", typeof(string));
                string queriesFileName = (string)appSettingsReader.GetValue("QueriesFileName", typeof(string));
                string serversFileName = (string)appSettingsReader.GetValue("ServersFileName", typeof(string));


                string xml = File.ReadAllText(Path.Combine(appSettings.FilesFolder, queriesFileName));
                XDocument xDocument = XDocument.Parse(xml);
                appSettings.PlacesQuery = xDocument.Descendants("PlacesQuery").Select(x => x.Value).FirstOrDefault();


                xDocument.Descendants("ReportQuery").Select(x => new
                {
                    ReportName = x.Attribute("ReportName")?.Value,
                    ReportSysName = x.Attribute("ReportSysName")?.Value,
                    Query = x.Value,
                    Servers = x.Attribute("Servers")?.Value.Split(',')

                }).ToList().ForEach(x =>
                {
                    appSettings.ReportQueries.Add((x.ReportName, x.ReportSysName, x.Query, x.Servers));
                });


                xml = File.ReadAllText(Path.Combine(appSettings.FilesFolder, serversFileName));
                xDocument = XDocument.Parse(xml);
                

                xDocument.Descendants("Server").Select(x => new
                {
                    SysName = x.Attribute("SysName")?.Value,
                    Name = x.Attribute("Name")?.Value,
                    ConnectionString = x.Attribute("ConnectionString")?.Value,
                    DbName = x.Attribute("DbName")?.Value
                }).ToList().ForEach(x =>
                {
                    appSettings.Servers.Add((x.SysName, x.Name, x.ConnectionString, x.DbName));
                    appSettings.ServersDataSource.Add(new Server(x.SysName, x.Name));
                });

                return appSettings;
            });
        }
    }
}
