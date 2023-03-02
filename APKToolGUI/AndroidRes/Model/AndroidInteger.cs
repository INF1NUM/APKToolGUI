using APKSMerger.AndroidRes.Model.Generic;
using System.Xml.Serialization;

namespace APKSMerger.AndroidRes.Model
{
    public sealed class AndroidInteger : AndroidResource
    {
        //[XmlText]
        //[XmlAttribute("value")]
        public int Value { get; set; }
    }
}
