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
    public class Vector
    {

        public Vector(double[] a)
        {
            this.a = a;

        }


        public double[] a { get; set; }

        /// <summary>
        /// скалярное произведение трёхмерных векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static double multiplying(Vector v, Vector u)
        {
            return v.a[0] * u.a[0] + v.a[1] * u.a[1] + v.a[2] * u.a[2];
        }


        public bool Equals(Vector other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return a[0] == other.a[0] && a[1] == other.a[1] && a[2] == other.a[2];
            //return EqualityComparer<double[]>.Default.Equals(a, other.a);

        }

        public override int GetHashCode()
        {
            return -1757793268 + EqualityComparer<double[]>.Default.GetHashCode(a);
        }

        /// <summary>
        /// сложение многочлена от одной переменной
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Vector operator +(Vector v, Vector u)
        {
            return new Vector(new double[] { v.a[0] + u.a[0], v.a[1] + u.a[1], v.a[2] + u.a[2] });
        }

        /// <summary>
        /// вычитание трёхмерных векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Vector operator -(Vector v, Vector u)
        {
            return new Vector(new double[] { v.a[0] - u.a[0], v.a[1] - u.a[1], v.a[2] - u.a[2]});
        }

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
