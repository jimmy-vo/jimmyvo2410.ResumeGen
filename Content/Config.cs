using SautinSoft.Document;
using SautinSoft.Document.Drawing;
using SautinSoft.Document.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Content
{
    public class Config
    {
        public byte[] Education = null;
        public byte[] Experience = null;
        public byte[] Award = null;
        public byte[] Skill = null;
        public byte[] Volunteer = null;
        public byte[] Summary = null;

        public Config(API.XmlTag input)
        {
            foreach (API.XmlTag item in input.Childs)
            {
                if (item.Name == "education") Education = ToByteArray(item.Text);
                if (item.Name == "experience") Experience = ToByteArray(item.Text);
                if (item.Name == "award") Award = ToByteArray(item.Text);
                if (item.Name == "skill") Skill = ToByteArray(item.Text);
                if (item.Name == "volunteer") Volunteer = ToByteArray(item.Text);
                if (item.Name == "summary") Summary = ToByteArray(item.Text);
            }
        }

        private byte[] ToByteArray(string input)
        {
            if (input == null) return null;

            List<byte> output = new List<byte>();
            string[] element = input.Split(' ');

            foreach(string item in element)
            {
                try
                {
                    output.Add(Byte.Parse(item));
                }
                catch
                {

                }
            }

            if (output.Count == 0)
            {
                return null;
            }
            else
            {
                return output.ToArray();
            }
        }
    }
}
