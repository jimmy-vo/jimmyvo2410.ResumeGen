using System.IO;
using SautinSoft.Document;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sample
{
    class Sample
    {
       
        static void Main(string[] args)
        {
            FindAndReplace();
        }
        
        public static void FindAndReplace()
        {
            // Path to a loadable document.
            string loadPath = @"..\..\..\..\..\..\Testing Files\critique.docx";

            // Load a document intoDocumentCore.
            DocumentCore dc = DocumentCore.Load(loadPath);

            Regex regex = new Regex(@"bean", RegexOptions.IgnoreCase);

            //Find "Bean" and Replace everywhere on "Joker :-)"
            // Please note, Reverse() makes sure that action replace not affects to Find().
            foreach (ContentRange item in dc.Content.Find(regex).Reverse())
            {
                item.Replace("Joker");
            }

            // Save our document into PDF format.
            string savePath = Path.ChangeExtension(loadPath, ".replaced.pdf");
            dc.Save(savePath, new PdfSaveOptions());

            // Open the result for demonstation purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(savePath) { UseShellExecute = true });
        }
    }
}