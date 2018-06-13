using System;
using System.IO;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            MailMergeSimpleEnvelope();            
        }
        /// <summary>
        /// Generates 5 envelopes "Happy New Year" for Simpson family using the one template.
        /// </summary>
        /// <remarks>
        /// See details at: http://www.sautinsoft.com/products/document/mail-merge-generate-simple-envelope-dotnet-csharp.php.
        /// </remarks>
        public static void MailMergeSimpleEnvelope()
        {
            string templatePath = @"..\..\..\..\..\..\..\Testing Files\envelope-template.docx";
            string resultPath = Path.GetDirectoryName(templatePath) + @"\Simpson-family.docx";

            DocumentCore dc = DocumentCore.Load(templatePath);

            var dataSource = new[] { new { Name = "Homer", FamilyName = "Simpson" }, 
                                new { Name = "Marge ", FamilyName = "Simpson" },
                                new { Name = "Bart", FamilyName = "Simpson" },
                                new { Name = "Lisa", FamilyName = "Simpson" },
                                new { Name = "Maggie", FamilyName = "Simpson" }};

            dc.MailMerge.Execute(dataSource);
            dc.Save(resultPath);
            System.Diagnostics.Process.Start(resultPath);
        }
    }
}
