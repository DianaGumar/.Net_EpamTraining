using Origami.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using Export;
using System.Text.RegularExpressions;

namespace Pack
{
    /// <summary>
    /// packege for Materials
    /// </summary>
    public class Box
    {

        public Box()
        {
            figures = new List<Material>();
        }

        List<Material> figures;

        /// <summary>
        /// add to box if box size less than 20 and don't exist equals figures
        /// </summary>
        /// <param name="obj"></param>
        public void Add(Material obj)
        {

            if (!FindByEquals(obj) && figures.Count < 20) { figures.Add(obj); }
            
        }

        /// <summary>
        /// find by id (don't delete)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Material FindByNumber(int id)
        {
            return figures.ElementAt(id);
            //просмотреть по номеру
        }

        /// <summary>
        /// just delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Material Out(int id)
        {
            Material m = figures[id];
            figures.RemoveAt(id);
            return m;
            //извлечь по номеру
        }

        /// <summary>
        /// just change by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="m"></param>
        public void ChangeByNumber(int id, Material m)
        {
            figures[id] = m;
            //заменить по номеру
        }

        /// <summary>
        /// find by equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true or false</returns>
        public bool FindByEquals(Material obj)
        {
            foreach(Material v in figures)
            {
                if (v.Equals(obj)) { return true;  }
            }

            return false;
        }

        /// <summary>
        /// just count figures in box
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return figures.Count;
        }

        /// <summary>
        /// count all figures perimeters
        /// </summary>
        /// <returns></returns>
        public double AllPerimeter()
        {
            double value = 0;

            foreach(Material m in figures)
            {
                value += m.GetPerimeter();
            }

            return value;
        }

        /// <summary>
        /// count all figures(inside box) areas
        /// </summary>
        /// <returns></returns>
        public double AllArea()
        {
            double value = 0;

            foreach (Material m in figures)
            {
                value += m.GetArea();
            }

            return value;
        }

        /// <summary>
        /// delete all by type figures
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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

        /// <summary>
        /// delete all by type Material
        /// </summary>
        /// <param name="materialType"></param>
        /// <returns></returns>
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

        /// <summary>
        /// standart export with export type conditions (to xml or to txt)
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="ms"></param>
        /// <param name="xml"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        private bool Export(string FileName, List<Material> ms, bool xml, bool txt)
        {
            bool ansver = false;

            if(xml && txt)
            {
                var x = new XML();
                ansver = x.Write<Material>(ms, FileName + "Materials_.xml");

                var t = new Txt();
                ansver = t.Write<Material>(ms, FileName + "Materials_.txt");

            }
            else if (xml)
            {
                var x = new XML();
                ansver = x.Write<Material>(ms, FileName + "Materials_.xml");
            }
            else
            {
                var t = new Txt();
                ansver = t.Write<Material>(ms, FileName + "Materials_.txt");
            }

            return ansver;

        }

        /// <summary>
        /// export with some conditions by materials type
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="materials"></param>
        /// <param name="xml"></param>
        /// <param name="txt"></param>
        /// <returns>export was successful or not</returns>
        public bool ExportByMaterial(string FileName, MaterialType materials, bool xml, bool txt)
        {
            List<Material> ms = new List<Material>();

            if(materials == MaterialType.All) { return Export(FileName, figures, xml, txt); }
            else
            {
                foreach (Material m in figures)
                {
                    if (m.Type == materials)
                    {
                        ms.Add(m);
                    }
                }

                return Export(FileName, ms, xml, txt);

            }            
        }

        /// <summary>
        /// import all to txt file
        /// </summary>
        /// <param name="name"></param>
        public void ImportAllFromTxt(string name)
        {
            Txt txt = new Txt();
            ImportParseString(txt.Read<Material>(name));
        }

        /// <summary>
        /// import all to xml file
        /// </summary>
        /// <param name="name"></param>
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
