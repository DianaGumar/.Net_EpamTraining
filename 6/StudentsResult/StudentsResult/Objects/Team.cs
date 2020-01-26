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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Team t = obj as Team;
            if (t as Team == null)
                return false;

            return t.TeamID == this.TeamID;

        }

        public override int GetHashCode()
        {
            return TeamID;

        }
    }
}
