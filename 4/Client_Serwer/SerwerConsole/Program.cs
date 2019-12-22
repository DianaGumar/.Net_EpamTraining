using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SerwerConsole
{
    class Program
    {
        static int port = 8005;
        static string address = "127.0.0.1";
        static void Main(string[] args)
        {
            Server s = new Server(port, address);

            if (s.Start())
            {
                Console.WriteLine("Serwer started...");

                while (true)
                {
                    Console.WriteLine(s.Listen());
                }
            }



        }
    }

}
