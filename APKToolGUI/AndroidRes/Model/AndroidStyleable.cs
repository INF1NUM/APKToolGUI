using APKSMerger.AndroidRes.Model.Generic;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace APKSMerger.AndroidRes.Model
{
    public sealed class AndroidStyleable : AndroidResource
    {
        [XmlElement("attr", Type = typeof(AndroidAttribute))]
        public List<AndroidAttribute> Values { get; set; } = new List<AndroidAttribute>();
    }
}
