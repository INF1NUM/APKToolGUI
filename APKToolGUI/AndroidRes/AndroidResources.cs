//https://github.com/shadow578/ApksMerger

using APKSMerger.AndroidRes.Model;
using APKSMerger.AndroidRes.Model.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace APKSMerger.AndroidRes
{
    [XmlRoot("resources")]
    public sealed class AndroidResources
    {
        //basic
        [XmlElement("bool", Type = typeof(AndroidBool))]
        [XmlElement("integer", Type = typeof(AndroidInteger))]
        [XmlElement("dimen", Type = typeof(AndroidDimension))]
        [XmlElement("drawable", Type = typeof(AndroidDrawable))]
        [XmlElement("color", Type = typeof(AndroidColor))]
        [XmlElement("fraction", Type = typeof(AndroidFraction))]

        //extended
        [XmlElement("attr", Type = typeof(AndroidAttribute))]
        [XmlElement("string", Type = typeof(AndroidString))]
        [XmlElement("item", Type = typeof(AndroidTypedItem))]
        [XmlElement("public", Type = typeof(AndroidPublic))]

        //complex
        [XmlElement("style", Type = typeof(AndroidStyle))]
        [XmlElement("plurals", Type = typeof(AndroidPlural))]
        [XmlElement("string-array", Type = typeof(AndroidStringArray))]
        [XmlElement("integer-array", Type = typeof(AndroidIntegerArray))]
        [XmlElement("array", Type = typeof(AndroidGenericArray))]
        [XmlElement("declare-styleable", Type = typeof(AndroidStyleable))]
        public List<AndroidResource> Values { get; set; } = new List<AndroidResource>();

        /// <summary>
        /// Find a AndroidPublic with matching id
        /// </summary>
        /// <param name="id">the id to find</param>
        /// <returns>matching public, or null if not found</returns>
        public AndroidPublic FindPublicWithId(string id)
        {
            foreach(AndroidResource res in Values)
            {
                if((res is AndroidPublic pub) && pub.Id.Equals(id))
                {
                    return pub;
                }
            }

            return null;
        }

        /// <summary>
        /// Deserialize a file into a object
        /// </summary>
        /// <param name="file">the file to deserialize</param>
        /// <returns>the object</returns>
        public static AndroidResources FromFile(string file)
        {
            //check file
            if (!File.Exists(file)) return null;

            //deserialize
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(AndroidResources));
                using (StreamReader reader = File.OpenText(file))
                {
                    return ser.Deserialize(reader) as AndroidResources;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// serialize into a file
        /// </summary>
        /// <param name="file">the file to serialize to, will be overwritten if exists</param>
        /// <returns>write file ok?</returns>
        public bool ToFile(string file)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(AndroidResources));
                using (StreamWriter writer = File.CreateText(file))
                {
                    ser.Serialize(writer, this, new XmlSerializerNamespaces());
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
