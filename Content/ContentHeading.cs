using SautinSoft.Document;
using SautinSoft.Document.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ContentHeading
    {
        public TableRow Content(DocumentCore docx, String text)
        {
            TableCell cell = new TableCell(docx, Template.CreateParagraph(docx, text, Template.FormatHeading));
            cell.CellFormat.Borders.SetBorders(MultipleBorderTypes.Top | MultipleBorderTypes.Bottom, BorderStyle.Single, Color.Black, 2);
            cell.ColumnSpan = 2;
            return new TableRow(docx, cell);
        }
    }
}
