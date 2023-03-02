using APKSMerger.AndroidRes.Model.Generic;
using System.Xml.Serialization;

namespace APKSMerger.AndroidRes.Model
{
    public sealed class AndroidString : AndroidResource
    {
        //[XmlAttribute("formatted")]
        //public bool Formatted { get; set; }

        //[XmlAttribute("translatable")]
        //public bool Translateable { get; set; }

        // [XmlText]
        //[XmlAttribute("value")]
        public string Value { get; set; }
    }
}
