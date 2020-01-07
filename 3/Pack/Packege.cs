using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pack
{
    public abstract class Packege<T, N>
    {
        internal T[] figures;

        public abstract bool Export(string FileName, List<T> ts );
        public abstract bool ExportByMaterial(string FileName, N materials);
        public abstract void Add(T obj);
    }
}
