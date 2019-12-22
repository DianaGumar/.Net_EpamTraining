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
        static int countClients = 10;
        static void Main(string[] args)
        {
            Server s = new Server(port, address, countClients);
            ClientMessageLib cl = new ClientMessageLib(s);

            if (s.Start())
            {
                Console.WriteLine("Serwer started...");

                while (true)
                {
                    s.Listen();

                    foreach (List<string> c in cl.GetAllClients().Values)
                    {
                        foreach (string cc in c)
                        {
                            Console.WriteLine("__" + cc);
                        }
                        Console.WriteLine("\b");
                    }
                }
            }

        }

    }

}
