Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        LoadDocxFromFile()
        'LoadDocxFromStream();
    End Sub

    ' From a file
    Public Sub LoadDocxFromFile()
        Dim filePath As String = "..\..\..\..\..\Testing Files\example.docx"
        ' The file format is detected automatically from the file extension: ".docx".
        ' But as shown in the example below, we can specify DocxLoadOptions as 2nd parameter
        ' to explicitly set that a loadable document has Docx format.
        Dim dc As DocumentCore = DocumentCore.Load(filePath)
    End Sub

    ' From a Stream
    Public Sub LoadDocxFromStream()
        ' Assume that we already have a DOCX document as bytes array.
        Dim fileBytes() As Byte = File.ReadAllBytes("..\..\..\..\..\Testing Files\example.docx")

        Dim dc As DocumentCore = Nothing
        ' Create a MemoryStream
        Using ms As New MemoryStream(fileBytes)
            ' Load a document from the MemoryStream.
            ' Specifying DocxLoadOptions we explicitly set that a loadable document is Docx.
            dc = DocumentCore.Load(ms, New DocxLoadOptions())
        End Using
    End Sub
End Module