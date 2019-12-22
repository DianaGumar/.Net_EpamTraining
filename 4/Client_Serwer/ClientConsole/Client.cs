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
        public Client(int port, string address)
        {
            Id = DateTime.Now.Minute + DateTime.Now.Second;
            this.port = port;
            this.address = address;
            ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            
        }

        public int Id;
        /// <summary>
        /// server's port
        /// </summary>
        public int port; 
        /// <summary>
        /// server's address
        /// </summary>
        public string address;
        IPEndPoint ipPoint;
        Socket socket;

        byte[] data;
        StringBuilder builder;

        public delegate void ClientHandler(string message);
        public event ClientHandler Notify;

        /// <summary>
        /// send message to server
        /// </summary>
        /// <param name="message"></param>
        public void sendMessage(string message)
        {
            builder = new StringBuilder();
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //при каждой операции отправки сообщения подключение происходит заново (реализация пула соединений?)
                socket.Connect(ipPoint);
                data = Encoding.Unicode.GetBytes(Id + " " + message);
                socket.Send(data);

                data = new byte[256];              
                int bytes = 0; 
                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                
                Notify?.Invoke(builder.ToString());

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
