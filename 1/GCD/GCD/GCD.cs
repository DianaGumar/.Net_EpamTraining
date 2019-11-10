using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    public class GCD
    {

        Double timeEuclidean, binaryEuclidean;



        /// <summary>
        /// Алгоритм Евклида по вычислению НОД двух целых чисел 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static int getGCD_Euclidean(int x, int y)
        {
            if (x >= 0 && y >= 0)
            {

                if (x == y)
                    return x;

                if (x == 0)
                    return x;

                if (y == 0)
                    return y;


                int max = Math.Max(x, y), min = Math.Min(x, y);

                //нод двух чисел равен ноду наименьшего из них и остатка при их делении
                //рекурсия завершается, когда второе передаваемое значение = 0
                if (max % min == 0) { return min; }
                else { return getGCD_Euclidean(min, max % min); }
            }

            return 0;

        }

        /// <summary>
        /// Алгоритм Евклида по вычислению НОД трёх целых чисел 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static int getGCD_Euclidean(int x, int y, int z)
        {
            //работает по принципу парного вычисления нод
            return getGCD_Euclidean(getGCD_Euclidean(x, y), z);
        }

        /// <summary>
        /// Алгоритм Евклида по вычислению НОД 4-х целых чисел 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static int getGCD_Euclidean(int x, int y, int z, int k)
        {
            //работает по принципу парного вычисления нод
            return getGCD_Euclidean(getGCD_Euclidean(getGCD_Euclidean(x, y), z), k);
        }

        /// <summary>
        /// Алгоритм Евклида по вычислению НОД пяти целых чисел 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static int getGCD_Euclidean(int x, int y, int z, int k, int j)
        {
            //работает по принципу парного вычисления нод
            return getGCD_Euclidean(getGCD_Euclidean(getGCD_Euclidean(getGCD_Euclidean(x, y), z), k), j);
        }

        /// <summary>
        /// бинарный алгоритм нахождения НОД (операции деления заменены операциями битовых сдвигов, сравнения и вычитания)
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static int getGCDbinaryEuclidean(int u, int v)
        {
            if (u == v)
                return u;

            if (u == 0)
                return v;

            if (v == 0)
                return u;

            // look for factors of 2
            if ((~u & 1) != 0) // u is even
            {
                
                if ((v & 1) != 0) // v is odd
                    return getGCDbinaryEuclidean(u >> 1, v);
                else // both u and v are even
                    return getGCDbinaryEuclidean(u >> 1, v >> 1) << 1;
            }
            
            if ((~v & 1) != 0) // u is odd, v is even
                return getGCDbinaryEuclidean(u, v >> 1);

            // reduce larger argument
            if (u > v)
                return getGCDbinaryEuclidean((u - v) >> 1, v);

            return getGCDbinaryEuclidean((v - u) >> 1, u);

        }

    }
}
