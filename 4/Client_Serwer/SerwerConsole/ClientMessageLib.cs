using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwerConsole
{
    public class ClientMessageLib
    {
        /// <summary>
        /// add to exist lib or create new
        /// </summary>
        /// <param name="s"></param>
        public ClientMessageLib(Server s)
        {
            s.Notify += (mes, id) =>

            {
                bool add = false;
                foreach (char c in clients.Keys)
                {
                    if (c == id)
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

        }

        Dictionary<int, List<string>> clients = new Dictionary<int, List<string>>();

        /// <summary>
        /// get all messages by id one client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> GetMessages(int id)
        {
            return clients[id];
        }

        /// <summary>
        /// get all client's messages
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<string>> GetAllClients()
        {
            return clients;
        }
        

    }
}
