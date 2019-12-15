using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Origami.Materials;
using Origami.Decorators.Form;
using Pack;
using Pack.Decorators;
using Export;

namespace Controllers
{
    public class Human : CutFigure<Material>
    {

        public Human()
        {
        }

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



        public Packege<Material> ExportPackegeProperties
            (
            Packege<Material> packege,
            string FileName,  
            bool ExportTxt,
            bool ExportXML
            )
        {
            if (ExportTxt && ExportXML)
            {
                packege = new XMLDecorator<Material>(packege);
                packege = new TxtDecorator<Material>(packege);

            }
            else if (ExportTxt)
            {
                packege = new TxtDecorator<Material>(packege);
            }
            else if (ExportXML)
            {
                packege = new XMLDecorator<Material>(packege);
            }

            return packege;

        }


    }
}
