Imports System.IO
Imports System.Linq
Imports SautinSoft.Document
Imports SautinSoft.Document.Tables

Module ExampleVB

    Sub Main()
        ModifyTable()
    End Sub

    ' How to modify an existing table in a document.
    Public Sub ModifyTable()
        Dim sourcePath As String = "..\..\..\..\..\Testing Files\table.docx"
        Dim destPath As String = Path.ChangeExtension(sourcePath, ".modified.pdf")

        ' Load a document with a table.
        Dim dc As DocumentCore = DocumentCore.Load(sourcePath)

        ' Find a first table in the document.
        Dim table As Table = CType(dc.GetChildElements(True, ElementType.Table).First(), Table)

        ' Set dashed borders and yellow background for all cells.
        For r As Integer = 0 To table.Rows.Count - 1
            Dim c As Integer = 0
            Do While c < table.Rows(r).Cells.Count
                Dim cell As TableCell = table.Rows(r).Cells(c)
                cell.CellFormat.Borders.SetBorders(MultipleBorderTypes.Outside, BorderStyle.Dashed, Color.Black, 1)
                cell.CellFormat.BackgroundColor = New Color("#FFCC00")
                c += 1
            Loop
        Next r

        ' Save the document as PDF.
        dc.Save(destPath, New PdfSaveOptions())

        ' Show the source and the dest documents.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(sourcePath) With {.UseShellExecute = True})
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(destPath) With {.UseShellExecute = True})

    End Sub
End Module