using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origami.Materials
{
    public interface  CutFigure<T>
    {

        T CutRectangle(T t);
        T CutTriangle(T t);
        T CutCircle(T t);


    }
}
