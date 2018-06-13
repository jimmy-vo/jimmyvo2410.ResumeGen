using SautinSoft.Document;
using SautinSoft.Document.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ContentName
    {
        public TableRow Content(DocumentCore docx)
        {
            TableCell cell = new TableCell(docx, Template.CreateParagraph(docx, "DUY (JIMMY) NGUYEN VO", Template.FormatName));
            cell.CellFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
            cell.ColumnSpan = 2;
            return  new TableRow (docx, cell);
        }
    }
}
