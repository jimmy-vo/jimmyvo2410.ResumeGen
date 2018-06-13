using System;
using System.Collections.Generic;
using System.Linq;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            AddPageNumbering();
            DeletePageNumbering();
        }

        // How to add a page numbering in a document.
        public static void AddPageNumbering()
        {
            string documentPath = @"PageNumbering.docx";

            // Let's create a new document with multiple pages.
            DocumentCore dc = new DocumentCore();

            string[] pagesText = new string[] { "One", "Two", "Three", "Four", "Five" };
            Random r = new Random();

            // Create a new section.
            Section section = new Section(dc);
            dc.Sections.Add(section);

            // We place our page numbers into the footer.
            // Therefore we've to create a footer.
            HeaderFooter footer = new HeaderFooter(dc, HeaderFooterType.FooterDefault);

            // Create a new paragraph to insert a page numbering.
            // So that, our page numbering looks as: Page N of M.
            Paragraph par = new Paragraph(dc);
            par.ParagraphFormat.Alignment = HorizontalAlignment.Center;
            CharacterFormat cf = new CharacterFormat() { FontName = "Arial", Size = 12.0 };
            par.Content.Start.Insert("Page ", cf.Clone());

            // Page numbering is a Field.
            // Create two fields: FieldType.Page and FieldType.NumPages.
            Field fPage = new Field(dc, FieldType.Page);
            fPage.CharacterFormat = cf.Clone();
            par.Content.End.Insert(fPage.Content);
            par.Content.End.Insert(" of ", cf.Clone());
            Field fPages = new Field(dc, FieldType.NumPages);
            fPages.CharacterFormat = cf.Clone();
            par.Content.End.Insert(fPages.Content);

            // Add the paragraph with Fields into the footer.
            footer.Blocks.Add(par);

            // Add the footer into the section.
            section.HeadersFooters.Add(footer);

            // Add some paragraphs with page breaks in the document,
            // to make several pages.
            foreach (string text in pagesText)
            {
                Paragraph p = new Paragraph(dc);
                p.ParagraphFormat.Alignment = HorizontalAlignment.Center;
                section.Blocks.Add(p);

                int color = r.Next(0x000000, 0xFFFFFF);
                p.Content.Start.Insert(text, new CharacterFormat() { FontName = "Arial", Size = 72.0, FontColor = new Color(color) });
                p.Content.End.Insert(new SpecialCharacter(dc, SpecialCharacterType.PageBreak).Content);
            }

            // Save our document into DOCX file.
            dc.Save(documentPath);

            // Open the result for demonstation purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(documentPath) { UseShellExecute = true });
        }

        // How to delete the page numbering from an existing document.
        public static void DeletePageNumbering()
        {
            string sourcePath = @"PageNumbering.docx";
            string destPath = @"PageNumbering - deleted.docx";

            // Load a document from DOCX file (PageNumbering.docx).
            // We've created PageNumbering.docx in the previous example.
            DocumentCore dc = DocumentCore.Load(sourcePath);
            Section s = dc.Sections[0];

            foreach (HeaderFooter hf in s.HeadersFooters)
            {
                foreach (Field field in hf.GetChildElements(true, ElementType.Field).Reverse())
                {
                    // Page numbering is a Field,
                    // so we have to find the fields with the type Page or NumPages and remove.
                    if (field.FieldType == FieldType.Page || field.FieldType == FieldType.NumPages)
                    {
                        // Also assume that our page numbering located in a paragraph,
                        // so let's remove the paragraph's content too.
                        if (field.Parent is Paragraph)
                            (field.Parent as Paragraph).Inlines.Clear();

                        // If we'll delete only the fields (field.Content.Delete()), our paragraph
                        // may contain text "Page of ".
                        // Based on this, we remove the whole paragraph.
                    }
                }
            }
            dc.Save(destPath);

            // Open the result for demonstation purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(destPath) { UseShellExecute = true });
        }
    }
}