using System;
using System.Data.Linq.Mapping;

namespace StudentsResult.Objects
{
    [Table(Name = "Teams")]
    public class Team : IExported, IIntKey
    {
        public Team() { }
        public Team(int id, string name, string Profession)
        {
            TeamID = id;
            Name = name;
            this.Profession = Profession;
        }
        public Team(string name, string Profession)
        {
            Name = name;
            this.Profession = Profession;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int TeamID;

        [Column(Name = "Name")]
        public string Name;

        [Column(Name = "Profession")]
        public string Profession;

        /// <summary>
        /// for export
        /// </summary>
        /// <returns></returns>
        public object[] ToObject()
        {
            return new object[] { TeamID, Name, Profession };
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

        public int GetID()
        {
            return TeamID;
        }
    }
}
