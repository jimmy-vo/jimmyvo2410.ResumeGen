Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        Sections()
    End Sub

    ' How to adjust a document page properties.
    Public Sub Sections()
        Dim documentPath As String = "Sections.docx"

        ' Let's create a simple document with two Sections.
        Dim dc As New DocumentCore()

        ' First Section, A4 - Portrait.
        Dim s1 As New Section(dc)
        s1.PageSetup.PaperType = PaperType.A4
        s1.PageSetup.Orientation = Orientation.Portrait
        dc.Sections.Add(s1)

        ' Add some text into section 1.
        s1.Content.Start.Insert("Text in section 1", New CharacterFormat() With {
            .FontName = "Times New Roman",
            .Size = 60.0
        })

        ' Second Section, Letter - Landscape.
        Dim s2 As New Section(dc)
        s2.PageSetup.PaperType = PaperType.Letter
        s2.PageSetup.Orientation = Orientation.Landscape
        dc.Sections.Add(s2)

        ' Add some text into section 2.
        s2.Content.Start.Insert("Text in section 2", New CharacterFormat() With {
            .FontName = "Arial",
            .Size = 72.0,
            .FontColor = New Color("DD55AA")
        })

        ' Save our document into DOCX format.
        dc.Save(documentPath)

        ' Open the result for demonstation purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(documentPath) With {.UseShellExecute = True})
    End Sub
End Module