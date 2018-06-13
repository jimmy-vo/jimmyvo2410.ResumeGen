Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        Styles()
    End Sub

    ' This sample shows how to work with styles.
    Public Sub Styles()
        Dim docxPath As String = "Styles.docx"

        ' Let's create document.
        Dim dc As New DocumentCore()

        ' Create custom styles.
        Dim characterStyle As New CharacterStyle("CharacterStyle1")
        characterStyle.CharacterFormat.FontName = "Arial"
        characterStyle.CharacterFormat.UnderlineStyle = UnderlineType.Wave
        characterStyle.CharacterFormat.Size = 18

        Dim paragraphStyle As New ParagraphStyle("ParagraphStyle1")
        paragraphStyle.CharacterFormat.FontName = "Times New Roman"
        paragraphStyle.CharacterFormat.Size = 14
        paragraphStyle.ParagraphFormat.Alignment = HorizontalAlignment.Center

        ' First add styles to the dc, then use it.
        dc.Styles.Add(characterStyle)
        dc.Styles.Add(paragraphStyle)

        ' Add text content.
        dc.Sections.Add(New Section(dc, New Paragraph(dc, New Run(dc, "Once upon a time, in a far away swamp, there lived an ogre named "), New Run(dc, "Shrek") With {
            .CharacterFormat = New CharacterFormat With {.Style = characterStyle}
        },
        New Run(dc, " whose precious solitude is suddenly shattered by an invasion of annoying fairy tale characters...")) With {
            .ParagraphFormat = New ParagraphFormat With {.Style = paragraphStyle}
        }))

        ' Save our document into DOCX format.
        dc.Save(docxPath)

        ' Open the result for demonstation purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(docxPath) With {.UseShellExecute = True})
    End Sub

End Module