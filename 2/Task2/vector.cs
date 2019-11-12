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

        double x, y, z;

        public static vector operator +(vector v, vector u) { }


    }
}
