using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//вариант создания классов многочлена и вектора с использованием наследования

namespace Task2
{
    /// <summary>
    /// трёхмерный вектор
    /// </summary>
    public class MathObject
    {

        protected MathObject()
        {
            this.a = new double[] { 1,1,1 };
        }

        protected MathObject(double[] a)
        {
            this.a = a;
        }

        protected double[] a { get; set; }

    }
}
