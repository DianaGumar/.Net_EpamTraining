using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        
        static int port = 8005; 
        static string address = "127.0.0.1"; 
        static void Main(string[] args)
        {
            Client c = new Client(port, address);
            RussianToTranslit rs = new RussianToTranslit(c);

            while (true)
            {
                Console.Write("Enter message:");
                string message = Console.ReadLine();
                c.sendMessage(message);
            }
            
        }
    }

}
