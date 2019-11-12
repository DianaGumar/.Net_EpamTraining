using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Task2
{
    /// <summary>
    /// многочлен от одной переменной 
    /// </summary>
    //todo реализовать для любой степени многочлена
    public class Polinomial : IEquatable<Polinomial>
    {
        public Polinomial(double[] a)
        {

            this.a = a;

        }

        public double[] a { get; set; }

        /// <summary>
        /// расчитывает значение многочлена при известной неизвестной
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double getAnsver(double x)
        {
            double ansver = 0;
            int i = 0, degree = a.Length-1;
            while (i < a.Length)
            {
                ansver += a[i] * Math.Pow(x, degree);

                degree--;
                i++;
            }

            return ansver;
        }

        public bool Equals(Polinomial other)
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
