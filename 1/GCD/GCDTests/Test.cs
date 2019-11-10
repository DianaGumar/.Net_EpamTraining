using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCDTests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestgetGCD_Euclidean_2()
        {          

            //arrange
            int actual, expected = 4464;
            int x = 624960, y = 49104;

            //act
            actual = GCD.GCD.getGCD_Euclidean(x, y);

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestgetGCD_Euclidean_4()
        {          

            //arrange
            int actual, expected = 6;
            int x = 78, y = 294, z = 570, k = 36;

            //act
            actual = GCD.GCD.getGCD_Euclidean(x, y, z, k);

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestgetGCDbinaryEuclidean()
        {

            //arrange
            int actual, expected = 4464;
            int x = 624960, y = 49104;

            //act
            actual = GCD.GCD.getGCDbinaryEuclidean(x, y);

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestgetGCDbinaryEuclidean_zero()
        {

            //arrange
            int actual, expected = 0;
            int x = 0, y = 0;

            //act
            actual = GCD.GCD.getGCDbinaryEuclidean(x, y);

            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}
