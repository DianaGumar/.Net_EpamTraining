using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    public class GCD
    {

        /// <summary>
        /// Алгоритм Евклида по вычислению НОД двух целых чисел 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static int getGCD_Euclidean(int x, int y)
        {
            if (x != 0 && y !=0)
            {
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


        public void getGCDbinaryEuclidean()
        {

        }

    }
}
