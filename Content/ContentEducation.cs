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
    public class ContentEducation
    {
        class Education 
        {
            public string Degree;
            public string Date;
            public string Organization;
            public string Location;
            public string Major;

            public Education(API.XmlTag input)
            {
                foreach (XmlTag item in input.Childs)
                {
                    if (item.Name == "degree") Degree = item.Text;
                    if (item.Name == "date") Date = item.Text;
                    if (item.Name == "organization") Organization = item.Text;
                    if (item.Name == "location") Location = item.Text;
                    if (item.Name == "major") Major = item.Text;
                }
            }

            public TableRow GetTitleAndDate(DocumentCore docx)
            {
                TableCell cellTitle = new TableCell(docx) { };
                cellTitle.CellFormat.PreferredWidth = new TableWidth(67, TableWidthUnit.Percentage);
                cellTitle.Blocks.Add(Template.CreateParagraph(docx, Degree, Template.FormatTitle));

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

                cell.Blocks.Add(Template.CreateParagraph(docx, Ult.GetOgr(Organization, Location), Template.FormatOganization));
                
                if (Major != null)
                {
                    cell.Blocks.Add(Template.CreateParagraph(docx, Major, Template.FormatNormal));
                }
                table.Rows.Add(new TableRow(docx, cell));


                return table;
            }
        }

        List<Education> education = new List<Education>();

        public ContentEducation(List<XmlTag> input, byte[] config)
        {
            for (var i = input.Count - 1; i >= 0; i--)
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
                    education.Add(new Education(input[i]));
                }
            }
        }

        public List<TableRow> Content(DocumentCore docx)
        {

            List<TableRow> rows = new List<TableRow>();

            foreach (Education item in education)
            {
                TableCell cell = new TableCell(docx, item.GetContent(docx));
                cell.CellFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
                cell.ColumnSpan = 2;
                rows.Add(new TableRow(docx, cell));
            }

            return rows;
        }
    }
}
