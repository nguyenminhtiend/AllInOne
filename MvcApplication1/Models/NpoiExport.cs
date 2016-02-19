using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;


namespace MvcApplication1.Models
{
    public class NpoiExport
    {
        public static HSSFWorkbook GetWorkbook()
        {
            // Create a new workbook and a sheet named "User Accounts"
            var workbook = new HSSFWorkbook();

            var detailSubtotalCellStyle = CellStyle(workbook);

            var sheet = workbook.CreateSheet("User Accounts");

            // Add header labels
            var rowIndex = 0;
            var row = sheet.CreateRow(rowIndex);

            var cell = row.CreateCell(0);
            cell.SetCellValue("User Name");
            cell.CellStyle = detailSubtotalCellStyle;

            cell = row.CreateCell(1);
            cell.SetCellValue("Email");
            cell.CellStyle = detailSubtotalCellStyle;
            rowIndex++;
            // Add data rows
            for (int i = 0; i < 10; i++)
            {
                row = sheet.CreateRow(rowIndex);
                row.CreateCell(0).SetCellValue("gasga");
                row.CreateCell(1).SetCellValue("gsdgd");
                rowIndex++;
            }

            // Save the Excel spreadsheet to a file on the web server's file system
            workbook.Write(new MemoryStream());
            return workbook;
        }

        private static ICellStyle CellStyle(HSSFWorkbook workbook)
        {
            var cellStyleHeader = workbook.CreateCellStyle();

            var boldFront = workbook.CreateFont();
            boldFront.Boldweight = (short) FontBoldWeight.Bold;
            cellStyleHeader.SetFont(boldFront);

            return cellStyleHeader;
        }
    }
}