using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult
{
    public class Student
    {
        /// <summary>
        /// for data base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="isMail"></param>
        /// <param name="date"></param>
        /// <param name="idTeam"></param>
        Student(int id, string name, int isMail, DateTime date, int idTeam)
        {
            Id = id;
            Name = name;
            IsMail = isMail;
            Date = date;
            IdTeam = idTeam;
        }

        Student(string name, int isMail, DateTime date, int idTeam)
        {
            Name = name;
            IsMail = isMail;
            Date = date;
            IdTeam = idTeam;
        }

        //must be indenticle with data base fields names
        public int Id;
        public string Name;
        public int IsMail;
        public DateTime Date;
        public int IdTeam;

    }
}
