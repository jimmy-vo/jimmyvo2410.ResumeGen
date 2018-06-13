Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        AddHyperlink()
    End Sub

    ' How to add a hyperlink into a document.
    Public Sub AddHyperlink()
        Dim docxPath As String = "Hyperlink.docx"

        ' Let's create a simple DOCX document with a hyperlink.
        Dim dc As New DocumentCore()

        Dim hpl As New Hyperlink(dc, "http://www.zoo.org", "Welcome to Zoo!")
        TryCast(hpl.DisplayInlines(0), Run).CharacterFormat = New CharacterFormat() With {
                .Size = 16,
                .FontColor = New Color("#358CCB"),
                .UnderlineStyle = UnderlineType.Single
            }
        hpl.ScreenTip = "Welcome to WoodLand Zoo!"

        Dim p As New Paragraph(dc)
        p.Inlines.Add(hpl)
        p.ParagraphFormat.Alignment = HorizontalAlignment.Center

        dc.Content.Start.Insert(p.Content)

        ' Save our document to DOCX format.
        dc.Save(docxPath)

        ' Open the result for demonstation purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(docxPath) With {.UseShellExecute = True})
    End Sub

End Module