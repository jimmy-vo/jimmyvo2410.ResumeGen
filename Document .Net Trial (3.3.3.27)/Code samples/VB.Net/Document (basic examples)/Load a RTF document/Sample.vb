Imports System.IO
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        LoadRtfFromFile()
        'LoadRtfFromStream();
    End Sub

    ' From a file
    Public Sub LoadRtfFromFile()
        Dim filePath As String = "..\..\..\..\..\Testing Files\example.rtf"

        ' The file format is detected automatically from the file extension: ".rtf".
        ' But as shown in the example below, we can specify RtfLoadOptions as 2nd parameter
        ' to explicitly set that a loadable document has RTF format.
        Dim dc As DocumentCore = DocumentCore.Load(filePath)
    End Sub

    ' From a Stream
    Public Sub LoadRtfFromStream()

        ' Get document bytes.
        Dim fileBytes() As Byte = File.ReadAllBytes("..\..\..\..\..\Testing Files\example.rtf")
        Dim dc As DocumentCore = Nothing

        ' Create a MemoryStream
        Using ms As New MemoryStream(fileBytes)

            ' Load a document from the MemoryStream.
            ' Specifying RtfLoadOptions we explicitly set that a loadable document is RTF.
            dc = DocumentCore.Load(ms, New RtfLoadOptions())
        End Using
    End Sub
End Module