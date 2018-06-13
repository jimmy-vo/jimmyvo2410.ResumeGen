Imports System
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports SautinSoft.Document
Imports SautinSoft.Document.Drawing
Imports System.Collections.Generic

Module ExampleVB

    Sub Main()
        ExtractPictures()
    End Sub

    Public Sub ExtractPictures()

        ' Path to a document where to extract pictures.
        Dim filePath As String = "..\..\..\..\..\Testing Files\example.pdf"

        ' Directory to store extracted pictures:
        Dim imageDirectory As New DirectoryInfo(Path.GetDirectoryName(filePath))
        Dim imageTemplate As String = "Picture"

        ' Here we store extracted images.
        Dim imageInventory As New List(Of ImageData)()

        ' Load the document.
        Dim dc As DocumentCore = DocumentCore.Load(filePath)

        ' Extract all images from document, skip duplicates.
        For Each pict As Picture In dc.GetChildElements(True, ElementType.Picture)

            ' Let's avoid the adding of duplicates.
            If imageInventory.Exists((Function(img) (img.GetStream().Length = pict.ImageData.GetStream().Length))) = False Then
                imageInventory.Add(pict.ImageData)
            End If
        Next pict

        ' Save and show all images.
        For i As Integer = 0 To imageInventory.Count - 1
            Dim imagePath As String = Path.Combine(imageDirectory.FullName, String.Format("{0}{1}.{2}", imageTemplate, i + 1, imageInventory(i).Format.ToString().ToLower()))
            File.WriteAllBytes(imagePath, imageInventory(i).GetStream().ToArray())
            System.Diagnostics.Process.Start(imagePath)
        Next i
    End Sub
End Module