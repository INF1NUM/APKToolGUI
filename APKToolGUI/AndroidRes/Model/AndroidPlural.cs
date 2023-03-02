using APKSMerger.AndroidRes.Model.Generic;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace APKSMerger.AndroidRes.Model
{
    public sealed class AndroidPlural : AndroidResource
    {
        public sealed class Plural
        {
            [XmlAttribute("quantitiy")]
            public string Quantity { get; set; }

            [XmlText]
            public string Value { get; set; }
        }

        [XmlElement("item", Type = typeof(Plural))]
        public List<Plural> Values { get; set; } = new List<Plural>();
    }
}
