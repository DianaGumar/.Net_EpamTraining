using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Origami.Materials;
using Controllers;
using Pack;

namespace UnitTestOrigami
{
    [TestClass]
    public class UnitTest1
    {
        Human gurl = new Human();

        /// <summary>
        /// test perimeter loggic affter cut
        /// </summary>
        [TestMethod]
        public void TestPerimeter()
        {
            Material Paper = new Paper(50,50);
            Material Film = new Film(50,50);

            double x = 49;
            double expected = Math.Sqrt(x*x+(x/2)*(x/2))*2 + x;
           
            Paper = gurl.CutTriangle(Paper);

            double actual = Paper.GetPerimeter();

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// test area after 2 cut
        /// </summary>
        [TestMethod]
        public void TestArea()
        {
            Material Paper = new Paper(50,50);
            Material Film = new Film(50,50);

            double x = 48;
            double expected = x*x;

            Paper = gurl.CutTriangle(Paper);
            Paper = gurl.CutRectangle(Paper);

            double actual = Paper.GetArea();

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// test paint loggic
        /// </summary>
        [TestMethod]
        public void TestPaintPaper()
        {
            Material Paper = new Paper(50, 50);
            Material Film = new Film(50, 50);

            bool expected = false;

            Film = gurl.CutTriangle(Film);
            Film = gurl.CutRectangle(Film);

            Film.Paint();
            bool actual = Paper.Painted;

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// test export by txt and only Paper type
        /// </summary>
        [TestMethod]
        public void TestExportTxt()
        {
            Material Paper = new Paper(50, 50);
            Material Film = new Film(50, 50);
            Box box = new Box();

            bool expected = true;

            Film = gurl.CutTriangle(Film);
            box.Add(Film);
            Film = gurl.CutRectangle(Film);

            Paper = gurl.CutCircle(Paper);
            box.Add(Paper);
            Paper = gurl.CutTriangle(Paper);

            box.Add(Film);
            box.Add(Paper);

            bool actual = box.ExportByMaterial(
                @"E:\Epam\.Net_EpamTraining\3\", 
                MaterialType.Paper, false, true);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// test import
        /// </summary>
        [TestMethod]
        public void TestImportTxt()
        {
            Box box = new Box();

            bool expected = true;
            bool actual = false;

            box.ImportAllFromTxt(@"E:\Epam\.Net_EpamTraining\3\Materials_.txt");

            if (box.Count() != 0) { actual = true; }

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// test export by XML
        /// </summary>
        [TestMethod]
        public void TestExportXML()
        {
            Material Paper = new Paper(50, 50);
            Material Film = new Film(50, 50);
            Box box = new Box();

            bool expected = true;

            Film = gurl.CutTriangle(Film);
            box.Add(Film);
            Film = gurl.CutRectangle(Film);

            Paper = gurl.CutCircle(Paper);
            box.Add(Paper);
            Paper = gurl.CutTriangle(Paper);

            box.Add(Film);
            box.Add(Paper);

            bool actual = box.ExportByMaterial(
                @"E:\Epam\.Net_EpamTraining\3\", 
                MaterialType.All,
                true, false);
            

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// test import by XML
        /// </summary>
        [TestMethod]
        public void TestImportXML()
        {
            Box box = new Box();

            bool expected = true;
            bool actual = false;

            box.ImportAllFromXML(@"E:\Epam\.Net_EpamTraining\3\Materials_.xml");

            if (box.Count() != 0) { actual = true; }

            Assert.AreEqual(expected, actual);

        }




    }
}
