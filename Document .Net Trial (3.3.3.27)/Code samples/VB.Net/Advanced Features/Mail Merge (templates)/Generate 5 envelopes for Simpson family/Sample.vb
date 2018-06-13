Imports System
Imports System.IO
Imports SautinSoft.Document

Module Sample

    Sub Main()
        MailMergeSimpleEnvelope()
    End Sub

    ''' <summary>
    ''' Generates 5 envelopes "Happy New Year" for Simpson family using the one template.
    ''' </summary>
    ''' <remarks>
    ''' See details at: http://www.sautinsoft.com/products/document/mail-merge-generate-simple-envelope-dotnet-csharp.php.
    ''' </remarks>
    Public Sub MailMergeSimpleEnvelope()
        Dim templatePath As String = "..\..\..\..\..\..\Testing Files\envelope-template.docx"
        Dim resultPath As String = Path.GetDirectoryName(templatePath) & "\Simpson-family.docx"

        Dim dc As DocumentCore = DocumentCore.Load(templatePath)

        Dim dataSource = {
            New With {
                Key .Name = "Homer",
                Key .FamilyName = "Simpson"
            },
            New With {
                Key .Name = "Marge ",
                Key .FamilyName = "Simpson"
            },
            New With {
                Key .Name = "Bart",
                Key .FamilyName = "Simpson"
            },
            New With {
                Key .Name = "Lisa",
                Key .FamilyName = "Simpson"
            },
            New With {
                Key .Name = "Maggie",
                Key .FamilyName = "Simpson"
            }
        }

        dc.MailMerge.Execute(dataSource)
        dc.Save(resultPath)
        System.Diagnostics.Process.Start(resultPath)
    End Sub

End Module
