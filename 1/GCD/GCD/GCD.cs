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
        /// подготавливает данные для гистограммы
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static Dictionary<int, long> getTimeStatistic(int x, int y)
        {
            Dictionary<int, long> timeStatistic = new Dictionary<int, long>();
            long timeTick = 0;

            //ключ 0 - нод по евклидовому методу
            getGCD_EuclidianIt(x, y, out timeTick);
            timeStatistic.Add(0, timeTick);

            //ключ 1 - нод по бинарному евкллидовому методу
            getGCDbinaryEuclideanIt(x, y, out timeTick);
            timeStatistic.Add(1, timeTick);

            return timeStatistic;

        }


        /// <summary>
        /// итерационный Алгоритм Евклида по вычислению НОД двух целых чисел 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>нод, время исполнения</returns>
        public static int getGCD_EuclidianIt(int x, int y, out long timeTick)
        {
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();

            while (x != y)
            {
                if (x > y) { x -= y; }
                else { y -= x; }
            }

            watch.Stop();
            timeTick = watch.ElapsedTicks;
            return x;
        }

        /// <summary>
        /// рекурсивный Алгоритм Евклида по вычислению НОД двух целых чисел 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>нод, время исполнения</returns>
        public static int getGCD_Euclidean(int x, int y, out long timeTick)
        {

            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();

            if (x >= 0 && y >= 0)
            {

                if (x == y)
                {
                    watch.Stop();
                    timeTick = watch.ElapsedTicks;
                    return x;
                }

                if (x == 0)
                {
                    watch.Stop();
                    timeTick = watch.ElapsedTicks;
                    return x;
                }

                if (y == 0)
                {
                    watch.Stop();
                    timeTick = watch.ElapsedTicks;
                    return y;
                }

                int max = Math.Max(x, y), min = Math.Min(x, y);

                //нод двух чисел равен ноду наименьшего из них и остатка при их делении
                //рекурсия завершается, когда второе передаваемое значение = 0
                if (max % min == 0)
                {
                    watch.Stop();
                    timeTick = watch.ElapsedTicks;
                    return min;
                }
                else { return getGCD_Euclidean(min, max % min, out timeTick); }
            }

            watch.Stop();
            timeTick = watch.ElapsedTicks;
            return 0;

        }

        /// <summary>
        /// Алгоритм Евклида по вычислению НОД трёх целых чисел 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>НОД трёх целых чисел</returns>
        public static int getGCD_Euclidean(int x, int y, int z, out long timeTick)
        {
            //работает по принципу парного вычисления нод
            return getGCD_Euclidean(getGCD_Euclidean(x, y, out timeTick), z, out timeTick);
        }

        /// <summary>
        /// Алгоритм Евклида по вычислению НОД 4-х целых чисел 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>НОД 4-х целых чисел</returns>
        public static int getGCD_Euclidean(int x, int y, int z, int k, out long timeTick)
        {
            //работает по принципу парного вычисления нод
            return getGCD_Euclidean(getGCD_Euclidean(getGCD_Euclidean(x, y, out timeTick), 
                z, out timeTick), k, out timeTick);
        }

        /// <summary>
        /// Алгоритм Евклида по вычислению НОД пяти целых чисел 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>НОД пяти целых чисел</returns>
        public static int getGCD_Euclidean(int x, int y, int z, int k, int j, out long timeTick)
        {
            //работает по принципу парного вычисления нод
            return getGCD_Euclidean(getGCD_Euclidean(getGCD_Euclidean(getGCD_Euclidean(x, y, out timeTick),
                z, out timeTick), k, out timeTick), j, out timeTick);
        }

        /// <summary>
        /// итеративный бинарный алгоритм нахождения НОД 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="timeTick"></param>
        /// <returns>нод двух целых чисел, время исполнения</returns>
        public static int getGCDbinaryEuclideanIt(int u, int v, out long timeTick)
        {
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();

            int shift = 0;

            /* GCD(0,v) == v; GCD(u,0) == u, GCD(0,0) == 0 */
            if (u == 0)
            {
                watch.Stop();
                timeTick = watch.ElapsedTicks;
                return v;
            }

            if (v == 0)
            {
                watch.Stop();
                timeTick = watch.ElapsedTicks;
                return u;
            }

            /* Let shift := lg K, where K is the greatest power of 2
                dividing both u and v. */
            while (((u | v) & 1) == 0)
            {
                shift++;
                u >>= 1;
                v >>= 1;
            }

            while ((u & 1) == 0)
                u >>= 1;

            /* From here on, u is always odd. */
            do
            {
                /* remove all factors of 2 in v -- they are not common */
                /*   note: v is not zero, so while will terminate */
                while ((v & 1) == 0)
                    v >>= 1;

                /* Now u and v are both odd. Swap if necessary so u <= v,
                    then set v = v - u (which is even). For bignums, the
                     swapping is just pointer movement, and the subtraction
                      can be done in-place. */
                if (u > v)
                {
                    int t = v; v = u; u = t; // Swap u and v.
                }

                v -= u; // Here v >= u.
            } while (v != 0);

            watch.Stop();
            timeTick = watch.ElapsedTicks;
            /* restore common factors of 2 */
            return u << shift;
        }

        /// <summary>
        /// рекурсивный бинарный алгоритм нахождения НОД 
        /// (операции деления заменены операциями битовых сдвигов, сравнения и вычитания)
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="elapsedMs"></param>
        /// <returns>нод двух целых чисел, время выполнения последней итерации</returns>
        public static int getGCDbinaryEuclidean(int u, int v, out long timeTick)
        {
            //в рекурсивной функции быдет измерено лишь время исполнения последнего её вызова.
            //для определения полного времени исполнения необходимо отслеживать количество вызовов функции
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();

            if (u == v)
            {
                watch.Stop();
                timeTick = watch.ElapsedTicks;
                return u;
            }

            if (u == 0)
            {
                watch.Stop();
                timeTick = watch.ElapsedTicks;
                return v;
            }

            if (v == 0)
            {
                watch.Stop();
                timeTick = watch.ElapsedTicks;
                return u;
            }

            // look for factors of 2
            if ((~u & 1) != 0) // u is even
            {

                if ((v & 1) != 0) // v is odd
                {
                    return getGCDbinaryEuclidean(u >> 1, v, out timeTick);
                }
                else // both u and v are even
                {
                    return getGCDbinaryEuclidean(u >> 1, v >> 1, out timeTick) << 1;
                }
            }

            if ((~v & 1) != 0) // u is odd, v is even
            {
                return getGCDbinaryEuclidean(u, v >> 1, out timeTick);
            }

            // reduce larger argument
            if (u > v)
            {
                return getGCDbinaryEuclidean((u - v) >> 1, v, out timeTick);
            }

            return getGCDbinaryEuclidean((v - u) >> 1, u, out timeTick);

        }


    }
}
