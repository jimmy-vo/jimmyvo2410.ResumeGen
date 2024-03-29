Imports SautinSoft.Document

Module ExampleVB
    Sub Main()
        CreateHtml()
    End Sub
    Public Sub CreateHtml()
        ' Set a path to our HTML document.
        Dim htmlPath As String = "Result.html"

        ' Let's create a simple HTML document.
        Dim dc As New DocumentCore()
        'DocumentCore.Serial = "put your serial here";

        ' Add new section.
        Dim section As New Section(dc)
        dc.Sections.Add(section)

        ' Add two paragraphs using different ways:

        ' Way 1: Add 1st paragraph.
        Dim par1 As New Paragraph(dc)
        par1.ParagraphFormat.Alignment = HorizontalAlignment.Center
        section.Blocks.Add(par1)

        ' Let's create a characterformat for text in the 1st paragraph.
        Dim cf As New CharacterFormat() With {
            .FontName = "Verdana",
            .Size = 16,
            .FontColor = Color.Orange
        }

        Dim text1 As New Run(dc, "This is a first line in 1st paragraph!")
        text1.CharacterFormat = cf
        par1.Inlines.Add(text1)

        ' Let's add a line break into our paragraph.
        par1.Inlines.Add(New SpecialCharacter(dc, SpecialCharacterType.LineBreak))

        Dim text2 As Run = text1.Clone()
        text2.Text = "Let's type a second line."
        par1.Inlines.Add(text2)

        ' Way 2 (easy): Add 2nd paragraph using ContentRange.
        dc.Content.End.Insert(vbLf & "This is a first line in 2nd paragraph.", New CharacterFormat() With {
            .Size = 25,
            .FontColor = Color.Blue,
            .Bold = True
        })
        Dim lBr As New SpecialCharacter(dc, SpecialCharacterType.LineBreak)
        dc.Content.End.Insert(lBr.Content)
        dc.Content.End.Insert("This is a second line.", New CharacterFormat() With {
            .Size = 20,
            .FontColor = Color.DarkGreen,
            .UnderlineStyle = UnderlineType.Single
        })

        ' Save HTML document to a file.
        dc.Save(htmlPath, New HtmlFixedSaveOptions())
        ShowResult(htmlPath)
    End Sub

    Sub ShowResult(ByVal filename As String)
        Dim psi As New System.Diagnostics.ProcessStartInfo(filename) With {.UseShellExecute = True}
        System.Diagnostics.Process.Start(psi)
    End Sub
End Module