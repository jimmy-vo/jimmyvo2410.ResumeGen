using System;
using System.IO;
using System.Collections.Generic;
using SautinSoft.Document;
using SautinSoft.Document.Drawing;

namespace Sample
{
    class Sample
    {
        
        static void Main(string[] args)
        {
            ExtractPictures();
        }
       
        public static void ExtractPictures()
        {
            
            // Path to a document where to extract pictures.
            string filePath = @"..\..\..\..\..\..\Testing Files\example.pdf";
           
            // Directory to store extracted pictures:
            DirectoryInfo imageDirectory = new DirectoryInfo(Path.GetDirectoryName(filePath));
            string imageTemplate = "Picture";

            // Here we store extracted images.
            List<ImageData> imageInventory = new List<ImageData>();

            // Load the document.
            DocumentCore dc = DocumentCore.Load(filePath);

            // Extract all images from document, skip duplicates.
            foreach (Picture pict in dc.GetChildElements(true, ElementType.Picture))
            {
               
                // Let's avoid the adding of duplicates.
                if (imageInventory.Exists((img => (img.GetStream().Length == pict.ImageData.GetStream().Length))) == false)
                    imageInventory.Add(pict.ImageData);
            }
            
            // Save and show all images.
            for (int i = 0; i < imageInventory.Count; i++)
            {
                string imagePath = Path.Combine(imageDirectory.FullName, String.Format("{0}{1}.{2}", imageTemplate, i + 1, imageInventory[i].Format.ToString().ToLower()));
                File.WriteAllBytes(imagePath, imageInventory[i].GetStream().ToArray());
                System.Diagnostics.Process.Start(imagePath);
            }
        }
    }
}