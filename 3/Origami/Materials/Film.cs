using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origami.Materials
{
    public class Film : Material
    {

        public Film(double Weight, double Height) : base(Weight, Height)
        {
            base.Type = MaterialType.Film;
        }

        /// <summary>
        /// for import
        /// </summary>
        /// <param name="Weight"></param>
        /// <param name="Height"></param>
        public Film(double Weight, double Height, string Name, MaterialType Type, bool Painted) :
            base(Weight, Height,Name, Type, Painted)
        {
        }


        public override double GetPerimeter() { return (Weight + Height) * 2; }
        public override double GetArea() { return Weight * Height; }

        public override void Paint()
        {
            Painted = false;
        }
    }
}
