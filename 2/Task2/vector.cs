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
    public class Vector : MathObject
    {
        public Vector(double[] a)
        {
            base.a = a;

        }


        /// <summary>
        /// скалярное произведение трёхмерных векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public double multiplying(Vector v, Vector u)
        {
            return v.a[0] * u.a[0] + v.a[1] * u.a[1] + v.a[2] * u.a[2];
        }

        /// <summary>
        /// сложение многочлена от одной переменной
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Vector operator +(Vector v, Vector u) { return new Vector(new double[] { v.a[0] + u.a[0], v.a[1] + u.a[1], v.a[2] + u.a[2] }); }

        /// <summary>
        /// вычитание трёхмерных векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Vector operator -(Vector v, Vector u) { return new Vector(new double[] { v.a[0] - u.a[0], v.a[1] - u.a[1], v.a[2] - u.a[2]}); }

        /// <summary>
        /// векторное произведение трёхмерных векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Vector operator *(Vector v, Vector u)
        {

            //метод нацеленный исключительно на трёхмерный вектор
            return new Vector(new double[]{((v.a[1] * u.a[2]) - (u.a[1] * v.a[2])), -
                                         ((v.a[0] * u.a[2]) - (u.a[0] * v.a[2])), +
                                         ((v.a[0] * u.a[1]) - (u.a[0] * v.a[1])) });
        }


    }
}
