using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BynaryTree;
using Serializer;

namespace BynaryTreeTests
{
    [TestClass]
    public class BynaryTreeTests
    {
        /// <summary>
        /// just serialize and deserialize
        /// </summary>
        [TestMethod]
        public void TestSearisable()
        {

            Test t = new Test("Igor", 1, new DateTime(2019,12,30), 7);

            myXmlSerializer<Test> serializer = new myXmlSerializer<Test>();

            serializer.Serialize(t, @"E:\Epam\.Net_EpamTraining\5\BynaryTree\1.xml");


            Test tt = serializer.Deserialize(@"E:\Epam\.Net_EpamTraining\5\BynaryTree\1.xml");

            int expected = 0, actual = tt.CompareTo(t);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// just serialize and deserialize
        /// </summary>
        [TestMethod]
        public void TestSearisableArray()
        {

            Test t = new Test("Igor", 1, new DateTime(2019, 12, 30), 7);
            Test t2 = new Test("Masha", 1, new DateTime(2019, 12, 31), 5);

            Test[] tests = new Test[] { t, t2 };

            myXmlSerializer<Test[]> serializer = new myXmlSerializer<Test[]>();

            serializer.Serialize(tests, @"E:\Epam\.Net_EpamTraining\5\BynaryTree\1.xml");


            Test[] tests2 = serializer.Deserialize(@"E:\Epam\.Net_EpamTraining\5\BynaryTree\1.xml");

            int expected = 0, actual = 0;

            for(int i = 0; i < tests.Length; i++)
            {
                actual += tests[i].CompareTo(tests2[i]);
            }

            Assert.AreEqual(expected, actual);

        }
    }
}
