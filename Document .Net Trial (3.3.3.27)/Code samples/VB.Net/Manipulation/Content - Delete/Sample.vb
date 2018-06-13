Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        DeleteContent()
    End Sub
    ' Open a document and delete some content.
    Public Sub DeleteContent()
        Dim loadPath As String = "..\..\..\..\..\Testing Files\example.docx"
        Dim savePath As String = Path.ChangeExtension(loadPath, ".result.docx")

        Dim dc As DocumentCore = DocumentCore.Load(loadPath)

        ' Remove the text "This" from all paragraphs in 1st section.
        For Each par As Paragraph In dc.Sections(0).GetChildElements(True, ElementType.Paragraph)
            Dim findText = par.Content.Find("This")

            If findText IsNot Nothing Then
                For Each cr As ContentRange In findText
                    cr.Delete()
                Next cr
            End If
        Next par
        dc.Save(savePath)

        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(loadPath) With {.UseShellExecute = True})
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(savePath) With {.UseShellExecute = True})

    End Sub

End Module