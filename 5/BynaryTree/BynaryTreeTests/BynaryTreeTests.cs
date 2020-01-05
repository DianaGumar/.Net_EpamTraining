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
            BynaryTree<Test> tree = new BynaryTree<Test>();

            myXmlSerializer<Test> serializer = new myXmlSerializer<Test>();

            serializer.Serialize(t, "1.xml");

        }
    }
}
