using SautinSoft.Document;
using SautinSoft.Document.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ContentSummary
    {
        class Summary
        {
            public string Text;

            public Summary(XmlTag input)
            {
                if (input.Name.Equals("bullet")) Text = input.Text;
            }

            public Paragraph GetContent(DocumentCore docx)
            {
                return Template. CreateList(docx,Text, Template.FormatNormal);
            }
        }

        List<Summary> summaries = new List<Summary>();

        public ContentSummary(List<XmlTag> input, byte[] config)
        {
            for (int i = 0; i < input.Count; i++)
            {
                bool isIgnore = false;

                foreach (byte number in config)
                {
                    if (number == i)
                    {
                        isIgnore = true;
                        break;
                    }
                }

                if (!isIgnore)
                {
                    summaries.Add(new Summary(input[i]));
                }
            }
        }


        public TableRow Content(DocumentCore docx)
        {
            TableCell cell = new TableCell(docx);
            cell.CellFormat.Borders.SetBorders(MultipleBorderTypes.None, BorderStyle.Single, Color.Black, 1);
            cell.CellFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
            cell.ColumnSpan = 2;

            foreach (Summary item in summaries)
                cell.Blocks.Add(item.GetContent(docx));

            return new TableRow(docx, cell) ;
        }


    }
}
