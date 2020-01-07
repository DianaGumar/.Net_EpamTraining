using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Export
{
    /// <summary>
    /// abstract XML exporter/importer
    /// </summary>
    public class XML : Exported
    {

        public List<string> Read<T>(string fileName)
        {
            List<string> t = new List<string>();

            using (XmlReader reader = XmlReader.Create(fileName))
            {
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "objects":
                                break;
                            case "object":
                                // Next read will contain text.
                                if (reader.Read())
                                {
                                    t.Add(reader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }

            return t;
        }

        public bool Write<T>(T[] obj, string fileName)
        {
            try
            {

                using (XmlWriter writer = XmlWriter.Create(fileName))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("objects");
                    for(int i = 0; i < obj.Length; i++)
                    { 
                        writer.WriteStartElement("object");
                        writer.WriteString(obj[i].ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("XML write error: " + e);
            }

            return false;

        }

    }

}
