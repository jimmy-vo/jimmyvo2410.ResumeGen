using SautinSoft.Document;
using SautinSoft.Document.Drawing;
using SautinSoft.Document.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ContentSkill
    {
        public static int breakNumber = 2;
        class Skill
        {
            public string Title;
            public List<string> Description = new List<string>();

            public Skill(API.XmlTag input)
            {
                foreach (XmlTag item in input.Childs)
                {
                    if (item.Name == "topic") Title = item.Text;
                    if (item.Name == "bullet") Description.Add(item.Text);
                }
            }
                        
            public Table GetDescription(DocumentCore docx)
            {
                Table table = new Table(docx);
                table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);

                TableRow row = new TableRow(docx);
                TableCell cell = new TableCell(docx);
                cell.CellFormat.Borders.SetBorders(MultipleBorderTypes.None, BorderStyle.Single, Color.Black, 1);
                cell.CellFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
                cell.ColumnSpan = 3;

                foreach (String item in Description)
                    cell.Blocks.Add(Template.CreateList(docx, item, Template.FormatNormal));

                row.Cells.Add(cell);
                table.Rows.Add(row);

                return table;

            }

            public Table GetContent(DocumentCore docx)
            {
                Block content = null;
                Table table = new Table(docx);
                table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);


                table.Rows.Add(new TableRow(docx, new TableCell(docx, Template.CreateParagraph(docx, Title, Template.FormatTitle))));

                if ((content = GetDescription(docx)) != null)
                {
                    table.Rows.Add(new TableRow(docx, new TableCell(docx, content)));
                }


                return table;
            }
        }

        List<Skill> skills = new List<Skill>();

        public ContentSkill(List<XmlTag> input, byte[] config)
        {
            foreach (int i in config)
            {               
                skills.Add(new Skill(input[i]));
            }
        }

        public List<Table> Content(DocumentCore docx)
        {
            List<Table> tables = new List<Table>();
            foreach (Skill item in skills)
            {
                TableCell cell = new TableCell(docx, item.GetContent(docx));
                cell.CellFormat.PreferredWidth = new TableWidth(50, TableWidthUnit.Percentage);
                cell.ColumnSpan = 2;
                tables.Add(new Table(docx, new TableRow(docx, cell)));
            }

            return tables;

        }
    }
}
