Imports System
Imports System.IO
Imports SautinSoft.Document

Namespace Sample
    Friend Class Sample

        Shared Sub Main(ByVal args() As String)
            MergeMultipleDocuments()
        End Sub

        ''' This sample shows how to merge multiple DOCX, RTF, PDF and Text files.
        Public Shared Sub MergeMultipleDocuments()
            ' Path to our combined document.
            Dim singlePDFPath As String = "Single.pdf"

            Dim supportedFiles() As String = {"..\..\..\..\..\Testing Files\example.pdf", "..\..\..\..\..\Testing Files\example.docx"}

            ' Create single pdf.
            Dim singlePDF As New DocumentCore()

            For Each file As String In supportedFiles
                Dim dc As DocumentCore = DocumentCore.Load(file)

                Console.WriteLine("Adding: {0}...", Path.GetFileName(file))

                ' Create import session.
                Dim session As New ImportSession(dc, singlePDF, StyleImportingMode.KeepSourceFormatting)

                ' Loop through all sections in the source document.
                For Each sourceSection As Section In dc.Sections
                    ' Because we are copying a section from one document to another,
                    ' it is required to import the Section into the destination document.
                    ' This adjusts any document-specific references to styles, bookmarks, etc.
                    '
                    ' Importing a element creates a copy of the original element, but the copy
                    ' is ready to be inserted into the destination document.
                    Dim importedSection As Section = singlePDF.Import(Of Section)(sourceSection, True, session)
                    ' First section start from new page.
                    If dc.Sections.IndexOf(sourceSection) = 0 Then
                        importedSection.PageSetup.SectionStart = SectionStart.NewPage
                    End If
                    ' Now the new section can be appended to the destination document.
                    singlePDF.Sections.Add(importedSection)
                Next sourceSection
            Next file

            ' Save single PDF to a file.
            singlePDF.Save(singlePDFPath)

            ShowResult(singlePDFPath)
        End Sub

        Private Shared Sub ShowResult(ByVal filename As String)
            Dim psi As New System.Diagnostics.ProcessStartInfo(filename) With {.UseShellExecute = True}
            System.Diagnostics.Process.Start(psi)
        End Sub
    End Class
End Namespace