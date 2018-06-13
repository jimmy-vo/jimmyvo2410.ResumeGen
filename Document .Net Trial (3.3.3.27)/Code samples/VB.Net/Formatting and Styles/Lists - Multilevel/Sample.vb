Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        MultilevelLists()
    End Sub

    ''' How to create multilevel ordered and unordered lists.
    Public Sub MultilevelLists()
        Dim documentPath As String = "MultilvelLists.docx"

        ' Let's create a new document.
        Dim dc As New DocumentCore()

        ' Add a new section.
        Dim s As New Section(dc)
        dc.Sections.Add(s)

        Dim myCollection() As String = {"One", "Two", "Three", "Four", "Five"}

        ' Create list style.
        Dim ls As New ListStyle("", ListTemplateType.NumberWithDot)
        dc.Styles.Add(ls)

        ' Add the collection of paragraphs marked as ordered list.
        Dim level As Integer = 0
        For Each listText As String In myCollection
            Dim p As New Paragraph(dc)
            dc.Sections(0).Blocks.Add(p)

            p.Content.End.Insert(listText, New CharacterFormat() With {
                .Size = 14.0,
                .FontColor = Color.Black
            })
            p.ListFormat.Style = ls
            'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
            'ORIGINAL LINE: p.ListFormat.ListLevelNumber = level++;
            p.ListFormat.ListLevelNumber = level
            level += 1
            p.ParagraphFormat.SpaceAfter = 0
        Next listText

        ' Add the collection of paragraphs marked as unordered list (bullets).
        ' Create list style.
        Dim ls1 As New ListStyle("", ListTemplateType.Bullet)
        dc.Styles.Add(ls1)

        level = 0
        For Each listText As String In myCollection
            Dim p As New Paragraph(dc)
            dc.Sections(0).Blocks.Add(p)

            p.Content.End.Insert(listText, New CharacterFormat() With {
                .Size = 14.0,
                .FontColor = Color.Black
            })
            p.ListFormat.Style = ls1
            p.ListFormat.ListLevelNumber = level
            level += 1
            p.ParagraphFormat.SpaceAfter = 0
        Next listText

        ' Save our document into DOCX file.
        dc.Save(documentPath, New DocxSaveOptions())

        ' Open the result for demonstation purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(documentPath) With {.UseShellExecute = True})
    End Sub
End Module