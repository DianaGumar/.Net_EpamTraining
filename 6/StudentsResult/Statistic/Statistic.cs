using System;
using System.Collections.Generic;
using StudentsResult.Objects;
using StudentsResult.DataBase.Factory;
using StudentsResult.DataBase.ConcretControllers;
using Export;
using System.Linq;

namespace Statistic
{
    public class StatisticSession
    {

        public StatisticSession()
        {
            fc = new FactoryControllers();

            resultController
                = (ResultController)fc.CreateController(ControllersFormat.Result);

            studentController
                = (StudentController)fc.CreateController(ControllersFormat.Student);

            scheduleController
                = (ScheduleController)fc.CreateController(ControllersFormat.Schedule);

            teamController
                 = (TeamController)fc.CreateController(ControllersFormat.Team);
        }

        FactoryControllers fc;
        ResultController resultController;
        StudentController studentController;
        ScheduleController scheduleController;
        TeamController teamController;

        List<Result> results;
        string[] ColumnsNamesResult;

        public bool ExportExpelledStudents(int SessionNumber, string Path)
        {

            //find inadmissible marks
            if(results == null)
            {
                results = resultController.Reed(out ColumnsNamesResult);
            }        
            
            List<Result> ModifyResults = new List<Result>();
            foreach(Result r in results)
            {
                if(r.Mark < 4 || r.Mark == null)
                {
                    ModifyResults.Add(r);
                }
            }

            //find right session
            List<Schedule> schedules = new List<Schedule>();
            foreach (Result r in ModifyResults)
            {
                Schedule sc = scheduleController.Reed(r.ScheduleID);
                if(sc.SessionNumber == SessionNumber)
                {
                    schedules.Add(sc);
                }
                
            }

            List<Result> ModyfiModifyResults = new List<Result>();
            foreach (Result r in ModifyResults)
            {
                foreach (Schedule s in schedules)
                {
                    if (r.ScheduleID == s.ScheduleID)
                    {
                        ModyfiModifyResults.Add(r);
                    }

                }
            }

            ModifyResults.Clear();

            //find expelleds student
            List<Student> Expelledstudents = new List<Student>();
            foreach (Result r in ModyfiModifyResults)
            {
                Expelledstudents.Add(studentController.Reed(r.StudentsID));
            }

            //delete dublicate
            List<Student> ExpelledstudentsMod = Expelledstudents.Distinct().ToList<Student>();

            //find name team
            List<Team> teams = new List<Team>();
            foreach (Student s in ExpelledstudentsMod)
            {
                teams.Add(teamController.Reed(s.TeamID));
            }


            //---------------EXPORT

            List<object[]> objs = new List<object[]>();
            objs.Add(new object[] {"Team", "ExpelledStudents" });

            for(int i = 0; i < ExpelledstudentsMod.Count; i++)
            {
                objs.Add(new object[] { teams[i].Name, ExpelledstudentsMod[i].Name});
            }

            //принимает первым значением листа имена таблицы, остальными- значения
            return ExcelExport.Export(objs, Path, "ExpelledStudents_sessionNumber=" + SessionNumber);

        }



    }
}
