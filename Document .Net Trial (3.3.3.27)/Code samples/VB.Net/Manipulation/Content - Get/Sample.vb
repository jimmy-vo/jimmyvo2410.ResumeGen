Imports System.Text
Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        GetContent()
    End Sub

    ' Get content example.
    Public Sub GetContent()
        ' Path to an input document.
        Dim documentPath As String = "..\..\..\..\..\Testing Files\example.docx"

        Dim dc As DocumentCore = DocumentCore.Load(documentPath)

        Dim sb As New StringBuilder()

        ' Get content of each paragraph in the document.
        For Each par As Paragraph In dc.GetChildElements(True, ElementType.Paragraph)
            ' The property 'Content' returns the content as ContentRange.
            ' Get content and append it into StringBuilder.
            sb.AppendFormat("Paragraph: {0}", par.Content.ToString())
            sb.AppendLine()
        Next par

        ' Get content of each Run where the text color is Red.
        For Each run As Run In dc.GetChildElements(True, ElementType.Run)
            If run.CharacterFormat.FontColor = Color.Red Then
                ' The property 'Content' returns the content as ContentRange.
                ' Get content and append it into StringBuilder.
                sb.AppendFormat("Red color: {0}", run.Content.ToString())
                sb.AppendLine()
            End If
        Next run
        Console.WriteLine(sb.ToString())
        Console.ReadLine()
    End Sub

End Module