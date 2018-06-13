using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDocx();
        }

        public static void CreateDocx()
        {
            // Set a path to our docx file.
            string docxPath = @"Result.docx";

            // Let's create a simple document.
            DocumentCore dc = new DocumentCore();
            //DocumentCore.Serial = "put your serial here";

            // Add new section.
            Section section = new Section(dc);
            dc.Sections.Add(section);

            // Let's set page size A4.
            section.PageSetup.PaperType = PaperType.A4;

            // Add two paragraphs using different ways:

            // Way 1: Add 1st paragraph.
            Paragraph par1 = new Paragraph(dc);
            par1.ParagraphFormat.Alignment = HorizontalAlignment.Center;
            section.Blocks.Add(par1);

            // Let's create a characterformat for text in the 1st paragraph.
            CharacterFormat cf = new CharacterFormat() { FontName = "Verdana", Size = 16, FontColor = Color.Orange };

            Run text1 = new Run(dc, "This is a first line in 1st paragraph!");
            text1.CharacterFormat = cf;
            par1.Inlines.Add(text1);

            // Let's add a line break into our paragraph.
            par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));

            Run text2 = text1.Clone();
            text2.Text = "Let's type a second line.";
            par1.Inlines.Add(text2);

            // Way 2 (easy): Add 2nd paragraph using ContentRange.
            dc.Content.End.Insert("\nThis is a first line in 2nd paragraph.", new CharacterFormat() { Size = 25, FontColor = Color.Blue, Bold = true });
            SpecialCharacter lBr = new SpecialCharacter(dc, SpecialCharacterType.LineBreak);
            dc.Content.End.Insert(lBr.Content);
            dc.Content.End.Insert("This is a second line.", new CharacterFormat() { Size = 20, FontColor = Color.DarkGreen, UnderlineStyle = UnderlineType.Single });

            // Save a document to a file in DOCX format.
            dc.Save(docxPath, new DocxSaveOptions());
            ShowResult(docxPath);
        }

        static void ShowResult(string filename)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
            System.Diagnostics.Process.Start(psi);
        }
    }
}