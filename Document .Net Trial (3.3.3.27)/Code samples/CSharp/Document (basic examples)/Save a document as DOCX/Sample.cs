using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveToDocxFile();
            SaveToDocxStream();
        }

        static void SaveToDocxFile()
        {
            // Assume we already have a document 'dc'.
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hey Guys and Girls!");

            string filePath = @"Result-file.docx";

            dc.Save(filePath, new DocxSaveOptions());
        }

        static void SaveToDocxStream()
        {
            // There variables are necessary only for demonstration purposes.
            byte[] fileData = null;
            string filePath = @"Result-stream.docx";

            // Assume we already have a document 'dc'.
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hey Guys and Girls!");

            // Let's save our document to a MemoryStream.
            using (MemoryStream ms = new MemoryStream())
            {
                dc.Save(ms, new DocxSaveOptions());
                fileData = ms.ToArray();
            }
            File.WriteAllBytes(filePath, fileData);
        }
    }
}