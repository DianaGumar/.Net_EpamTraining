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
        bool Write<T>(List<T> obj, string fileName);
    }
}
