Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        LoadHtmlFromFile()
        'LoadHtmlFromStream();
    End Sub

    ' From a file
    Public Sub LoadHtmlFromFile()
        Dim filePath As String = "..\..\..\..\..\Testing Files\example.html"
        ' The file format is detected automatically from the file extension: ".html".
        ' But as shown in the example below, we can specify HtmlLoadOptions as 2nd parameter
        ' to explicitly set that a loadable document has HTML format.
        Dim dc As DocumentCore = DocumentCore.Load(filePath)
    End Sub

    ' From a Stream
    Public Sub LoadHtmlFromStream()
        ' Get document bytes.
        Dim fileBytes() As Byte = File.ReadAllBytes("..\..\..\..\..\Testing Files\example.html")

        Dim dc As DocumentCore = Nothing
        ' Create a MemoryStream
        Using ms As New MemoryStream(fileBytes)
            ' Load a document from the MemoryStream.
            ' Specifying HtmlLoadOptions we explicitly set that a loadable document is HTML.
            dc = DocumentCore.Load(ms, New HtmlLoadOptions())
        End Using
    End Sub
End Module