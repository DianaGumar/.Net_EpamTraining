using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.Objects
{
    public class Result : IExported
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

        public int ResultsID;
        public int StudentsID;
        public int ScheduleID;
        public int? Mark;

        /// <summary>
        /// for export
        /// </summary>
        /// <returns></returns>
        public object[] ToObject()
        {
            return new object[] { ResultsID, StudentsID, ScheduleID, Mark };
        }

    }
}
