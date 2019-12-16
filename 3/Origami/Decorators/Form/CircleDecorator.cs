using Origami.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origami.Decorators.Form
{
    public class CircleDecorator : MaterialDecorator
    {
        public CircleDecorator(Material AbstractMaterial) : base(AbstractMaterial)
        {
            base.Name = "Circle";
            base.Height--;
            base.Weight--;
        }

        public override double GetPerimeter()
        {
            return Math.PI * Height;
        }


        public override double GetArea()
        {
            return Math.PI * Height/2 * Height/2;
        }


    }
}
