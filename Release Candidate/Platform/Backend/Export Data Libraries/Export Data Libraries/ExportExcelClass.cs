using System;
using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.libraries.ExportData
{
    public class ExportExcelClass
    {
        public ExportExcelClass()
        {
        }

        public void ExportDataTable(DataTable table, string exportFile)
        {
            // Create a spreadsheet document by supplying the filepath.
            // By default, AutoSave = true, Editable = true, and Type = xlsx.
            SpreadsheetDocument spreadsheetDocument = spreadsheetDocument.Create(exportFile, SpreadsheetDocumentType.Workbook);

            // Add a WorkbookPart to the document.
            WorkbookPart workbook = spreadsheetDocument.AddWorkbookPart;
            workbook.Workbook = new Workbook();

            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart Worksheet = workbook.AddNewPart<WorksheetPart>();
            Worksheet.Worksheet = new Worksheet(new SheetData());

            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
            SheetData data = Worksheet.Worksheet.GetFirstChild<SheetData>();
            var Header = new Row();
            Header.RowIndex = Conversions.ToUInteger(1);
            foreach (DataColumn column in table.Columns)
            {
                var headerCell = createTextCell(table.Columns.IndexOf(column) + 1, 1, column.ColumnName);
                Header.AppendChild(headerCell);
            }

            data.AppendChild(Header);
            DataRow contentRow;
            for (int i = 0, loopTo = table.Rows.Count - 1; i <= loopTo; i++)
            {
                contentRow = table.Rows[i];
                data.AppendChild(createContentRow(contentRow, i + 2));
            }
        }

        private Cell createTextCell(int columnIndex, int rowIndex, object cellValue)
        {
            var cell = new Cell();
            cell.DataType = CellValues.InlineString;
            cell.CellReference = getColumnName(columnIndex) + rowIndex.ToString();
            var inlineString = new InlineString();
            var t = new System.Text();
            t.Text = cellValue.ToString();
            inlineString.AppendChild(t);
            cell.AppendChild(inlineString);
            return cell;
        }

        private Row createContentRow(DataRow dataRow, int rowIndex)
        {
            var row = new Row() { rowIndex = Conversions.ToUInteger(rowIndex) };
            for (int i = 0, loopTo = dataRow.Table.Columns.Count - 1; i <= loopTo; i++)
            {
                var dataCell = createTextCell(i + 1, rowIndex, dataRow[i]);
                row.AppendChild(dataCell);
            }

            return row;
        }

        private string getColumnName(int columnIndex)
        {
            int dividend = columnIndex;
            string columnName = string.Empty;
            int modifier;
            while (dividend > 0)
            {
                modifier = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modifier).ToString() + columnName;
                dividend = Conversions.ToInteger((dividend - modifier) / (double)26);
            }

            return columnName;
        }
    }
}