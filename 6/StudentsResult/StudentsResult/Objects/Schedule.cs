using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.Objects
{
    public class Schedule : IExported
    {
        public Schedule() { }

        public Schedule(int ScheduleID, int SessionNumber, int TeamID, int ExamID, DateTime DateExam, int TeacherID)
        {
            this.ScheduleID = ScheduleID;
            this.SessionNumber = SessionNumber;
            this.TeamID = TeamID;
            this.ExamID = ExamID;
            this.DateExam = DateExam;
            this.TeacherID = TeacherID;
        }
        public Schedule(int SessionNumber, int TeamID, int ExamID, DateTime DateExam, int TeacherID)
        {
            this.SessionNumber = SessionNumber;
            this.TeamID = TeamID;
            this.ExamID = ExamID;
            this.DateExam = DateExam;
            this.TeacherID = TeacherID;
        }


        public int ScheduleID;
        public int SessionNumber;
        public int TeamID;
        public int ExamID;
        public DateTime DateExam;
        public int TeacherID;

        /// <summary>
        /// for export
        /// </summary>
        /// <returns></returns>
        public object[] ToObject()
        {
            return new object[] { ScheduleID, SessionNumber, TeamID, ExamID, DateExam, TeacherID };
        }

    }
}
