using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadRtfFromFile();
            //LoadRtfFromStream();
        }

        // From a file
        static void LoadRtfFromFile()
        {
            string filePath = @"..\..\..\..\..\..\Testing Files\example.rtf";
            // The file format is detected automatically from the file extension: ".rtf".
            // But as shown in the example below, we can specify RtfLoadOptions as 2nd parameter
            // to explicitly set that a loadable document has RTF format.
            DocumentCore dc = DocumentCore.Load(filePath);
        }

        // From a Stream
        static void LoadRtfFromStream()
        {
            // Get document bytes.
            byte[] fileBytes = File.ReadAllBytes(@"..\..\..\..\..\..\Testing Files\example.rtf");

            DocumentCore dc = null;
            // Create a MemoryStream
            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                // Load a document from the MemoryStream.
                // Specifying RtfLoadOptions we explicitly set that a loadable document is RTF.
                dc = DocumentCore.Load(ms, new RtfLoadOptions());
            }
        }
    }
}