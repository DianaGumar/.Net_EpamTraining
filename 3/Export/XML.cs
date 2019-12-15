using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export
{
    public class XML : Exported
    {

        public List<string> Read<T>(string fileName)
        {
            List<string> t = new List<string>();
            return t;
        }

        public bool Write<T>(List<T> obj, string fileName)
        {
            return false;

        }

    }
}
