using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Steps to activate the component:

            // 1. Open your project in Visual Studio.
            // 2. Remove the reference to the "SautinSoft.Document.dll".
            // 3. Replace the old file "SautinSoft.Document.dll" by the new "SautinSoft.Document.dll".
            //    (You can find the new "SautinSoft.Document.dll" inside "Bin" in "document_net_full.zip").
            // 4. Add new reference to the new file "SautinSoft.Document.dll".
            // 5. Fill the property 'Serial' by your serial (Activation key):

            string myKey = "1234567890";
            DocumentCore.Serial = myKey;

            // Let's create a new document by activated version.
            DocumentCore dc = new DocumentCore();
            // ...
        }
    }
}