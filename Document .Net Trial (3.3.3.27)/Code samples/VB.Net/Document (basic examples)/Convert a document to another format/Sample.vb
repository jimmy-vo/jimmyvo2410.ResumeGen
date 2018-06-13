Imports System
Imports System.IO
Imports SautinSoft.Document

Module ExampleVB
    Sub Main()
        ConvertFromFile()
        ConvertFromStream()
    End Sub

    Public Sub ConvertFromFile()
        Dim inpFile As String = "..\..\..\..\..\Testing Files\example.pdf"
        Dim outFile As String = Path.ChangeExtension(inpFile, ".docx")

        Dim dc As DocumentCore = DocumentCore.Load(inpFile)
        dc.Save(outFile)

        ShowResult(outFile)
    End Sub

    Public Sub ConvertFromStream()
        ' We need files only for demonstration purposes.
        ' The conversion process will be done completely in memory.
        Dim inpData() As Byte = File.ReadAllBytes("..\..\..\..\..\Testing Files\example.pdf")
        Dim outData() As Byte = Nothing

        Using msInp As New MemoryStream(inpData)
            ' Load a document.
            Dim dc As DocumentCore = DocumentCore.Load(msInp, New PdfLoadOptions() With {
                .PreserveGraphics = True,
                .DetectTables = True
            })

            ' Save the document to another format.
            Using outMs As New MemoryStream()
                dc.Save(outMs, New HtmlFixedSaveOptions() With {
                    .CssExportMode = CssExportMode.Inline,
                    .EmbedImages = True
                })
                outData = outMs.ToArray()
            End Using
        End Using
    End Sub

    Sub ShowResult(ByVal filename As String)
        Dim psi As New System.Diagnostics.ProcessStartInfo(filename) With {.UseShellExecute = True}
        System.Diagnostics.Process.Start(psi)
    End Sub

End Module