using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BynaryTree
{
    public abstract class ITreePart<T> where T : IComparable
    {
        public T RChild { get; set; }
        public T LChild { get; set; }

        public int BalansFactor;
    }
}
