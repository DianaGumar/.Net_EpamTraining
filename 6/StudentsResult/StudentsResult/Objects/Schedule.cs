using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace StudentsResult.Objects
{
    [Table(Name = "Schedules")]
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

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ScheduleID;

        [Column(Name = "SessionNumber")]
        public int SessionNumber;

        [Column(Name = "TeamID")]
        public int TeamID;

        [Column(Name = "ExamID")]
        public int ExamID;

        [Column(Name = "DateExam")]
        public DateTime DateExam;

        [Column(Name = "TeacherID")]
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
