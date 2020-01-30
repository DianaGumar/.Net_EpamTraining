using System;
using System.Data.Linq.Mapping;

namespace StudentsResult.Objects
{
    [Table(Name = "Exams")]
    public class Exam : IExported

    {
        public Exam() { }

        public Exam(int id, string name, int exam)
        {
            ExamID = id;
            Name = name;
            IsExam = exam;
        }

        public Exam(string name, int exam)
        {
            Name = name;
            IsExam = exam;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ExamID;
        [Column(Name = "Name")]
        public string Name;
        [Column(Name = "IsExam")]
        public int? IsExam;

        /// <summary>
        /// for export
        /// </summary>
        /// <returns></returns>
        public object[] ToObject()
        {
            return new object[] { ExamID, Name, IsExam };
        }

    }
}
