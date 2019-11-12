using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace UnitTestTask2
{
    [TestClass]
    public class UnitTestPolynomial
    {

        [TestMethod]
        public void TestAnsver()
        {
            Polinomial v = new Polinomial(new double[] { 1, 2, 3 });

            double expected = 11;
            double actual;

            actual = v.getAnsver(2);

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestSum() 
        {
            Polinomial v = new Polinomial(new double[] { 1, 1, 1 });
            Polinomial u = new Polinomial(new double[] { 2, 3, 4 });

            Polinomial expected = new Polinomial(new double[] { 3, 4, 5 });
            Polinomial actual;

            actual = v + u;

            Assert.AreEqual(actual.Equals(expected), true);

        }

        [TestMethod]
        public void TestDif() 
        {
            Polinomial v = new Polinomial(new double[] { 1, 1, 1 });
            Polinomial u = new Polinomial(new double[] { 2, 3, 4 });

            Polinomial expected = new Polinomial(new double[] { -1, -2, -3 });
            Polinomial actual;

            actual = v - u;

            Assert.AreEqual(actual.Equals(expected), true);

        }

        [TestMethod]
        public void TestMultyplexing() 
        {
            Polinomial v = new Polinomial(new double[] { 1, 2, 1 });
            Polinomial u = new Polinomial(new double[] { 2, 3, 4 });

            Polinomial expected = new Polinomial(new double[] { 2, 6, 4 });
            Polinomial actual;

            actual = v * u;

            Assert.AreEqual(actual.Equals(expected), true);

        }

        [TestMethod]
        public void TestDivision()
        {
            Polinomial v = new Polinomial(new double[] { 4, 6, 8 });
            Polinomial u = new Polinomial(new double[] { 2, 3, 4 });

            Polinomial expected = new Polinomial(new double[] { 2, 2, 2 });
            Polinomial actual;

            actual = v / u;

            Assert.AreEqual(actual.Equals(expected), true);

        }

    }

    [TestClass]
    public class UnitTestVector
    {
        [TestMethod]
        public void TestSum()
        {
            Vector v = new Vector(new double[] { 1, 1, 1 });
            Vector u = new Vector(new double[] { 2, 3, 4 });

            Vector expected = new Vector(new double[] { 3, 4, 5 });
            Vector actual;

            actual = v + u;

            Assert.AreEqual(actual.Equals(expected), true);

        }

        [TestMethod]
        public void TestmultiplyingVector()
        {
            Vector v = new Vector(new double[] { 1, 1, 1 });
            Vector u = new Vector(new double[] { 2, 3, 4 });

            Vector expected = new Vector(new double[] { 1, -2, 1 });
            Vector actual;

            actual = v * u;

            Assert.AreEqual(actual.Equals(expected), true);

        }

        [TestMethod]
        public void TestDif()
        {
            Vector v = new Vector(new double[] { 1, 1, 1 });
            Vector u = new Vector(new double[] { 2, 3, 4 });

            Vector expected = new Vector(new double[] { -1, -2, -3 });

            Vector actual = v - u;

            Assert.AreEqual(actual.Equals(expected), true);


        }


        [TestMethod]
        public void Testmultiplying()
        {
            Vector v = new Vector(new double[] { 1, 1, 1 });
            Vector u = new Vector(new double[] { 2, 3, 4 });

            double actual, expected = 9;

            actual = Vector.multiplying(v, u);

            Assert.AreEqual(actual.Equals(expected), true);

        }



    }
}
