using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;


namespace OpenAPITest
{
    class SearilizeObject
    {
        public static string Searilize(string format, Type type, object value)
        {
            return Searilize(format, type, value);
        }

        public static string Searilize(string format, Type type, object value, Type extendType)
        {
            string str = "";
            if (format == "xml")
            {
                StringWriter sw = new StringWriter();
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                //ns.Add("", "");

                System.IO.Stream stream = new System.IO.MemoryStream();

                System.Xml.Serialization.XmlSerializer serializer = null;
                if (extendType == null)
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(type);
                }
                else
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(type, new Type[]{ extendType });
                }
                serializer.Serialize(stream, value, ns);

                stream.Seek(0, System.IO.SeekOrigin.Begin);
                System.IO.StreamReader reader = new System.IO.StreamReader(stream, Encoding.UTF8);

                str = reader.ReadToEnd();

            }
            else
            {

                var enumConverter = new Newtonsoft.Json.Converters.StringEnumConverter();
                var settings =  new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
                settings.Converters.Add(enumConverter);
                str = JsonConvert.SerializeObject(value, settings);
            }

            return str;
        }

        public static T Deserialize<T>(string format, string xml)
        {
            if (format == "xml")
            {
                

                T t = default(T);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                //MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
                //XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                //t = xs.Deserialize(memoryStream);

                //using (StringReader rdr = new StringReader(xml))
                //{
                //    t = (T)xs.Deserialize(rdr);
                //}

               
                

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                var rd = new XmlNodeReader(doc.DocumentElement);
                t = (T)xs.Deserialize(rd);

                //XElement root = XElement.Parse(xml); 

                return t;
            }
            if (xml.StartsWith("{") || xml.StartsWith("<"))
            {
                return JsonConvert.DeserializeObject<T>(xml);
            }
            else
            {
                return default(T);
            }
        }

        private static String UTF8ByteArrayToString(Byte[] characters)
        {

            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        private static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }
    }
}
