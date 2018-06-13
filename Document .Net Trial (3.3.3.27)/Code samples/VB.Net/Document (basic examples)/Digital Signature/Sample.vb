Imports System.IO
Imports System.Linq
Imports SautinSoft.Document
Imports SautinSoft.Document.Drawing
Namespace Sample
    Friend Class Sample
        Shared Sub Main(ByVal args() As String)
            DigitalSignature()
        End Sub

        ''' Load an existing document (*.docx, *.rtf, *.pdf, *.html, *.txt, *.pdf) and save it in a PDF document with the digital signature.
        Public Shared Sub DigitalSignature()
            ' Path to a loadable document.
            Dim loadPath As String = "..\..\..\..\..\Testing Files\digitalsignature.docx"

            Dim dc As DocumentCore = DocumentCore.Load(loadPath)

            ' Signature line added with MS Word -> Insert tab -> Signature Line button by default has description 'Microsoft Office Signature Line...'.
            Dim signatureLine As ShapeBase = dc.GetChildElements(True).OfType(Of ShapeBase)().FirstOrDefault()
            ' This picture symbolizes a handwritten signature
            Dim signature As New Picture(dc, "..\..\..\..\..\Testing Files\signature.png")

            ' Signature in this document will be 4.5 cm right of TopLeft position of signature line
            ' and 4.5 cm below of TopLeft position of signature line.
            signature.Layout = Layout.Floating(New HorizontalPosition(4.5, LengthUnit.Centimeter, HorizontalPositionAnchor.Page), New VerticalPosition(-4.5, LengthUnit.Centimeter, VerticalPositionAnchor.Page), signature.Layout.Size)

            'signature.Layout = Layout.Inline(signature.Layout.Size);
            Dim options As New PdfSaveOptions()

            ' Path to the certificate (*.pfx).
            options.DigitalSignature.CertificatePath = "..\..\..\..\..\Testing Files\sautinsoft.pfx"

            ' Password of the certificate.
            options.DigitalSignature.CertificatePassword = "123456789"

            ' Additional information about the certificate.
            options.DigitalSignature.Location = "World Wide Web"
            options.DigitalSignature.Reason = "Document.Net by SautiSoft"
            options.DigitalSignature.ContactInfo = "info@sautinsoft.com"

            ' Placeholder where signature should be visualized.
            options.DigitalSignature.SignatureLine = signatureLine

            ' Visual representation of digital signature.
            options.DigitalSignature.Signature = signature

            Dim savePath As String = Path.ChangeExtension(loadPath, ".pdf")
            dc.Save(savePath, options)
            ShowResult(savePath)
        End Sub

        Private Shared Sub ShowResult(ByVal filename As String)
            Dim psi As New System.Diagnostics.ProcessStartInfo(filename) With {.UseShellExecute = True}
            System.Diagnostics.Process.Start(psi)
        End Sub
    End Class
End Namespace