using System;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDocument();
        }
        static void CreateDocument()
        {
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hello World!", new CharacterFormat() { FontName = "Verdana", Size = 65.5f, FontColor = Color.Orange });
            dc.Save("Result.docx");

            // Show the result.
            ShowResult("Result.docx");
        }
        static void ShowResult(string filename)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
            System.Diagnostics.Process.Start(psi);
        }
    }
}