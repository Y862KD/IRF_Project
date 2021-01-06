using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using ShipmentTracking.Entities;

namespace ShipmentTracking
{
    public class ExcelExport
    {
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;
        string _pathPlusFileName;

        public ExcelExport(string pathPlusFilename)
        {
            _pathPlusFileName = pathPlusFilename;
        }

        public void FormatTable(string[] headers)
        {
            int lastRowID = xlSheet.UsedRange.Rows.Count;
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

        }

        public void CreateExcel(string[] headers, List<Warehouse> ShipmentPacking)
        {
            try
            {

                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                              

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

        public void CreateTable(string[] headers, List<Warehouse> ShipmentPacking)
        {
            {
                for (int i = 0; i < headers.Length; i++)
                {
                    xlSheet.Cells[1, i+1] = headers[i];
                }

                object[,] values = new object[ShipmentPacking.Count, headers.Length];

                int counter = 0;
                foreach (Warehouse f in ShipmentPacking)
                {
                    values[counter, 0] = f.CustomerCode;
                    values[counter, 1] = f.OrderNumber;
                    values[counter, 2] = f.PackageNumber;
                    values[counter, 3] = f.PickUpDate;

                    counter++;
                }

                xlSheet.get_Range(
                 GetCell(2, 1),
                 GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
                                
            }
        }
        public string GetCell(int x, int y)
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
        }

        public void Mentes()
        {
            xlWB.SaveAs(_pathPlusFileName);
            //xlWB.Close();
        }
    }
}
