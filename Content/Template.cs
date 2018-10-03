using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public static class Template
    {
        public static string PathXml = "~/../../../../../jimmyvo2410.github.io/xml/profile.xml";
        public static string PathImage = "~/../../../../../jimmyvo2410.github.io/images/";
        public static string PathOutput = "~/../../../../../jimmyvo2410.github.io/file/Resume.docx";

        public  class Formatt 
        {
            public CharacterFormat cFormat;
            public ParagraphFormat pFormat;
        }


        public static Formatt FormatLink = new Formatt()
        {
            cFormat = new CharacterFormat() { Size = 11, FontName = "Calibri (Body)", FontColor = Color.Black, UnderlineStyle = UnderlineType.Single, },
            pFormat = new ParagraphFormat() { Alignment = HorizontalAlignment.Left, SpaceAfter = .25f, SpaceBefore = 0 }
        };

        public static Formatt FormatNormal = new Formatt()
        {
            cFormat = new CharacterFormat() { Size = 11, FontName = "Calibri (Body)", FontColor = Color.Black, },
            pFormat = new ParagraphFormat() { Alignment = HorizontalAlignment.Left, SpaceAfter = .25f, SpaceBefore = 0 }
        };



        public static Formatt FormatName = new Formatt()
        {
            cFormat = new CharacterFormat() { Size = 16, FontName = "Calibri (Body)", FontColor = Color.Black,  Bold = true },
            pFormat = new ParagraphFormat() { Alignment = HorizontalAlignment.Center, SpaceAfter = 15, SpaceBefore = 0 }
        };

        public static Formatt FormatHeading = new Formatt()
        {
            cFormat = new CharacterFormat() { Size = 11, FontName = "Calibri (Body)", FontColor = Color.Black,  Bold = true },
            pFormat = new ParagraphFormat() { Alignment = HorizontalAlignment.Left, SpaceAfter = 1, SpaceBefore = 1 }
        };

        public static Formatt FormatDate = new Formatt()
        {
            cFormat = new CharacterFormat() { Size = 11, FontName = "Calibri (Body)", FontColor = Color.Black, Italic = true },
            pFormat = new ParagraphFormat() { Alignment = HorizontalAlignment.Right, SpaceAfter = 0, SpaceBefore = 4 }
        };

        public static Formatt FormatTitle = new Formatt()
        {
            cFormat = new CharacterFormat() { Size = 12, FontName = "Calibri (Body)", FontColor = Color.Black, Bold = true },
            pFormat = new ParagraphFormat() { Alignment = HorizontalAlignment.Left, SpaceAfter = 1, SpaceBefore = 4 }
        };

        public static Formatt FormatOganization = new Formatt()
        {
            cFormat = new CharacterFormat() { Size = 11, FontName = "Calibri (Body)", FontColor = Color.Black,  Italic = true},
            pFormat = new ParagraphFormat() { Alignment = HorizontalAlignment.Left, SpaceAfter = 1, SpaceBefore = 0, LeftIndentation = 15 }
        };

        public static Formatt FormatLineBreak = new Formatt()
        {
            cFormat = new CharacterFormat() { Size = 5, FontName = "Calibri (Body)", FontColor = Color.Black, },
            pFormat = new ParagraphFormat() { Alignment = HorizontalAlignment.Left, SpaceAfter = 0, SpaceBefore = 0 }
        };
        public static ListStyle StyleBullet = new ListStyle("Simple Numbers", ListTemplateType.Bullet);


        public static Paragraph CreateList(DocumentCore docx, string text, Formatt format)
        {
            Paragraph p = new Paragraph(docx);
            p.ParagraphFormat = format.pFormat.Clone();
            p.Content.Start.Insert(text, format.cFormat.Clone());
            p.ListFormat.Style = Template.StyleBullet;
            p.ParagraphFormat.LeftIndentation = 15;
            p.ParagraphFormat.SpecialIndentation = -10;
            return p.Clone(true);
        }

        public static Paragraph CreateParagraph(DocumentCore docx, string text, Formatt format)
        {
            List<Paragraph> ps = new List<Paragraph>();
            Paragraph p = new Paragraph(docx);
            p.ParagraphFormat = format.pFormat.Clone();
            p.Content.Start.Insert(text, format.cFormat.Clone());
            return p.Clone(true);
        }

        public static Paragraph LineBreak(DocumentCore docx)
        {

            Paragraph p = new Paragraph(docx, " ");
            p.ParagraphFormat = FormatLineBreak.pFormat.Clone();
            p.CharacterFormatForParagraphMark = FormatLineBreak.cFormat.Clone();
            return p.Clone(true);
        }

    }
}
