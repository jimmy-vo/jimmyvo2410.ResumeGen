Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        LoadPDFFromFile()
        'LoadPDFFromStream();
    End Sub

    ' From a file
    Public Sub LoadPDFFromFile()
        Dim filePath As String = "..\..\..\..\..\Testing Files\example.pdf"
        ' The file format is detected automatically from the file extension: ".pdf".
        ' But as shown in the example below, we can specify PdfLoadOptions as 2nd parameter
        ' to explicitly set that a loadable document has PDF format.
        Dim dc As DocumentCore = DocumentCore.Load(filePath)
    End Sub

    Public Sub LoadPDFFromStream()
        ' Get document bytes.
        Dim fileBytes() As Byte = File.ReadAllBytes("..\..\..\..\..\Testing Files\example.pdf")

        Dim dc As DocumentCore = Nothing
        ' Create a MemoryStream
        Using ms As New MemoryStream(fileBytes)
            ' Specifying PdfLoadOptions we explicitly set that a loadable document is PDF.
            ' Also we specified here to load only 1st page and
            ' switched off the 'OptimizeImage' to not merge adjacent images into a one.
            Dim pdfLO As New PdfLoadOptions() With {
                    .PageCount = 1,
                    .OptimizeImages = False
                }

            ' Load a PDF document from the MemoryStream.
            dc = DocumentCore.Load(ms, New PdfLoadOptions())
        End Using
    End Sub
End Module