using System;
using System.Data.Linq.Mapping;

namespace StudentsResult.Objects
{
    [Table(Name = "Teachers")]
    public class Teacher
    {

        public Teacher() { }

        public Teacher(string Name)
        {
            this.Name = Name;
        }

        public Teacher(int TeacherID, string Name)
        {
            this.TeacherID = TeacherID;
            this.Name = Name;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int TeacherID;

        [Column(Name = "Name")]
        public string Name;

        /// <summary>
        /// for export
        /// </summary>
        /// <returns></returns>
        public object[] ToObject()
        {
            return new object[] { TeacherID, Name };
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Teacher t = obj as Teacher;
            if (t as Teacher == null)
                return false;

            return t.TeacherID == this.TeacherID;

        }

        public override int GetHashCode()
        {
            return this.TeacherID;

        }


    }

}
