using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.Objects
{
    public class Student :  IExported
    {
        /// <summary>
        /// for reflection
        /// </summary>
        public Student() { }

        /// <summary>
        /// for data base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="isMail"></param>
        /// <param name="date"></param>
        /// <param name="idTeam"></param>
        public Student(int id, string name, int isMail, DateTime date, int idTeam)
        {
            StudentsID = id;
            Name = name;
            IsMale = isMail;
            Date = date; //.ToString("yyyy-MM-dd");

            //Date.ParseExact(dateFormat, "yyyy-MM-dd", null);

            TeamID = idTeam;
        }

        public Student(string name, int isMail, DateTime date, int idTeam)
        {
            Name = name;
            IsMale = isMail;
            Date = date; //.ToString("yyyy-MM-dd");
            TeamID = idTeam;
        }

        //must be indenticle with data base fields names
        public int StudentsID;
        public string Name;
        public int IsMale;
        public DateTime Date;
        public int TeamID;

        /// <summary>
        /// for export
        /// </summary>
        /// <returns></returns>
        public object[] ToObject()
        {
            return new object[] { StudentsID, Name, IsMale, Date, TeamID };
        }
    }
}
