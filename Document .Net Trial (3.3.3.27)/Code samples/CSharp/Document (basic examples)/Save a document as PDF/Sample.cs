using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveToPdfFile();
            SaveToPdfStream();
        }

        static void SaveToPdfFile()
        {
            // Assume we already have a document 'dc'.
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hey Guys and Girls!");

            string filePath = @"Result-file.pdf";

            dc.Save(filePath, new PdfSaveOptions()
            {
                Compliance = PdfCompliance.PDF_A,
                PreserveFormFields = true
            });
        }

        static void SaveToPdfStream()
        {
            // There variables are necessary only for demonstration purposes.
            byte[] fileData = null;
            string filePath = @"Result-stream.pdf";

            // Assume we already have a document 'dc'.
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hey Guys and Girls!");

            // Let's save our document to a MemoryStream.
            using (MemoryStream ms = new MemoryStream())
            {
                dc.Save(ms, new PdfSaveOptions()
                {
                    PageIndex = 0,
                    PageCount = 1,
                    Compliance = PdfCompliance.PDF_A
                });
                fileData = ms.ToArray();
            }
            File.WriteAllBytes(filePath, fileData);
        }
    }
}