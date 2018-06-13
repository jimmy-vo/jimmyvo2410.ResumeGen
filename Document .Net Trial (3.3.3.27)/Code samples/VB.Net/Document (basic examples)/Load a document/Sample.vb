Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        LoadFromFile()
    End Sub

    ' From a file
    Public Sub LoadFromFile()
        Dim filePath As String = "..\..\..\..\..\Testing Files\example.docx"
        ' The file format is detected automatically from the file extension: ".docx".
        ' But as shown in the example below, we can specify DocxLoadOptions as 2nd parameter
        ' to explicitly set that a loadable document has Docx format.
        Dim dc As DocumentCore = DocumentCore.Load(filePath)
    End Sub

    ' From a Stream
    Public Sub LoadFromStream()
        ' We've knowingly created an empty DocumentCore instance before "Using {}"
        ' to continue work with it after stream will be closed.
        Dim dc As DocumentCore = Nothing
        Using fs As New FileStream("..\..\..\..\..\Testing Files\example.docx", FileMode.Open)
            ' Here we explicitly set that a loadable document is Docx.
            dc = DocumentCore.Load(fs, New DocxLoadOptions())
        End Using
    End Sub

    ' From an array of bytes
    Public Sub LoadFromBytes()
        ' Get document bytes from a file.
        Dim fileBytes() As Byte = File.ReadAllBytes("..\..\..\..\..\Testing Files\example.pdf")

        Dim dc As DocumentCore = Nothing
        Using ms As New MemoryStream(fileBytes)
            ' With PdfLoadOptions we explicitly set that a loadable document is PDF.
            Dim pdfLO As New PdfLoadOptions() With {
                    .RasterizeVectorGraphics = False,
                    .PageCount = 2
                }
            dc = DocumentCore.Load(ms, pdfLO)
        End Using
    End Sub
End Module