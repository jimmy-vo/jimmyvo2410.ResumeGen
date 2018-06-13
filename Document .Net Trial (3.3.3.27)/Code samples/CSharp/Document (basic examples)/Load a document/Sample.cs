using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadFromFile();
        }

        // From a file
        static void LoadFromFile()
        {
            string filePath = @"..\..\..\..\..\..\Testing Files\example.docx";
            // The file format is detected automatically from the file extension: ".docx".
            // But as shown in the example below, we can specify DocxLoadOptions as 2nd parameter
            // to explicitly set that a loadable document has Docx format.
            DocumentCore dc = DocumentCore.Load(filePath);
        }

        // From a Stream
        static void LoadFromStream()
        {
            // We've knowingly created an empty DocumentCore instance before "Using {}"
            // to continue work with it after stream will be closed.
            DocumentCore dc = null;
            using (FileStream fs = new FileStream(@"..\..\..\..\..\..\Testing Files\example.docx", FileMode.Open))
            {
                // Here we explicitly set that a loadable document is Docx.
                dc = DocumentCore.Load(fs, new DocxLoadOptions());
            }
        }

        // From an array of bytes
        static void LoadFromBytes()
        {
            // Get document bytes from a file.
            byte[] fileBytes = File.ReadAllBytes(@"..\..\..\..\..\..\Testing Files\example.pdf");

            DocumentCore dc = null;
            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                // With PdfLoadOptions we explicitly set that a loadable document is PDF.
                PdfLoadOptions pdfLO = new PdfLoadOptions()
                {
                    // Leave a vector graphics as is.
                    RasterizeVectorGraphics = false,
                    // Load only first 2 pages from document.
                    PageCount = 2
                };
                dc = DocumentCore.Load(ms, pdfLO);
            }
        }
    }
}