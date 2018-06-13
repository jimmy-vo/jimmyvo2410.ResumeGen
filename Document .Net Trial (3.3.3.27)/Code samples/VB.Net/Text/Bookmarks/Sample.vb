Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        AddBookmarks()
    End Sub

    ' How add a text bounded by BookmarkStart and BookmarkEnd.
    Public Sub AddBookmarks()

        ' P.S. If you are using MS Word, to display bookmarks:
        ' File -> Options -> Advanced -> On the "Show document content" check "Show bookmarks".
        Dim documentPath As String = "Bookmarks.docx"

        ' Let's create a new document.
        Dim dc As New DocumentCore()

        ' Add text bounded by BookmarkStart and BookmarkEnd.
        dc.Sections.Add(New Section(dc, New Paragraph(dc, New Run(dc, "Text before bookmark. "), New BookmarkStart(dc, "Simple Bookmark"), New Run(dc, "Text inside bookmark."), New BookmarkEnd(dc, "Simple Bookmark"), New Run(dc, " Text after bookmark."))))

        ' Modify text inside bookmark.
        dc.Bookmarks("Simple Bookmark").GetContent(False).Replace("Some text inside bookmark.")

        ' Let's save our document into DOCX format.
        dc.Save(documentPath)

        ' Open the result for demonstation purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(documentPath) With {.UseShellExecute = True})
    End Sub

End Module