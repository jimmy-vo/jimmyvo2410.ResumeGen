using System.IO;
using System.Linq;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        
        static void Main(string[] args)
        {
            DeleteContent();
        }

        // Open a document and delete some content.
        public static void DeleteContent()
        {
            string loadPath = @"..\..\..\..\..\..\Testing Files\example.docx";
            string savePath = Path.ChangeExtension(loadPath, ".result.docx");

            DocumentCore dc = DocumentCore.Load(loadPath);

            // Remove the text "This" from all paragraphs in 1st section.
            foreach (Paragraph par in dc.Sections[0].GetChildElements(true, ElementType.Paragraph))
            {
                var findText = par.Content.Find("This");

                if (findText != null)
                {
                    foreach (ContentRange cr in findText)
                        cr.Delete();
                }
            }
            dc.Save(savePath);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(loadPath) { UseShellExecute = true });
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(savePath) { UseShellExecute = true });

        }
    }
}