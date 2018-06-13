Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        SaveToRtfFile()
        SaveToRtfStream()
    End Sub

    Public Sub SaveToRtfFile()
        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        Dim filePath As String = "Result-file.rtf"

        dc.Save(filePath, New RtfSaveOptions())
    End Sub

    Public Sub SaveToRtfStream()
        ' There variables are necessary only for demonstration purposes.
        Dim fileData() As Byte = Nothing
        Dim filePath As String = "Result-stream.rtf"

        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        ' Let's save our document to a MemoryStream.
        Using ms As New MemoryStream()
            dc.Save(ms, New RtfSaveOptions())
            fileData = ms.ToArray()
        End Using
        File.WriteAllBytes(filePath, fileData)
    End Sub
End Module