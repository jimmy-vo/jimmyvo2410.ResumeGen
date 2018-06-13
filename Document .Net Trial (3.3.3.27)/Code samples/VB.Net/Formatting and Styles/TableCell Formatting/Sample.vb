Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        SaveToTextFile()
        SaveToTextStream()
    End Sub

    Public Sub SaveToTextFile()
        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        Dim filePath As String = "Result-file.txt"

        dc.Save(filePath, New TxtSaveOptions() With {
                .Encoding = System.Text.Encoding.UTF8,
                .ParagraphBreak = Environment.NewLine
            })
    End Sub

    Public Sub SaveToTextStream()
        ' There variables are necessary only for demonstration purposes.
        Dim fileData() As Byte = Nothing
        Dim filePath As String = "Result-stream.txt"

        ' Assume we already have a document 'dc'.
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hey Guys and Girls!")

        ' Let's save our document to a MemoryStream.
        Using ms As New MemoryStream()
            dc.Save(ms, New TxtSaveOptions())
            fileData = ms.ToArray()
        End Using
        File.WriteAllBytes(filePath, fileData)
    End Sub
End Module