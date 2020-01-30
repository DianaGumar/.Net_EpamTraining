using System;
using System.Data.Linq.Mapping;

namespace StudentsResult.Objects
{
    [Table(Name = "Students")]
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
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int StudentsID;

        [Column(Name = "Name")]
        public string Name;

        [Column(Name = "IsMale")]
        public int IsMale;

        [Column(Name = "Date")]
        public DateTime Date;

        [Column(Name = "TeamID")]
        public int TeamID;

        /// <summary>
        /// for export
        /// </summary>
        /// <returns></returns>
        public object[] ToObject()
        {
            return new object[] { StudentsID, Name, IsMale, Date, TeamID };
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Student student = obj as Student;
            if (student as Student == null)
                return false;

            return student.StudentsID == this.StudentsID;

        }

        public override int GetHashCode()
        {
            return StudentsID;

        }

    }
}
