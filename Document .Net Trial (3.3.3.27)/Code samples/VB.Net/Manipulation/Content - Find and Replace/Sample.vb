Imports System.IO
Imports System.Linq
Imports System.Text.RegularExpressions
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        FindAndReplace()
    End Sub

    Public Sub FindAndReplace()
        ' Path to a loadable document.
        Dim loadPath As String = "..\..\..\..\..\Testing Files\critique.docx"

        ' Load a document intoDocumentCore.
        Dim dc As DocumentCore = DocumentCore.Load(loadPath)

        Dim regex As New Regex("bean", RegexOptions.IgnoreCase)

        'Find "Bean" and Replace everywhere on "Joker :-)"
        'Please note, Reverse() makes sure that action replace not affects to Find().
        For Each item As ContentRange In dc.Content.Find(regex).Reverse()
            item.Replace("Joker")
        Next item

        ' Save our document into PDF format.
        Dim savePath As String = Path.ChangeExtension(loadPath, ".replaced.pdf")
        dc.Save(savePath, New PdfSaveOptions())

        ' Open the result for demonstation purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(savePath) With {.UseShellExecute = True})
    End Sub
End Module