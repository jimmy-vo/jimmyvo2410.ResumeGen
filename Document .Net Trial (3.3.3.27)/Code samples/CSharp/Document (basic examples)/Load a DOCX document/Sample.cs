using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadDocxFromFile();
            //LoadDocxFromStream();
        }

        // From a file
        static void LoadDocxFromFile()
        {
            string filePath = @"..\..\..\..\..\..\Testing Files\example.docx";
            // The file format is detected automatically from the file extension: ".docx".
            // But as shown in the example below, we can specify DocxLoadOptions as 2nd parameter
            // to explicitly set that a loadable document has Docx format.
            DocumentCore dc = DocumentCore.Load(filePath);
        }

        // From a Stream
        static void LoadDocxFromStream()
        {
            // Assume that we already have a DOCX document as bytes array.
            byte[] fileBytes = File.ReadAllBytes(@"..\..\..\..\..\..\Testing Files\example.docx");

            DocumentCore dc = null;
            // Create a MemoryStream
            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                // Load a document from the MemoryStream.
                // Specifying DocxLoadOptions we explicitly set that a loadable document is Docx.
                dc = DocumentCore.Load(ms, new DocxLoadOptions());
            }
        }
    }
}