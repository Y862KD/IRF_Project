using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Windows.Forms;

namespace ShipmentTracking
{
    public class ExcelExport
    {
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;

        public ExcelExport()
        {
            CreateExcel();
            FormatTable();
        }

        private void FormatTable()
        {
            /*int lastRowID = xlSheet.UsedRange.Rows.Count;
            int lastColumnID = xlSheet.UsedRange.Columns.Count;

            Excel.Range headerRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));
            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.EntireColumn.AutoFit();
            headerRange.RowHeight = 40;
            headerRange.Interior.Color = Color.LightBlue;
            headerRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            Excel.Range tableRange = xlSheet.get_Range(GetCell(1, 1), GetCell(lastRowID, lastColumnID));
            tableRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            Excel.Range firstColumnRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, lastColumnID));
            firstColumnRange.Font.Bold = true;
            firstColumnRange.Interior.Color = Color.LightYellow;

            Excel.Range lastColumnRange = xlSheet.get_Range(GetCell(1, lastColumnID), GetCell(lastRowID, lastColumnID));
            lastColumnRange.Interior.Color = Color.LightGreen;
            lastColumnRange.NumberFormat = "#,##0.00";*/
        }

        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;

                CreateTable();

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {

                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        private void CreateTable()
        {
            throw new NotImplementedException();
        }

        /*private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }*/
    }
}
