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
            //list clients messages;
            Dictionary<int, List<string>> clients = new Dictionary<int, List<string>>();

            //add event handler
            s.Notify += (mes, id) =>
            {
                bool add = false;
                foreach(char c in clients.Keys)
                {
                    if(c == id)
                    {                      
                        add = true;
                    }
                }
                if (!add)
                {
                    clients.Add(id, new List<string>());
                }

                clients[id].Add(DateTime.Now.ToShortTimeString() + ": " + mes);

            };


            if (s.Start())
            {
                Console.WriteLine("Serwer started...");

                while (true)
                {
                    s.Listen();

                    foreach (List<string> c in clients.Values)
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
