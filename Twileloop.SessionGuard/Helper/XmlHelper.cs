using YAXLib;

namespace Twileloop.SessionGuard.Helper
{
    public static class XmlHelper
    {
        public static string Serialize<T>(T obj)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(T));
            //using (StringWriter writer = new StringWriter())
            //{
            //    serializer.Serialize(writer, obj);
            //    return writer.ToString();
            //}

            var serializer = new YAXSerializer(typeof(T));
            return serializer.Serialize(obj);
        }

        public static T Deserialize<T>(string xml)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(T));
            //using (StringReader reader = new StringReader(xml))
            //{
            //    return (T)serializer.Deserialize(reader);
            //}

            var serializer = new YAXSerializer(typeof(T));
            return (T)serializer.Deserialize(xml);
        }
    }
}
