using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCDTests
{
    [TestClass]
    public class TestRecursive
    {
        [TestMethod]
        public void TestgetGCD_Euclidean()
        {

            //arrange
            int actual, expected = 4464;
            int x = 624960, y = 49104;
            long time = 0;

            //act
            actual = GCD.GCD.getGCD_Euclidean(x, y, out time);

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestgetGCD_Euclidean_4()
        {

            //arrange
            int actual, expected = 6;
            int x = 78, y = 294, z = 570, k = 36;

            long timeTick;

            //act
            actual = GCD.GCD.getGCD_Euclidean(x, y, z, k, out timeTick);

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestgetGCDbinaryEuclidean()
        {

            //arrange
            int actual, expected = 4464;
            int x = 624960, y = 49104;

            long timeTick;

            //act
            actual = GCD.GCD.getGCDbinaryEuclidean(x, y, out timeTick);

            //assert
            Assert.AreEqual(expected, actual);

        }

    }


    [TestClass]
    public class TestIterative
    {
        [TestMethod]
        public void TestgetGCD_EuclidianIt()
        {

            //arrange
            int actual, expected = 4464;
            int x = 624960, y = 49104;

            long timeTick = 0;

            //act
            actual = GCD.GCD.getGCD_EuclidianIt(x, y, out timeTick);

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestgetGCDbinaryEuclideanIt()
        {

            //arrange
            int actual, expected = 4464;
            int x = 624960, y = 49104;

            long timeTick = 0;

            //act
            actual = GCD.GCD.getGCDbinaryEuclideanIt(x, y, out timeTick);
            

            //assert
            Assert.AreEqual(expected, actual);

        }

    }

}
