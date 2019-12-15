using Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pack.Decorators
{
    public class ExportDecorator<T> : Packege<T>
    {
        public Packege<T> box;

        public ExportDecorator(Packege<T> box)
        {
            this.box = box;

        }

        public override bool Export(string FileName, List<T> ts)
        {
            //by default
            var v = new Txt();
            return v.Write<T>(ts, FileName);
        }
    }
}
