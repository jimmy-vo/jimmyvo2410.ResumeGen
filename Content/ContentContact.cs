using SautinSoft.Document;
using SautinSoft.Document.Drawing;
using SautinSoft.Document.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    public class ContentContact
    {
        class Contact
        {
            public string Text;
            public string Link;
            public string Image;

            public Contact(XmlTag input)
            {
                foreach (XmlTag item in input.Childs)
                {
                    if (item.Name == "text") Text = item.Text;
                    if (item.Name == "link") Link = item.Text;
                    if (item.Name == "image") Image = item.Text;
                }
            }

            public Paragraph GetContent (DocumentCore docx)
            {
                Paragraph p = new Paragraph(docx, new Picture(docx, new InlineLayout(new Size(0.18f, 0.18f, LengthUnit.Inch)), Template.PathImage + Image));
                p.Inlines.Content.End.Insert("  ");
                p.ParagraphFormat = Template.FormatNormal.pFormat.Clone();
            

                if (Link != null)
                {
                    Hyperlink hpl = new Hyperlink(docx, Link, Text);
                    (hpl.DisplayInlines[0] as Run).CharacterFormat = Template.FormatLink.cFormat.Clone();

                    p.Inlines.Add(hpl);
                }
                else
                {
                    p.Content.End.Insert(Text, Template.FormatNormal.cFormat.Clone());
                }
                return p;
            }
        }

        private List<Contact> contacts = new List<Contact>();


        public ContentContact (List<XmlTag> input)
        {        
            foreach (XmlTag item in input)                contacts.Add(new Contact(item));  
        }

        public TableRow Content(DocumentCore docx)
        {
            Table table = new Table(docx);
            table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);

            TableRow[] row = new TableRow[2];
            for (int r = 0; r < 2; r++)
            {
                row[r] = new TableRow(docx);
                for (int c = 0; c < 3; c++)
                {
                    TableCell subCell = new TableCell(docx);
                    subCell.CellFormat.Borders.SetBorders(MultipleBorderTypes.None, BorderStyle.None, Color.Auto, 0);
                    subCell.CellFormat.PreferredWidth = new TableWidth(35, TableWidthUnit.Percentage);
                    subCell.Blocks.Add(contacts[r*3 + c].GetContent(docx));
                    subCell.ColumnSpan = 1;

                    row[r].Cells.Add(subCell);
                }
                table.Rows.Add(row[r]);
            }

            TableCell cell = new TableCell(docx, table);
            cell.CellFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
            cell.ColumnSpan = 2;

            return new TableRow(docx, cell);

        }
    }
}
