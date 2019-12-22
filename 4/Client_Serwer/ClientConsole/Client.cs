using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    public class Client
    {
        public Client(int port, string address, int Id)
        {
            this.Id = Id;
            this.port = port;
            this.address = address;
            ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            
        }

        public Client()
        {
            ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            
        }

        int Id;
        public int port = 8005; // порт сервера
        public string address = "127.0.0.1"; // адрес сервера
        IPEndPoint ipPoint;
        Socket socket;

        byte[] data;
        StringBuilder builder;

        public string sendMessage(string message)
        {
            builder = new StringBuilder();
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //при каждой операции отправки сообщения подключение происходит заново (реализация пула соединений?)
                socket.Connect(ipPoint);
                data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                // получаем ответ
                data = new byte[256]; // буфер для ответа              
                int bytes = 0; // количество полученных байт
                do
                {
                    //получение 
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                //Console.WriteLine("ответ сервера: " + builder.ToString());

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

             return builder.ToString();

        }
    }
}
