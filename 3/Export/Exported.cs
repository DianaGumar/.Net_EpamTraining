using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export
{
    interface Exported
    {
        List<string> Read<T>(string fileName);
        bool Write<T>(T[] obj, string fileName);
    }
}
