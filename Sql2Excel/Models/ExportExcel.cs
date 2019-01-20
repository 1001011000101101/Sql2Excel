using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Sql2Excel.Models
{
    //This class responsible for one thing - export data
    class ExportExcel : IExport
    {
        protected string ReportName;
        protected ExcelPackage excelPackage;
        protected ExcelWorkbook excelWorkbook;
        protected ExcelWorksheet excelWorksheet;
        protected IEnumerable<dynamic> Rows;
        protected int startRow = 1, startColumn = 1;
        protected string yesLabel = "True";
        protected string noLabel = "False";

        public async Task<string> ExecuteAsync(IEnumerable<dynamic> Rows, string ReportSysName, string ReportName, string ServerName, string ReportsFolder, string[] Commands, AppSettings Settings)
        {
            this.ReportName = ReportName;
            this.Rows = Rows;

            string fileName = $"{ServerName} {ReportName} {DateTime.Now.ToString().Replace(":", "")}.xlsx";
            

            excelPackage = new ExcelPackage();
            excelWorkbook = excelPackage.Workbook;

            return await Task.Run(() =>
            {
                try
                {
                    for (int j = 0; j < Commands.Count(); j++)
                    {
                        string command = string.Empty;
                        object[] commandParams = null;

                        ParseCommand(Commands[j], Settings.RegexCommand, Settings.RegexCommandParams, out command, out commandParams);
                        
                        if (command != string.Empty)
                        {
                            MethodInfo mi = (MethodInfo)this.GetType().GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .FirstOrDefault(x => x.MemberType == MemberTypes.Method && x.Name == command);
                            //MethodInfo mi = this.GetType().GetMethod(command);
                            mi?.Invoke(this, commandParams);
                        }
                    }

                    FileInfo fi = new FileInfo(Path.Combine(Path.GetFullPath(ReportsFolder), fileName));
                    excelPackage.SaveAs(fi);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    excelPackage.Dispose();
                }

                return fileName;
            });
        }

        private void ParseCommand(string Input, string RegexCommand, string RegexCommandParams, out string Command, out object[] CommandParams)
        {
            Command = string.Empty;
            CommandParams = null;

            Regex regex = new Regex(RegexCommand);
            var match = regex.Match(Input);
            if (match.Success)
            {
                Command = match.Value;
            }

            regex = new Regex(RegexCommandParams);
            match = regex.Match(Input);
            if (match.Success)
            {
                string value = match.Value;
                CommandParams = value.Split(',');
            }
        }

        private void Fill()
        {
            if (Rows.Count() == 0 || excelWorkbook == null) return;

            excelWorksheet = excelWorkbook.Worksheets.Add(ReportName);
            var firstRow = Rows.First();
            IDictionary<string, object> values = null;
            values = (IDictionary<string, object>)firstRow;
            List<string> fieldNames = new List<string>();
            int i = 0;
            foreach (var item in values)
            {
                fieldNames.Add(item.Key);

                excelWorksheet.Cells[startRow, startColumn + i].Value = item.Key;
                excelWorksheet.Column(startColumn + i).AutoFit();
                excelWorksheet.Column(startColumn + i).BestFit = true;
                i++;
            }

            i = startRow + 1;

            foreach (var row in Rows)
            {
                values = (IDictionary<string, object>)row;

                for (int j = 0; j < fieldNames.Count; j++)
                {
                    object value = null;
                    values.TryGetValue(fieldNames[j], out value);

                    if (value != null && value.GetType() == typeof(DateTime))
                    {
                        value = ((DateTime)value).ToShortDateString();
                    }
                    else if (value != null && value.GetType() == typeof(bool))
                    {
                        value = ((bool)value) ? yesLabel : noLabel;
                    }
                    else if (value != null && value.GetType() == typeof(double))
                    {
                        value = Math.Round((double)value, 3);
                    }

                    excelWorksheet.Cells[i, startColumn + j].Value = value;
                }
                i++;
            }

            excelWorksheet.Row(startRow).Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            excelWorksheet.Row(startRow).Style.Font.Bold = true;

            for (i = 0; i < excelWorksheet.Dimension.End.Column; i++)
            {
                excelWorksheet.Column(startColumn + i).AutoFit();
                excelWorksheet.Column(startColumn + i).BestFit = true;
            }
        }
    }
}
