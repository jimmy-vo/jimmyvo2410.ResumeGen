using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    public class XmlTag
    {
        public XmlTag(string name) { Name = name; Childs = new List<XmlTag>(); }

        public XmlTag Parent { get; set; }
        public List<XmlTag> Childs { get; set; }

        public string Text { get; set; }
        public string Name { get; set; }

        public XmlTag CreateChild (string name)
        {
            XmlTag child = new XmlTag(name) { Parent = this};
            Childs.Add(child);
            return child;
        }

        void UpdateDate(DateTime date)
        {
            this.Text = date.ToString();
        }
    }
}
