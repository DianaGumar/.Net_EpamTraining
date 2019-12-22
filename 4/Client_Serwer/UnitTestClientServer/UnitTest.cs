using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConsole;
using SerwerConsole;
using System.Collections.Generic;

namespace UnitTestClientServer
{

    [TestClass]
    public class UnitTestClientServer
    {
        static int port = 8005;
        static string address = "127.0.0.1";
        static int countClients = 10;

        /// <summary>
        /// test start serwer
        /// </summary>
        [TestMethod]
        public void TestStartSerwer()
        {
            bool actual = false, expected = true;
            Server s = new Server(port, address, countClients);

            actual = s.Start();

            Assert.AreEqual(expected, actual);

        }


        /// <summary>
        /// all kirrils symbols pars to translit
        /// </summary>
        [TestMethod]
        public void TestRussianToTranslit()
        {
            string actual, expected = "privet";

            actual = RussianToTranslit.ToTranslit("привет");

            Assert.AreEqual(expected, actual);
        }



        }

}
