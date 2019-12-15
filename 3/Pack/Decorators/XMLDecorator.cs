using Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pack.Decorators
{
    public class XMLDecorator<T> : ExportDecorator<T>
    {

        public XMLDecorator(Packege<T> box) : base(box)
        {
        }

        public override bool Export(string fileName, List<T> ts)
        {
            //by defiult
            var v = new XML();
            return v.Write<T>(ts, fileName);
        }
    }
}
