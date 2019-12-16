using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Origami.Materials;
using Origami.Decorators.Form;
using Pack;
using Export;

namespace Controllers
{
    public class Human : CutFigure<Material>
    {

        public Human()
        {
        }

        /// <summary>
        /// human be able to cut figures 
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public Material CutRectangle(Material material)
        {
            return new RectangleDecorator(material);
        }

        public Material CutTriangle(Material material)
        {
            return new TriangleDecorator(material);
        }

        public Material CutCircle(Material material)
        {
            return new CircleDecorator(material);
        }


    }
}
