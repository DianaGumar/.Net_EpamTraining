using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.Objects
{
    public class Team : IExported
    {
        public Team() { }
        public Team(int id, string name)
        {
            TeamID = id;
            Name = name;
        }
        public Team(string name) { Name = name; }

        public int TeamID;
        public string Name;

        /// <summary>
        /// for export
        /// </summary>
        /// <returns></returns>
        public object[] ToObject()
        {
            return new object[] { TeamID, Name };
        }


    }
}
