Imports System
Imports System.Linq
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        AddPageNumbering()
        DeletePageNumbering()
    End Sub

    ' How to add a page numbering in a document.
    Public Sub AddPageNumbering()
        Dim documentPath As String = "PageNumbering.docx"

        ' Let's create a new document with multiple pages.
        Dim dc As New DocumentCore()

        Dim pagesText() As String = {"One", "Two", "Three", "Four", "Five"}
        Dim r As New Random()

        ' Create a new section.
        Dim section As New Section(dc)
        dc.Sections.Add(section)

        ' We place our page numbers into the footer.
        ' Therefore we've to create a footer.
        Dim footer As New HeaderFooter(dc, HeaderFooterType.FooterDefault)

        ' Create a new paragraph to insert a page numbering.
        ' So that, our page numbering looks as: Page N of M.
        Dim par As New Paragraph(dc)
        par.ParagraphFormat.Alignment = HorizontalAlignment.Center
        Dim cf As New CharacterFormat() With {
            .FontName = "Arial",
            .Size = 12.0
        }
        par.Content.Start.Insert("Page ", cf.Clone())

        ' Page numbering is a Field.
        ' Create two fields: FieldType.Page and FieldType.NumPages.
        Dim fPage As New Field(dc, FieldType.Page)
        fPage.CharacterFormat = cf.Clone()
        par.Content.End.Insert(fPage.Content)
        par.Content.End.Insert(" of ", cf.Clone())
        Dim fPages As New Field(dc, FieldType.NumPages)
        fPages.CharacterFormat = cf.Clone()
        par.Content.End.Insert(fPages.Content)

        ' Add the paragraph with Fields into the footer.
        footer.Blocks.Add(par)

        ' Add the footer into the section.
        section.HeadersFooters.Add(footer)

        ' Add some paragraphs with page breaks in the document,
        ' to make several pages.
        For Each text As String In pagesText
            Dim p As New Paragraph(dc)
            p.ParagraphFormat.Alignment = HorizontalAlignment.Center
            section.Blocks.Add(p)

            Dim c As Integer = r.Next(&H0, &HFFFFFF)
            p.Content.Start.Insert(text, New CharacterFormat() With {
                .FontName = "Arial",
                .Size = 72.0,
                .FontColor = New Color(c)
            })
            p.Content.End.Insert((New SpecialCharacter(dc, SpecialCharacterType.PageBreak)).Content)
        Next text

        ' Save our document into DOCX file.
        dc.Save(documentPath)

        ' Open the result for demonstation purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(documentPath) With {.UseShellExecute = True})
    End Sub

    ' How to delete the page numbering from an existing document.
    Public Sub DeletePageNumbering()
        Dim sourcePath As String = "PageNumbering.docx"
        Dim destPath As String = "PageNumbering - deleted.docx"

        ' Load a document from DOCX file (PageNumbering.docx).
        ' We've created PageNumbering.docx in the previous example.
        Dim dc As DocumentCore = DocumentCore.Load(sourcePath)
        Dim s As Section = dc.Sections(0)

        For Each hf As HeaderFooter In s.HeadersFooters
            For Each field As Field In hf.GetChildElements(True, ElementType.Field).Reverse()

                ' Page numbering is a Field,
                ' so we have to find the fields with the type Page or NumPages and remove.
                If field.FieldType = FieldType.Page OrElse field.FieldType = FieldType.NumPages Then

                    ' Also assume that our page numbering located in a paragraph,
                    ' so let's remove the paragraph's content too.
                    If TypeOf field.Parent Is Paragraph Then
                        TryCast(field.Parent, Paragraph).Inlines.Clear()
                    End If

                    ' If we'll delete only the fields (field.Content.Delete()), our paragraph
                    ' may contain text "Page of ".
                    ' Based on this, we remove the whole paragraph.
                End If
            Next field
        Next hf
        dc.Save(destPath)

        ' Open the result for demonstation purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(destPath) With {.UseShellExecute = True})
    End Sub
End Module