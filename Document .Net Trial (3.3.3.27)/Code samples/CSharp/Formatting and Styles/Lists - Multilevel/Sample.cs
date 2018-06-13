using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            MultilevelLists();
        }

        /// How to create multilevel ordered and unordered lists.
        public static void MultilevelLists()
        {
            string documentPath = @"MultilvelLists.docx";

            // Let's create a new document.
            DocumentCore dc = new DocumentCore();

            // Add a new section.
            Section s = new Section(dc);
            dc.Sections.Add(s);

            string[] myCollection = new string[] { "One", "Two", "Three", "Four", "Five" };

            // Create list style.
            ListStyle ls = new ListStyle("", ListTemplateType.NumberWithDot);
            dc.Styles.Add(ls);

            // Add the collection of paragraphs marked as ordered list.
            int level = 0;
            foreach (string listText in myCollection)
            {
                Paragraph p = new Paragraph(dc);
                dc.Sections[0].Blocks.Add(p);

                p.Content.End.Insert(listText, new CharacterFormat() { Size = 14.0, FontColor = Color.Black });
                p.ListFormat.Style = ls;
                p.ListFormat.ListLevelNumber = level++;
                p.ParagraphFormat.SpaceAfter = 0;
            }

            // Add the collection of paragraphs marked as unordered list (bullets).
            // Create list style.
            ListStyle ls1 = new ListStyle("", ListTemplateType.Bullet);
            dc.Styles.Add(ls1);

            level = 0;
            foreach (string listText in myCollection)
            {
                Paragraph p = new Paragraph(dc);
                dc.Sections[0].Blocks.Add(p);

                p.Content.End.Insert(listText, new CharacterFormat() { Size = 14.0, FontColor = Color.Black });
                p.ListFormat.Style = ls1;
                p.ListFormat.ListLevelNumber = level++;
                p.ParagraphFormat.SpaceAfter = 0;
            }

            // Save our document into DOCX file.
            dc.Save(documentPath, new DocxSaveOptions());

            // Open the result for demonstation purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(documentPath) { UseShellExecute = true });
        }
    }
}