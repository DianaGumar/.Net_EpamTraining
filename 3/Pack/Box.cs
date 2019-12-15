using Origami.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using Export;
using Pack.Decorators;
using System.Text.RegularExpressions;

namespace Pack
{
    public class Box : Packege<Material>
    {

        public Box()
        {
            figures = new List<Material>();
        }

        List<Material> figures;

        public void Add(Material obj)
        {
            bool key = true;

            foreach(Material m in figures)
            {
                if (m.Equals(obj)) { key = false; }
            }

            if (key && figures.Count < 20) { figures.Add(obj); }
            
        }

        public Material FindByNumber(int id)
        {
            return figures.ElementAt(id);
            //просмотреть по номеру
        }

        public Material Out(int id)
        {
            Material m = figures[id];
            figures.RemoveAt(id);
            return m;
            //извлечь по номеру
        }

        public void ChangeByNumber(int id, Material m)
        {
            figures[id] = m;
            //заменить по номеру
        }

        public Material FindByEquals(Material obj)
        {
            foreach(Material v in figures)
            {
                if (v.Equals(obj)) { return v;  }
            }

            return null;
            //ищет такуюже 
        }

        public int Count()
        {
            return figures.Count;
        }

        public double AllPerimeter()
        {
            double value = 0;

            foreach(Material m in figures)
            {
                value += m.GetPerimeter();
            }

            return value;
        }

        public double AllArea()
        {
            double value = 0;

            foreach (Material m in figures)
            {
                value += m.GetArea();
            }

            return value;
        }

        public List<Material> OutAllByTypeFigures(string str)
        {
            List<Material> ms = new List<Material>();

            foreach(Material m in figures)
            {
                if (m.Name.Equals(str))
                {
                    ms.Add(m);
                }
            }

            foreach (Material m in ms)
            {
                figures.Remove(m);
            }

            return ms;
        }

        public List<Material> OutAllByTypeMaterial(MaterialType materialType)
        {
            List<Material> ms = new List<Material>();

            foreach (Material m in figures)
            {
                if (m.Type == materialType)
                {
                    ms.Add(m);
                }
            }

            foreach (Material m in ms)
            {
                figures.Remove(m);
            }

            return ms;
        }

        public override bool Export(string FileName, List<Material> ms)
        {
            //by defiult
            var v = new Txt();
            return v.Write<Material>(ms, FileName);
        }

        public bool ExportByMaterial(string FileName, MaterialType materials)
        {
            List<Material> ms = new List<Material>();

            if(materials == MaterialType.All) { return Export(FileName, figures); }
            else
            {
                foreach (Material m in figures)
                {
                    if (m.Type == materials)
                    {
                        ms.Add(m);
                    }
                }

                return Export(FileName, ms);

            }            
        }

        public void ImportAllFromTxt(string name)
        {
            Txt txt = new Txt();
            ImportParseString(txt.Read<Material>(name));
        }

        public void ImportAllFromXML(string name)
        {
            XML xml = new XML();
            ImportParseString(xml.Read<Material>(name));

        }

        /// <summary>
        /// parse from list stimg to Materials
        /// </summary>
        /// <param name="strs"></param>
        private void ImportParseString(List<string> strs)
        {
            //Film Triangle Weight=49 Height=49 Painted=False

            Regex regex = new Regex(@"^(\w+) (\w+) Weight=(\d+) Height=(\d+) Painted=(\w+)");

            foreach (string s in strs)
            {
                //regex
                Match match = regex.Match(s);
                while (match.Success)
                {
                    if (match.Groups[1].Value == MaterialType.Film.ToString())
                    {
                        Add(new Film(
                            Double.Parse(match.Groups[3].Value),
                            Double.Parse(match.Groups[4].Value), 
                            match.Groups[2].Value,
                            MaterialType.Film,
                            Boolean.Parse(match.Groups[5].Value)));
                    }
                    else
                    {
                        Add(new Paper(
                            Double.Parse(match.Groups[3].Value),
                            Double.Parse(match.Groups[4].Value),
                            match.Groups[2].Value,
                            MaterialType.Paper,
                            Boolean.Parse(match.Groups[5].Value)));
                    }

                    match = match.NextMatch();
                }
            }
        }


    }




}
