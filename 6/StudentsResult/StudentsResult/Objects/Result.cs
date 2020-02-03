using System;
using System.Data.Linq.Mapping;

namespace StudentsResult.Objects
{
    [Table(Name = "Results")]
    public class Result : IExported, IIntKey
    {
        public Result() { }

        public Result(int ResultsID, int StudentsID, int ScheduleID, int Mark)
        {
            this.ResultsID = ResultsID;
            this.StudentsID = StudentsID;
            this.ScheduleID = ScheduleID;
            this.Mark = Mark;
        }
        public Result(int StudentsID, int ScheduleID, int Mark)
        {
            this.StudentsID = StudentsID;
            this.ScheduleID = ScheduleID;
            this.Mark = Mark;
                 
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ResultsID;

        [Column(Name = "StudentsID")]
        public int StudentsID;

        [Column(Name = "ScheduleID")]
        public int ScheduleID;

        [Column(Name = "Mark")]
        public int Mark;

        /// <summary>
        /// for export
        /// </summary>
        /// <returns></returns>
        public object[] ToObject()
        {
            return new object[] { ResultsID, StudentsID, ScheduleID, Mark };
        }

        public int GetID()
        {
            return ResultsID;
        }
    }
}
