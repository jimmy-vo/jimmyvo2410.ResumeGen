using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveToRtfFile();
            SaveToRtfStream();
        }

        static void SaveToRtfFile()
        {
            // Assume we already have a document 'dc'.
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hey Guys and Girls!");

            string filePath = @"Result-file.rtf";

            dc.Save(filePath, new RtfSaveOptions());
        }

        static void SaveToRtfStream()
        {
            // There variables are necessary only for demonstration purposes.
            byte[] fileData = null;
            string filePath = @"Result-stream.rtf";

            // Assume we already have a document 'dc'.
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hey Guys and Girls!");

            // Let's save our document to a MemoryStream.
            using (MemoryStream ms = new MemoryStream())
            {
                dc.Save(ms, new RtfSaveOptions());
                fileData = ms.ToArray();
            }
            File.WriteAllBytes(filePath, fileData);
        }
    }
}