using System.Linq;
using SautinSoft.Document;

namespace Example
{
    class Sample
    {
        static void Main(string[] args)
        {
            TOC_Update();
        }

        public static void TOC_Update()
        {

            // Let's create a simple document.
            DocumentCore dc = new DocumentCore();
            // DocumentCore.Serial = "put your serial here";

            //It's easy to load any document.
            dc = DocumentCore.Load(@"..\..\..\..\..\..\Testing Files\toc.docx");

            // Update TOC (TOC can be updated only after all document content is added).
            var toc = (TableOfEntries)dc.GetChildElements(true, ElementType.TableOfEntries).FirstOrDefault();
            toc.Update();

            // Update TOC's page numbers.
            // Page numbers are automatically updated in that case.
            dc.GetPaginator(new PaginatorOptions() { UpdateFields = true });

            // Save DOCX to a file
            dc.Save(@"..\..\..\..\..\..\Testing Files\TOC_Updated.docx");
            ShowResult(@"..\..\..\..\..\..\Testing Files\TOC_Updated.docx");
        }

        static void ShowResult(string filename)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
            System.Diagnostics.Process.Start(psi);
        }
    }
}