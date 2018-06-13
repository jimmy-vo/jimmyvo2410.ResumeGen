Imports System.Linq
Imports SautinSoft.Document

Module ExampleVB
    Sub Main()
        TOC_Update()
    End Sub

    Public Sub TOC_Update()
        ' Let's create a simple document.
        Dim dc As New DocumentCore()
        ' DocumentCore.Serial = "put your serial here";

        'It's easy to load any document.
        dc = DocumentCore.Load("..\..\..\..\..\Testing Files\toc.docx")

        ' Update TOC (TOC can be updated only after all document content is added).
        Dim toc = CType(dc.GetChildElements(True, ElementType.TableOfEntries).FirstOrDefault(), TableOfEntries)
        toc.Update()

        ' Update TOC's page numbers.
        ' Page numbers are automatically updated in that case.
        dc.GetPaginator(New PaginatorOptions() With {.UpdateFields = True})

        ' Save DOCX to a file
        dc.Save("..\..\..\..\..\Testing Files\TOC_Updated.docx")
        ShowResult("..\..\..\..\..\Testing Files\TOC_Updated.docx")
    End Sub

    Sub ShowResult(ByVal filename As String)
        Dim psi As New System.Diagnostics.ProcessStartInfo(filename) With {.UseShellExecute = True}
        System.Diagnostics.Process.Start(psi)
    End Sub
End Module