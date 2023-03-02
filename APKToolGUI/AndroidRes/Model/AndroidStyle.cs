using APKSMerger.AndroidRes.Model.Generic;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace APKSMerger.AndroidRes.Model
{
    public sealed class AndroidStyle : AndroidResource
    {
        [XmlAttribute("parent")]
        public string Parent { get; set; }

        [XmlElement("item", Type = typeof(AndroidGeneric))]
        public List<AndroidGeneric> Items { get; set; } = new List<AndroidGeneric>();
    }
}
