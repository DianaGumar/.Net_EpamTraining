using Origami.Decorators.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origami.Materials
{

    public enum MaterialType { All, Paper, Film }

    /// <summary>
    /// abstract Material type class
    /// </summary>
    public abstract class Material
    {
        /// <summary>
        /// default
        /// </summary>
        /// <param name="Weight"></param>
        /// <param name="Height"></param>
        public Material(double Weight, double Height)
        {
            this.Height = Height;
            this.Weight = Weight;
        }

        /// <summary>
        /// for import
        /// </summary>
        /// <param name="Weight"></param>
        /// <param name="Height"></param>
        public Material(double Weight, double Height, string Name, MaterialType Type, bool Painted)
        {
            this.Height = Height;
            this.Weight = Weight;
            this.Name = Name;
            this.Type = Type;
            this.Painted = Painted;
        }


        public string Name;
        public MaterialType Type;

        public double Weight;
        public double Height;

        public bool Painted = false;

        public abstract void Paint();

        public abstract double GetPerimeter();
        public abstract double GetArea();

        public override string ToString()
        {
            return Type + " " + Name + " Weight=" + Weight + " Height=" + Height + " Painted=" + Painted;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Material material = (Material)obj;

            return (
                Name == material.Name &&
                Weight == material.Weight &&
                Height == material.Height &&
                Painted == material.Painted);

        }

        /// <summary>
        /// just GetHashCode by Name
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}
