using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SerwerConsole
{
    public class Server
    {

        public Server(int port, string address)
        {
            this.port = port;
            this.address = address;
            ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            builder = new StringBuilder();
            data = new byte[256];
        }

        int port = 8005; // порт для приема входящих запросов
        string address;
        IPEndPoint ipPoint;
        Socket listenSocket;
        Socket handler;
        StringBuilder builder;
        byte[] data;
        int bytes;



        public bool Start()
        {
            bool sucsess = false;
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);
                // начинаем прослушивание
                listenSocket.Listen(10);
                sucsess = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return sucsess;
        }


        public string Listen()
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

                // отправляем ответ
                string message = "The message is delivered";
                data = Encoding.Unicode.GetBytes(message);
                handler.Send(data);
                // закрываем сокет
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DateTime.Now.ToShortTimeString() + ": " + builder.ToString();

        }



    }
}
