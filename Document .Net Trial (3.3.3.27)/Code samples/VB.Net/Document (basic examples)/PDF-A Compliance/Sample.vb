Imports System.IO
Imports SautinSoft.Document

Namespace Sample
    Friend Class Sample

        Shared Sub Main(ByVal args() As String)
            LoadAndSaveAsPDFA()
        End Sub
        '''
        ''' Load an existing document (*.docx, *.rtf, *.pdf, *.html, *.txt, *.pdf) and save it as a PDF/A compliant version.
        '''

        Public Shared Sub LoadAndSaveAsPDFA()
            ' Path to a loadable document.
            Dim loadPath As String = "..\..\..\..\..\Testing Files\example.docx"

            Dim dc As DocumentCore = DocumentCore.Load(loadPath)

            Dim options As New PdfSaveOptions() With {.Compliance = PdfCompliance.PDF_A}

            Dim savePath As String = Path.ChangeExtension(loadPath, ".pdf")
            dc.Save(savePath, options)

            ' Open file - example.pdf.
            ShowResult(savePath)
        End Sub

        Private Shared Sub ShowResult(ByVal filename As String)
            Dim psi As New System.Diagnostics.ProcessStartInfo(filename) With {.UseShellExecute = True}
            System.Diagnostics.Process.Start(psi)
        End Sub
    End Class
End Namespace
