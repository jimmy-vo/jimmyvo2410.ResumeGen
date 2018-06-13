Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        CreateDocument()
    End Sub

    Sub CreateDocument()
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hello World!", New CharacterFormat() With {
                .FontName = "Verdana",
                .Size = 65.5F,
                .FontColor = Color.Orange
            })
        dc.Save("Result.docx")

        ' Show the result.
        ShowResult("Result.docx")
    End Sub

    Sub ShowResult(ByVal filename As String)
        Dim psi As New System.Diagnostics.ProcessStartInfo(filename) With {.UseShellExecute = True}
        System.Diagnostics.Process.Start(psi)
    End Sub
End Module