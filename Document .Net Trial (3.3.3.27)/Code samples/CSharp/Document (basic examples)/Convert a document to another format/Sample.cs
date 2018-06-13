using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertFromFile();
            ConvertFromStream();
        }

        static void ConvertFromFile()
        {
            string inpFile = @"..\..\..\..\..\..\Testing Files\example.pdf";
            string outFile = Path.ChangeExtension(inpFile, "-Result.docx");

            DocumentCore dc = DocumentCore.Load(inpFile);
            dc.Save(outFile);

            ShowResult(outFile);
        }

        static void ConvertFromStream()
        {
            // We need files only for demonstration purposes.
            // The conversion process will be done completely in memory.
            byte[] inpData = File.ReadAllBytes(@"..\..\..\..\..\..\Testing Files\example.pdf");
            byte[] outData = null;

            using (MemoryStream msInp = new MemoryStream(inpData))
            {
                // Load a document.
                DocumentCore dc = DocumentCore.Load(msInp, new PdfLoadOptions()
                {
                    PreserveGraphics = true,
                    DetectTables = true
                });

                // Save the document to another format.
                using (MemoryStream outMs = new MemoryStream())
                {
                    dc.Save(outMs, new HtmlFixedSaveOptions()
                    {
                        CssExportMode = CssExportMode.Inline,
                        EmbedImages = true
                    });
                    outData = outMs.ToArray();
                }
            }
        }

        static void ShowResult(string filename)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
            System.Diagnostics.Process.Start(psi);
        }
    }
}