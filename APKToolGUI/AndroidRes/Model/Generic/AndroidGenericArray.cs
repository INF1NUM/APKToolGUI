using System.Collections.Generic;
using System.Xml.Serialization;

namespace APKSMerger.AndroidRes.Model.Generic
{
    public class AndroidGenericArray : AndroidResource
    {
        public sealed class Item
        {
            //  [XmlText]
            //[XmlAttribute("value")]
            public string Value { get; set; }
        }

        [XmlElement("item", Type = typeof(Item))]
        public List<Item> Values { get; set; } = new List<Item>();
    }
}
