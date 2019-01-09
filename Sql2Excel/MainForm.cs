using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Npgsql;
using Npgsql.PostgresTypes;
using Sql2Excel.Models;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
using OfficeOpenXml;
using System.Data.Common;

namespace Sql2Excel
{
    //This class responsible for one thing - represent MainForm
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        IExport Export;
        IAppSettingsReader AppSettingsReader;
        AppSettings AppSettings;
        string ConnectionString = string.Empty;
        Query Query = null;

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", AppSettings.ReportsFolder);
        }

        private async void btnCreateReport_Click(object sender, EventArgs e)
        {
            Server server = (Server)cbServers.SelectedItem;
            ReportType reportType = (ReportType)cbReports.SelectedItem;
            IEnumerable<dynamic> rows = null;
            DynamicParameters dynamicParameters = new DynamicParameters();
            Place place = (Place)cbPlaces.SelectedItem;

            string sql = AppSettings.ReportQueries.FirstOrDefault(x => x.ReportSysName == reportType.SysName).Query;
            dynamicParameters.Add("@PlaceID", place.ID);
            dynamicParameters.Add("@BeginDate", dtBegin.Value.Date, DbType.DateTime);
            dynamicParameters.Add("@EndDate", dtEnd.Value.Date, DbType.DateTime);

            lblStatus.Text = "Формирование отчета. Ожидайте";
            rows = await Query.ExecuteAsync(sql, dynamicParameters);
            lblStatus.Text = "Экспорт отчета в Excel...";

            string fileName = await Export.ExecuteAsync(rows, reportType.SysName, reportType.Name, server.Name, AppSettings.ReportsFolder);
            lblStatus.Text = $"Отчет сохранен";
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Загрузка настроек. Ожидайте";

            Export = new ExportExcel();
            this.AppSettingsReader = new Models.AppSettingsReader();
            AppSettings = await AppSettingsReader.ExecuteAsync();

            cbServers.DataSource = AppSettings.ServersDataSource;
            cbServers.DisplayMember = "Name";
            cbServers.ValueMember = "SysName";
            cbServers.Enabled = true;


            //cbServers.Invoke(new Action(() =>
            //{
            //    cbServers.DataSource = serversDataSource;
            //    cbServers.DisplayMember = "Name";
            //    cbServers.ValueMember = "SysName";
            //    cbServers.Enabled = true;
            //}));

            lblStatus.Text = "Настройки загружены";
        }

        private async void cbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Server server = (Server)cbServers.SelectedItem;
            if (cbServers.Text != server.Name) return; //this prevent double executed in initialization time

            ConnectionString = AppSettings.Servers.FirstOrDefault(x => x.SysName == server.SysName).ConnectionString;
            string dbName = AppSettings.Servers.FirstOrDefault(x => x.SysName == server.SysName).DbName;
            cbPlaces.DataSource = null;
            cbReports.DataSource = null;

            Query = QueryFactory.CreateQuery(dbName, ConnectionString);

            cbPlaces.Enabled = false;
            cbReports.Enabled = false;
            btnCreateReport.Enabled = false;

            IEnumerable<dynamic> rows = null;



            string placesQuery = AppSettings.PlacesQueries.FirstOrDefault(x => x.Servers.Contains(server.SysName)).Query;

            rows = await Query.ExecuteAsync(placesQuery);
            List<Place> places = new List<Place>();

            foreach (var row in rows)
            {
                object value = null;
                Place place = new Place();
                IDictionary<string, object> values = row;
                values.TryGetValue($"id", out value);
                place.ID = (int)value;
                values.TryGetValue($"Name", out value);
                place.Name = (string)value;
                places.Add(place);
            }

            if (places.Count > 0)
            {
                cbPlaces.DataSource = places;
                cbPlaces.DisplayMember = "Name";
                cbPlaces.ValueMember = "ID";
                cbPlaces.Enabled = true;
            }

            List<ReportType> reportTypes = new List<ReportType>();
            AppSettings.ReportQueries.Where(x => x.Servers.Contains(server.SysName)).ToList().ForEach(x=> 
            {
                reportTypes.Add(new ReportType(x.ReportName, x.ReportSysName));
            });

            cbReports.DataSource = reportTypes;
            cbReports.DisplayMember = "Name";
            cbReports.ValueMember = "SysName";
            cbReports.Enabled = true;

            btnCreateReport.Enabled = true;
        }
    }
}
