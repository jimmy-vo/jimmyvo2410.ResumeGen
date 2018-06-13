Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        SaveToPdfFile()
        SaveToPdfStream()
    End Sub

    Public Sub SaveToPdfFile()
        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        Dim filePath As String = "Result-file.pdf"

        dc.Save(filePath, New PdfSaveOptions() With {
                .Compliance = PdfCompliance.PDF_A,
                .PreserveFormFields = True
            })
    End Sub

    Public Sub SaveToPdfStream()
        ' There variables are necessary only for demonstration purposes.
        Dim fileData() As Byte = Nothing
        Dim filePath As String = "Result-stream.pdf"

        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        ' Let's save our document to a MemoryStream.
        Using ms As New MemoryStream()
            dc.Save(ms, New PdfSaveOptions() With {
                    .PageIndex = 0,
                    .PageCount = 1,
                    .Compliance = PdfCompliance.PDF_A
                })
            fileData = ms.ToArray()
        End Using
        File.WriteAllBytes(filePath, fileData)
    End Sub
End Module