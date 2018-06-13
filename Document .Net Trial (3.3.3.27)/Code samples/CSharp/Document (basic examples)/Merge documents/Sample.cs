using System;
using System.IO;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {

        static void Main(string[] args)
        {
            MergeMultipleDocuments();
        }

        /// This sample shows how to merge multiple DOCX, RTF, PDF and Text files.
        public static void MergeMultipleDocuments()
        {
            // Path to our combined document.
            string singlePDFPath = "Single.pdf";

            string[] supportedFiles = new string[] { @"..\..\..\..\..\..\Testing Files\example.pdf", @"..\..\..\..\..\..\Testing Files\example.docx" };

            // Create single pdf.
            DocumentCore singlePDF = new DocumentCore();

            foreach (string file in supportedFiles)
            {
                DocumentCore dc = DocumentCore.Load(file);

                Console.WriteLine("Adding: {0}...", Path.GetFileName(file));

                // Create import session.
                ImportSession session = new ImportSession(dc, singlePDF, StyleImportingMode.KeepSourceFormatting);

                // Loop through all sections in the source document.
                foreach (Section sourceSection in dc.Sections)
                {
                    // Because we are copying a section from one document to another,
                    // it is required to import the Section into the destination document.
                    // This adjusts any document-specific references to styles, bookmarks, etc.
                    //
                    // Importing a element creates a copy of the original element, but the copy
                    // is ready to be inserted into the destination document.
                    Section importedSection = singlePDF.Import<Section>(sourceSection, true, session);
                    // First section start from new page.
                    if (dc.Sections.IndexOf(sourceSection) == 0)
                        importedSection.PageSetup.SectionStart = SectionStart.NewPage;
                    // Now the new section can be appended to the destination document.
                    singlePDF.Sections.Add(importedSection);
                }
            }

            // Save single PDF to a file.
            singlePDF.Save(singlePDFPath);

            ShowResult(singlePDFPath);
        }

        static void ShowResult(string filename)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
            System.Diagnostics.Process.Start(psi);
        }
    }
}