using Origami.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origami.Decorators
{
    public class MaterialDecorator : Material
    {

        public Material AbstractMaterial;

        //public MaterialDecorator(Material AbstractMaterial) : base(AbstractMaterial.Weight, AbstractMaterial.Height)
        //{
        //    this.AbstractMaterial = AbstractMaterial;
        //    base.Type = AbstractMaterial.Type;

        //}

        /// <summary>
        /// version with use copy constructor
        /// </summary>
        /// <param name="AbstractMaterial"></param>
        public MaterialDecorator(Material AbstractMaterial) : base(AbstractMaterial)
        {

            this.AbstractMaterial = AbstractMaterial;
            base.Type = AbstractMaterial.Type;

        }

        public void SetMaterial(Material AbstractMaterial)
        {
            this.AbstractMaterial = AbstractMaterial;

        }

        public override double GetPerimeter()
        {
            return (Height + Weight) * 2;
        }

        public override double GetArea()
        {
            return Height * Weight;
        }

        public override void Paint()
        {
            base.Painted = false;
        }
    }
}
