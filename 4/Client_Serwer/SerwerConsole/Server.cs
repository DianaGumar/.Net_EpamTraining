using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SerwerConsole
{
    public class Server
    {
        public Server(int port, string address, int countClients)
        {
            this.countClients = countClients;
            this.port = port;
            this.address = address;
            ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            builder = new StringBuilder();
            data = new byte[256];
            
        }

        int countClients;
        int port;
        string address;
        IPEndPoint ipPoint;
        Socket listenSocket;
        Socket handler;
        StringBuilder builder;
        byte[] data;
        int bytes;

        //for event generate
        public delegate void ServerHandler(string message, int id);
        public event ServerHandler Notify;

        /// <summary>
        /// start listening clients connections
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            bool sucsess = false;
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);
                // начинаем прослушивание
                listenSocket.Listen(countClients);
                sucsess = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return sucsess;
        }

        /// <summary>
        /// get clients message and send ansver
        /// </summary>
        public void Listen()
        {
            try
            {
                handler = listenSocket.Accept();
                
                builder.Clear();
                bytes = 0; // количество полученных байтов
                //data = new byte[256]; // буфер для получаемых данных

                do
                {
                    bytes = handler.Receive(data);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (handler.Available > 0);

                int id = 0;
                Notify?.Invoke(ReParse(builder.ToString(), ref id), id);

                //string message = "The message is delivered";
                data = Encoding.Unicode.GetBytes("Server: Hi, " + ReParse(builder.ToString(), ref id));
                handler.Send(data);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        /// <summary>
        /// get id client
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ReParse(string mes, ref int id)
        {

            Regex regex = new Regex(@"(\d+) (\w+)");
            Match match = regex.Match(mes);
            while (match.Success)
            {
                id = int.Parse(match.Groups[1].Value);
                mes = match.Groups[2].Value;

                match = match.NextMatch();

            }

            return mes;
        }

    }
}
