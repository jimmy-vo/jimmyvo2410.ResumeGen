Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        SaveToHtmlFile()
        SaveToHtmlStream()
    End Sub

    Public Sub SaveToHtmlFile()
        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        Dim fileHtmlFixed As String = "Result-Fixed.html"
        Dim fileHtmlFlowing As String = "Result-Flowing.html"

        ' Save to HTML file: HtmlFixed.
        dc.Save(fileHtmlFixed, New HtmlFixedSaveOptions() With {
                .Version = HtmlVersion.Html5,
                .CssExportMode = CssExportMode.Inline
            })

        ' Save to HTML file: HtmlFlowing.
        dc.Save(fileHtmlFlowing, New HtmlFlowingSaveOptions() With {
                .Version = HtmlVersion.Html5,
                .CssExportMode = CssExportMode.Inline,
                .ListExportMode = HtmlListExportMode.ByHtmlTags
            })
    End Sub

    Public Sub SaveToHtmlStream()
        ' There variables are necessary only for demonstration purposes.
        Dim fileData() As Byte = Nothing
        Dim fileHtmlFixed As String = "Result-Fixed.html"
        Dim fileHtmlFlowing As String = "Result-Flowing.html"

        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        ' Let's save our document to a MemoryStream.
        Using ms As New MemoryStream()
            ' HTML Fixed.
            dc.Save(ms, New HtmlFixedSaveOptions())
            fileData = ms.ToArray()

            File.WriteAllBytes(fileHtmlFixed, fileData)

            ' Or HTML flowing.
            dc.Save(ms, New HtmlFlowingSaveOptions())
            fileData = ms.ToArray()

            File.WriteAllBytes(fileHtmlFlowing, fileData)
        End Using
    End Sub
End Module