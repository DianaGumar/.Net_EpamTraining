using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Serializer
{
    /// <summary>
    /// add-on to the class xmlSerializer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class myXmlSerializer<T>
    {
        public myXmlSerializer()
        {
            formatter = new XmlSerializer(typeof(T));
        }

        XmlSerializer formatter;

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="t"></param>
        /// <param name="fileName"></param>
        public void Serialize(T t, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, t);
            }

        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T Deserialize(string fileName)
        {
            T t;

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                t = (T)formatter.Deserialize(fs);
            }

            return t;

        }

    }

}
