using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export
{
    /// <summary>
    /// abstract Txt exporter/importer
    /// </summary>
    public class Txt : Exported
    {

        public List<string> Read<T>(string fileName)
        {
            
            List<string> t = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        t.Add(line);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Txt read error: " + e);
            }

            return t;
        }

        public bool Write<T>(List<T> obj, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, true, System.Text.Encoding.Default))
                {
                    foreach(T t in obj)
                    {
                        sw.WriteLine(t.ToString());
                    }
                    
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Txt write error: " + e);
            }

            return false;
        }

    }
}
