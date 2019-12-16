using Origami.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origami.Decorators.Form
{
    public class TriangleDecorator : MaterialDecorator
    {

        public TriangleDecorator(Material AbstractMaterial) : base(AbstractMaterial)
        {
            base.Name = "Triangle";
            base.Height--;
            base.Weight--;
        }

        public override double GetPerimeter()
        {
            return Math.Sqrt(Height*Height + (Weight/2)*(Weight/2)) * 2 + Weight;
        }


        public override double GetArea()
        {
            return base.GetArea()/2;
        }

    }
}
