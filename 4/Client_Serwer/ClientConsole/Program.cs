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
            Client c1 = new Client(port, address);

            while (true)
            {
                Console.Write("Enter message:");
                string message = Console.ReadLine();
                Console.WriteLine("Server answer: " + c1.sendMessage(message));
            }
            
        }
    }

}
