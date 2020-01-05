﻿using System;
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
        /// just array serialize and deserialize
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

        /// <summary>
        /// serialize and deserialize array in tree and check correct work IEnumerator
        /// </summary>
        [TestMethod]
        public void TestSearisableArrayTree()
        {
            Test t = new Test("Igor", 1, new DateTime(2019, 12, 30), 7);
            Test t2 = new Test("Masha", 2, new DateTime(2019, 12, 31), 5);
            Test t3 = new Test("Alekssey", 4, new DateTime(2019, 12, 29), 8);
            Test t4 = new Test("Masha", 3, new DateTime(2019, 12, 30), 9);

            BynaryTree<Test> tree = new BynaryTree<Test>();

            tree.Add(t);
            tree.Add(t2);
            tree.Add(t3);
            tree.Add(t4);

            //check correct work Print method
            Test[] tt = new Test[tree.CountNodes];
            int i = 0;
            foreach (Test test in tree)
            {
                tt[i] = test;

                i++;
            }

            myXmlSerializer<Test[]> serializer = new myXmlSerializer<Test[]>();

            serializer.Serialize(tt, @"E:\Epam\.Net_EpamTraining\5\BynaryTree\1.xml");


            Test[] tests2 = serializer.Deserialize(@"E:\Epam\.Net_EpamTraining\5\BynaryTree\1.xml");

            int expected = 0, actual = 0;

            for (i = 0; i < tt.Length; i++)
            {
                actual += tt[i].CompareTo(tests2[i]);
            }

            Assert.AreEqual(expected, actual);

        }

    }
}
