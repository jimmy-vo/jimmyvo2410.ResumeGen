using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            AddBookmarks();
        }
        
        // How add a text bounded by BookmarkStart and BookmarkEnd.
        public static void AddBookmarks()
        {

            // P.S. If you are using MS Word, to display bookmarks:
            // File -> Options -> Advanced -> On the "Show document content" check "Show bookmarks".
            string documentPath = @"Bookmarks.docx";

            // Let's create a new document.
            DocumentCore dc = new DocumentCore();

            // Add text bounded by BookmarkStart and BookmarkEnd.
            dc.Sections.Add(
            new Section(dc,
                new Paragraph(dc,
                new Run(dc, "Text before bookmark. "),
                new BookmarkStart(dc, "Simple Bookmark"),
                new Run(dc, "Text inside bookmark."),
                new BookmarkEnd(dc, "Simple Bookmark"),
                new Run(dc, " Text after bookmark."))));

            // Modify text inside bookmark.
            dc.Bookmarks["Simple Bookmark"].GetContent(false).Replace("Some text inside bookmark.");

            // Let's save our document into DOCX format.
            dc.Save(documentPath);

            // Open the result for demonstation purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(documentPath) { UseShellExecute = true });
        }
    }
}