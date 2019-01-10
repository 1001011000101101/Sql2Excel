using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;

namespace Sql2Excel.Models
{
    //This class responsible for one thing - export data
    class ExportExcel : IExport
    {
        public async Task<string> ExecuteAsync(IEnumerable<dynamic> Rows, string ReportSysName, string ReportName, string ServerName, string ReportsFolder)
        {
            string fileName = $"{ServerName} {ReportName} {DateTime.Now.ToString().Replace(":", "")}.xlsx";
            int startRow = 1, startColumn = 1;

            ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorkbook excelWorkbook = excelPackage.Workbook;
            ExcelWorksheet excelWorksheet;


            return await Task.Run(() =>
            {
                try
                {
                    string yesLabel = "True";
                    string noLabel = "False";

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
    }
}
