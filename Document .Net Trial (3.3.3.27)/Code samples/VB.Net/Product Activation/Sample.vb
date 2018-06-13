Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        ' Steps to activate the component:

        ' 1. Open your project in Visual Studio.
        ' 2. Remove the reference to the "SautinSoft.Document.dll".
        ' 3. Replace the old file "SautinSoft.Document.dll" by the new "SautinSoft.Document.dll".
        '    (You can find the new "SautinSoft.Document.dll" inside "Bin" in "document_net_full.zip").
        ' 4. Add new reference to the new file "SautinSoft.Document.dll".
        ' 5. Fill the property 'Serial' by your serial (Activation key):

        Dim myKey As String = "1234567890"
        DocumentCore.Serial = myKey

        ' Let's create a new document by activated version.
        Dim dc As New DocumentCore()
        ' ...
    End Sub
End Module