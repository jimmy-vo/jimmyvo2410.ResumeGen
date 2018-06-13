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
    public class ContentAwards
    {
        class Award
        {
            public string Title;
            public string Date;
            public string Organization;
            public string Location;
            public string Description;

            public Award(API.XmlTag input)
            {
                foreach (XmlTag item in input.Childs)
                {
                    if (item.Name == "title") Title = item.Text;
                    if (item.Name == "date") Date = item.Text;
                    if (item.Name == "organization") Organization = item.Text;
                    if (item.Name == "location") Location = item.Text;
                    if (item.Name == "description") Description = item.Text;
                }
            }
            
            public TableRow GetTitleAndDate(DocumentCore docx)
            {
                TableCell cellTitle = new TableCell(docx) { };
                cellTitle.CellFormat.PreferredWidth = new TableWidth(67, TableWidthUnit.Percentage);
                cellTitle.Blocks.Add(Template.CreateParagraph(docx, Title, Template.FormatTitle));

                TableCell cellDate = new TableCell(docx);
                cellDate.CellFormat.PreferredWidth = new TableWidth(33, TableWidthUnit.Percentage);
                cellDate.Blocks.Add(Template.CreateParagraph(docx, Date, Template.FormatDate));

                return new TableRow(docx, cellTitle, cellDate);
            }

            public Table GetContent(DocumentCore docx)
            {
                Table table = new Table(docx);
                table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);

                table.Rows.Add(GetTitleAndDate(docx));

                TableCell cell = new TableCell(docx) { ColumnSpan = 2 };

                cell.Blocks.Add(Template.CreateParagraph(docx, Ult.GetOgr(Organization , Location), Template.FormatOganization));

                if (Description != null)
                {
                    cell.Blocks.Add(Template.CreateParagraph(docx, Description, Template.FormatNormal));
                }
                table.Rows.Add(new TableRow(docx, cell));


                return table;
            }
        }

        List<Award> awards = new List<Award>();

        public ContentAwards(List<XmlTag> input)
        {
            foreach (XmlTag item in input) awards.Add(new Award(item));
        }

        public List<TableRow> Content(DocumentCore docx)
        {
            List<TableRow> rows = new List<TableRow>();

            foreach (Award item in awards)
            {
                TableCell cell = new TableCell(docx, item.GetContent(docx));
                cell.CellFormat.Borders.SetBorders(MultipleBorderTypes.None, BorderStyle.Single, Color.Black, 1);
                cell.CellFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
                cell.CellFormat.Borders.Add(MultipleBorderTypes.InsideHorizontal, BorderStyle.Single, Color.Green, 1);
                cell.ColumnSpan = 2;
                rows.Add(new TableRow(docx, cell));
            }

            return rows;
        }
    }
}
