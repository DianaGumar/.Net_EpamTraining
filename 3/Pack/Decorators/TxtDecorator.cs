using Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pack.Decorators
{
    public class TxtDecorator<T> : ExportDecorator<T>
    {
        public TxtDecorator(Packege<T> box) : base(box)
        {
        }

        public override bool Export(string fileName, List<T> ts)
        {
            //by defiult
            var v = new Txt();
            return v.Write<T>(ts, fileName);
        }

    }
}
