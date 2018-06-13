Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        SaveToFile()
        SaveToStream()
    End Sub

    Public Sub SaveToFile()
        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        Dim filePath As String = "Result.docx"
        ' The file format will be detected automatically from the file extension: ".docx".
        dc.Save(filePath)
    End Sub

    Public Sub SaveToStream()
        ' There variables are necessary only for demonstration purposes.
        Dim fileData() As Byte = Nothing
        Dim filePath As String = "Result.pdf"

        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        ' Let's save our document to a MemoryStream.
        Using ms As New MemoryStream()
            ' 2nd parameter: we've explicitly set to save our document in PDF format.
            dc.Save(ms, New PdfSaveOptions())

            fileData = ms.ToArray()
        End Using

        File.WriteAllBytes(filePath, fileData)
    End Sub
End Module