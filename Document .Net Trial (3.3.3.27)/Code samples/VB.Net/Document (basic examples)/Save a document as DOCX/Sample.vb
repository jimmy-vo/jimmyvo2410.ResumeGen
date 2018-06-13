Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        SaveToDocxFile()
        SaveToDocxStream()
    End Sub

    Public Sub SaveToDocxFile()
        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        Dim filePath As String = "Result-file.docx"

        dc.Save(filePath, New DocxSaveOptions())
    End Sub

    Public Sub SaveToDocxStream()
        ' There variables are necessary only for demonstration purposes.
        Dim fileData() As Byte = Nothing
        Dim filePath As String = "Result-stream.docx"

        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        ' Let's save our document to a MemoryStream.
        Using ms As New MemoryStream()
            dc.Save(ms, New DocxSaveOptions())
            fileData = ms.ToArray()
        End Using
        File.WriteAllBytes(filePath, fileData)
    End Sub
End Module