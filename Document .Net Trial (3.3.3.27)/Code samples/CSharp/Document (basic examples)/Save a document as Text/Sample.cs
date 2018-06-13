using System;
using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveToTextFile();
            SaveToTextStream();
        }

        static void SaveToTextFile()
        {
            // Assume we already have a document 'dc'.
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hey Guys and Girls!");

            string filePath = @"Result-file.txt";

            dc.Save(filePath, new TxtSaveOptions()
            {
                Encoding = System.Text.Encoding.UTF8,
                ParagraphBreak = Environment.NewLine
            });
        }

        static void SaveToTextStream()
        {
            // There variables are necessary only for demonstration purposes.
            byte[] fileData = null;
            string filePath = @"Result-stream.txt";

            // Assume we already have a document 'dc'.
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hey Guys and Girls!");

            // Let's save our document to a MemoryStream.
            using (MemoryStream ms = new MemoryStream())
            {
                dc.Save(ms, new TxtSaveOptions());
                fileData = ms.ToArray();
            }
            File.WriteAllBytes(filePath, fileData);
        }
    }
}