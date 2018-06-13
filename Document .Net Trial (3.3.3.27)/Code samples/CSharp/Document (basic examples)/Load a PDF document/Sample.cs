using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadPDFFromFile();
            //LoadPDFFromStream();
        }

        // From a file
        static void LoadPDFFromFile()
        {
            string filePath = @"..\..\..\..\..\..\Testing Files\example.pdf";
            // The file format is detected automatically from the file extension: ".pdf".
            // But as shown in the example below, we can specify PdfLoadOptions as 2nd parameter
            // to explicitly set that a loadable document has PDF format.
            DocumentCore dc = DocumentCore.Load(filePath);
        }

        static void LoadPDFFromStream()
        {
            // Assume that we already have a PDF document as bytes array.
            byte[] fileBytes = File.ReadAllBytes(@"..\..\..\..\..\..\Testing Files\example.pdf");

            DocumentCore dc = null;
            // Create a MemoryStream
            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                // Specifying PdfLoadOptions we explicitly set that a loadable document is PDF.
                // Also we specified here to load only 1st page and
                // switched off the 'OptimizeImage' to not merge adjacent images into a one.
                PdfLoadOptions pdfLO = new PdfLoadOptions()
                {
                    PageCount = 1,
                    OptimizeImages = false
                };

                // Load a PDF document from the MemoryStream.
                dc = DocumentCore.Load(ms, new PdfLoadOptions());
            }
        }
    }
}