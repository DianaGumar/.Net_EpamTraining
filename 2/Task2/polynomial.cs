using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// трёхмерный вектор
    /// </summary>
    public class Polinomial : MathObject
    {
        public Polinomial(double[] a)
        {
            base.a = a;

        }

        /// <summary>
        /// сложение многочлена от одной переменной
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Polinomial operator +(Polinomial v, Polinomial u)
        {
            return new Polinomial(new double[] { v.a[0] + u.a[0], v.a[1] + u.a[1], v.a[2] + u.a[2] });
        }

        /// <summary>
        /// вычитание многочлена от одной переменной
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Polinomial operator -(Polinomial v, Polinomial u)
        {
            return new Polinomial(new double[] { v.a[0] - u.a[0], v.a[1] - u.a[1], v.a[2] - u.a[2] });
        }

        /// <summary>
        /// умножение многочлена от одной переменной
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Polinomial operator *(Polinomial v, Polinomial u)
        {
            return new Polinomial(new double[] { v.a[0] * u.a[0], v.a[1] * u.a[1], v.a[2] * u.a[2] });
        }

        /// <summary>
        /// деление многочлена от одной переменной
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Polinomial operator /(Polinomial v, Polinomial u)
        {
            return new Polinomial(new double[] { v.a[0] / u.a[0], v.a[1] / u.a[1], v.a[2] / u.a[2] });
        }


    }
}
