using ConsoleTableExt;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = OfficeOpenXml;

namespace RadaDBMC
{
    internal class Program
    {
        static void Main(string[] arg)
        {
            Console.Title = arg[0];

            // Получение таблицы Excel
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string path = $@"C:\Users\Node\Desktop\ExcelData\ConsoleApp1\Data.xlsx";
            Excel.ExcelPackage xlsPackage = new Excel.ExcelPackage(new FileInfo(path));
            ExcelWorksheet wsworkSheet = xlsPackage.Workbook.Worksheets[0];
            int length = wsworkSheet.Dimension.End.Row;
            ExcelRange wsRow;

            // Запись данных в Список для вывода черех ConsoleTableBuilder
            List<List<object>> table = new List<List<object>>();
            for (int i = 2; i <= length; i++)
            {
                List<object> row = new List<object>();
                wsRow = wsworkSheet.Cells[i, 1, i, wsworkSheet.Dimension.End.Column];
                foreach (var cell in wsRow)
                    row.Add($"{cell.Value}");
                table.Add(row);
            }

            // NuGet пакет для вывода таблиц в консоли
            ConsoleTableBuilder
                .From(table)
                .WithColumn("Покупатель", "Авто", "Дата покупки")
                .ExportAndWriteLine(TableAligntment.Left);
            Console.Read();
        }
    }
}
