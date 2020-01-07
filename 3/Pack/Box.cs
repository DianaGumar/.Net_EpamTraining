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

        public Box(int size)
        {
            this.Size = size;
            figures = new Material[Size];
            FreeSpase = Size;
        }

        public Box()
        {
            figures = new Material[Size];
            FreeSpase = Size;
        }

        Material[] figures;
        public int Size = 10;
        public int FreeSpase;

        /// <summary>
        /// add to box if box size less than 20 and don't exist equals figures
        /// </summary>
        /// <param name="obj"></param>
        public void Add(Material obj)
        {

            if (!FindByEquals(obj) && FreeSpase>0)
            {

                figures[Size - FreeSpase] = obj;
                FreeSpase--;
            }
            
        }

        /// <summary>
        /// find by id (don't delete)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Material FindByNumber(int id)
        {
            return figures[id];
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

            //moove all
            for(int i = id; i< Size-FreeSpase-1; i++)
            {
                figures[i] = figures[i + 1];
            }
            //figures.RemoveAt(id);
            FreeSpase++;

            return m;
        }

        /// <summary>
        /// just change by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="m"></param>
        public void ChangeByNumber(int id, Material m)
        {
            figures[id] = m;
        }

        /// <summary>
        /// find by equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true or false</returns>
        public bool FindByEquals(Material obj)
        {
            for (int i = 0; i < Size - FreeSpase; i++)
            {
                if (figures[i].Equals(obj)) { return true;  }
            }

            return false;
        }

        /// <summary>
        /// just count figures in box
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return Size - FreeSpase;
        }

        /// <summary>
        /// count all figures perimeters
        /// </summary>
        /// <returns></returns>
        public double AllPerimeter()
        {
            double value = 0;

            for(int i=0; i< Size - FreeSpase; i++)
            {
                value += figures[i].GetPerimeter();
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

            for(int i = 0; i < Size-FreeSpase; i++)
            {
                value += figures[i].GetArea();
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

            for(int i = 0; i< Size - FreeSpase; i++)
            {
                if (figures[i].Name.Equals(str))
                {
                    
                    ms.Add(Out(i));
                }
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

            for (int i = 0; i < Size - FreeSpase+1; i++)
            {
                if (figures[i].Type == materialType)
                {
                    ms.Add(Out(i));
                }
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
        private bool Export(string FileName, Material[] ms, bool xml, bool txt)
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
            

            if(materials == MaterialType.All)
            {

                Material[] ms = new Material[Size-FreeSpase];

                for (int i = 0; i < Size - FreeSpase; i++)
                {
                    ms[i] = figures[i];
                }

                return Export(FileName, ms, xml, txt);
            }
            else
            {
                int size = 0;
                for (int i = 0; i < Size - FreeSpase; i++)
                {
                    if (figures[i].Type == materials)
                    {
                        size++;
                        //ms.Add(m);
                    }
                }

                Material[] ms = new Material[size];

                for(int i =0, j = 0; i < Size - FreeSpase; i++)
                {
                    if (figures[i].Type == materials)
                    {
                        ms[j] = figures[i];
                        j++;
                        //ms.Add(m);
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
