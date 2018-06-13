using System.IO;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {

        static void Main(string[] args)
        {
            LoadAndSaveAsPDFA();
        }

        /// Load an existing document (*.docx, *.rtf, *.pdf, *.html, *.txt, *.pdf) and save it as a PDF/A compliant version.
        public static void LoadAndSaveAsPDFA()
        {
            // Path to a loadable document.
            string loadPath = @"..\..\..\..\..\..\Testing Files\example.docx";

            DocumentCore dc = DocumentCore.Load(loadPath);

            PdfSaveOptions options = new PdfSaveOptions()
            {
                // PdfComliance supports: PDF/A, PDF/1.5, etc.
                Compliance = PdfCompliance.PDF_A
            };

            string savePath = Path.ChangeExtension(loadPath, ".pdf");
            dc.Save(savePath, options);

            // Open file - example.pdf.
            ShowResult(savePath);
        }

        static void ShowResult(string filename)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
            System.Diagnostics.Process.Start(psi);
        }
    }
}