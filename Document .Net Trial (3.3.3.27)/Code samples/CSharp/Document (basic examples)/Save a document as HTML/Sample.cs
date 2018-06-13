using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveToHtmlFile();
            SaveToHtmlStream();
        }

        static void SaveToHtmlFile()
        {
            // Assume we already have a document 'dc'.
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hey Guys and Girls!");

            string fileHtmlFixed = @"Result-Fixed.html";
            string fileHtmlFlowing = @"Result-Flowing.html";

            // Save to HTML file: HtmlFixed.
            dc.Save(fileHtmlFixed, new HtmlFixedSaveOptions()
            {
                Version = HtmlVersion.Html5,
                CssExportMode = CssExportMode.Inline
            });

            // Save to HTML file: HtmlFlowing.
            dc.Save(fileHtmlFlowing, new HtmlFlowingSaveOptions()
            {
                Version = HtmlVersion.Html5,
                CssExportMode = CssExportMode.Inline,
                ListExportMode = HtmlListExportMode.ByHtmlTags
            });
        }

        static void SaveToHtmlStream()
        {
            // There variables are necessary only for demonstration purposes.
            byte[] fileData = null;
            string fileHtmlFixed = @"Result-Fixed.html";
            string fileHtmlFlowing = @"Result-Flowing.html";

            // Assume we already have a document 'dc'.
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hey Guys and Girls!");

            // Let's save our document to a MemoryStream.
            using (MemoryStream ms = new MemoryStream())
            {
                // HTML Fixed.
                dc.Save(ms, new HtmlFixedSaveOptions());
                fileData = ms.ToArray();

                File.WriteAllBytes(fileHtmlFixed, fileData);

                // Or HTML flowing.
                dc.Save(ms, new HtmlFlowingSaveOptions());
                fileData = ms.ToArray();

                File.WriteAllBytes(fileHtmlFlowing, fileData);
            }

        }
    }
}