using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCDTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestgetGCD_Euclidean()
        {          

            //arrange
            int actual, expected = 4464;
            int x = 624960, y = 49104;

            //act
            actual = GCD.GCD.getGCD_Euclidean(x, y);

            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}
