using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult
{
    public class Exam
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

        public int ExamID;
        public string Name;
        public int IsExam;

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
