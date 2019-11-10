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

        public void getGCDbinaryEuclidean()
        {

        }

    }
}
