using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;       //microsoft Excel 14 object in references-> COM tab
using System.Collections.Generic;
using OfficeOpenXml;

namespace FileCompareTool
{
    class ExcelFile : IDisposable
    {
        private ExcelPackage _package;
        private ExcelWorksheet _worksheet;
        public IList<string> SheetNames { get; }
        public string CurrentSheetName
        {
            get { return _worksheet.Name; }
            set { _worksheet = _package.Workbook.Worksheets[value]; }
        }

        public ExcelFile(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            SheetNames = new List<string>();
            _package = new ExcelPackage(file);
            foreach (var sheet in _package.Workbook.Worksheets)
            {
                SheetNames.Add(sheet.Name);
            }
            CurrentSheetName = SheetNames[0];
        }

        public string[,] GetExcelFile(string filepath)
        {
            string[,] retArray = new string[_worksheet.Dimension.Rows, _worksheet.Dimension.Columns];
            for (int i = 1; i <= _worksheet.Dimension.Rows; i++)
            {
                for (var j = 1; j <= _worksheet.Dimension.Columns; j++)
                {
                    retArray[i-1, j-1] = _worksheet.Cells[i, j].Text.Trim();
                }
            }
            return retArray;
        }

        public static string[] GetRow(string[,] multidimArray, int wanted_row)
        {
            int l = multidimArray.GetLength(1);
            string[] rowArray = new string[l];
            for (int i = 0; i < l; i++)
            {
                rowArray[i] = multidimArray[wanted_row, i];
            }
            return rowArray;
        }

        public void Dispose()
        {
            _package?.Dispose();
            _package = null;
            GC.SuppressFinalize(this);
        }
    }
}
