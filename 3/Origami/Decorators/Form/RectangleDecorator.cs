using Origami.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origami.Decorators.Form
{
    public class RectangleDecorator : MaterialDecorator
    {
        public RectangleDecorator(Material AbstractMaterial) : base(AbstractMaterial)
        {
            base.Name = "Rectangle";
            base.Height--;
            base.Weight--;
        }

        public override double GetPerimeter()
        {
            return base.GetPerimeter();
        }

        public override double GetArea()
        {
            return base.GetArea();
        }

    }
}
