using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadHtmlFromFile();
            //LoadHtmlFromStream();
        }

        // From a file
        static void LoadHtmlFromFile()
        {
            string filePath = @"..\..\..\..\..\..\Testing Files\example.html";
            // The file format is detected automatically from the file extension: ".html".
            // But as shown in the example below, we can specify HtmlLoadOptions as 2nd parameter
            // to explicitly set that a loadable document has HTML format.
            DocumentCore dc = DocumentCore.Load(filePath);
        }

        // From a Stream
        static void LoadHtmlFromStream()
        {
            // Get document bytes.
            byte[] fileBytes = File.ReadAllBytes(@"..\..\..\..\..\..\Testing Files\example.html");

            DocumentCore dc = null;
            // Create a MemoryStream
            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                // Load a document from the MemoryStream.
                // Specifying HtmlLoadOptions we explicitly set that a loadable document is HTML.
                dc = DocumentCore.Load(ms, new HtmlLoadOptions());
            }
        }
    }
}