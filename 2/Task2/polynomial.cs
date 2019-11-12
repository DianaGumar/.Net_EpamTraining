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
    public class Polinomial : IEquatable<Polinomial>
    {
        public Polinomial(List<double> a)
        {

            this.a = a;

        }

        public Polinomial()
        {
            a = new List<double>();
        }

        public List<double> a { get; set; }

        /// <summary>
        /// расчитывает значение многочлена при известной неизвестной
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double getAnsver(double x)
        {

            double ansver = 0;
            int i = 0, degree = a.Count-1;
            while (i < a.Count)
            {
                ansver += a[i] * Math.Pow(x, degree);

                degree--;
                i++;
            }

            return ansver;
        }

        /// <summary>
        /// сравнивает экземпляры данного класса по полю double[] a
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Polinomial other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == other.a[i])
                    continue;
                return false;
            }

            return true;

            //return EqualityComparer<List<double>>.Default.Equals(a, other.a);

        }

        /// <summary>
        /// переопределённый метод hashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return -1757793268 + EqualityComparer<List<double>>.Default.GetHashCode(a);
        }

        /// <summary>
        /// сложение многочлена от одной переменной
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Polinomial operator +(Polinomial v, Polinomial u)
        {
            Polinomial z = new Polinomial();

            for (int i = 0; i < v.a.Count; i++)
            {
                z.a.Add(v.a.ElementAt(i) + u.a.ElementAt(i));

            }

            return z;
        }

        /// <summary>
        /// вычитание многочлена от одной переменной
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Polinomial operator -(Polinomial v, Polinomial u)
        {
            Polinomial z = new Polinomial();

            for (int i = 0; i < v.a.Count; i++)
            {
                z.a.Add(v.a.ElementAt(i) - u.a.ElementAt(i));

            }

            return z;
        }

        /// <summary>
        /// умножение многочлена от одной переменной
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Polinomial operator *(Polinomial v, Polinomial u)
        {
            Polinomial z = new Polinomial();

            for (int i = 0; i < v.a.Count; i++)
            {
                z.a.Add(v.a.ElementAt(i) * u.a.ElementAt(i));

            }

            return z;
        }

        /// <summary>
        /// деление многочлена от одной переменной
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Polinomial operator /(Polinomial v, Polinomial u)
        {
            Polinomial z = new Polinomial();

            for (int i = 0; i < v.a.Count; i++)
            {
                z.a.Add(v.a.ElementAt(i) / u.a.ElementAt(i));

            }

            return z;
        }


    }
}
