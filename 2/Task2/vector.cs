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
    public class vector
    {
        vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            
        }

        double x { get; }
        double y { get; }
        double z { get; }

        /// <summary>
        /// скалярное произведение трёхмерных векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public double multiplying(vector v, vector u)
        {
            return v.x * u.x + v.y * u.y + v.z * u.z;
        }

        /// <summary>
        /// сложение трёхмерных векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static vector operator +(vector v, vector u) { return new vector(v.x + u.x, v.y + u.y, v.z + u.z); }

        /// <summary>
        /// вычитание трёхмерных векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static vector operator -(vector v, vector u) { return new vector(v.x - u.x, v.y - u.y, v.z - u.z); }

        /// <summary>
        /// векторное произведение трёхмерных векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static vector operator *(vector v, vector u) {
            return new vector(((v.y * u.z) - (u.y * v.z)), - 
                             ((v.x * u.z) - (u.x * v.z)), + 
                             ((v.x * u.y) - (u.x * v.y))); }

        
    }
}
