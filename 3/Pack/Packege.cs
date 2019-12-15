using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pack
{
    public abstract class Packege<T>
    {
        public abstract bool Export(string FileName, List<T> ts);
    }
}
