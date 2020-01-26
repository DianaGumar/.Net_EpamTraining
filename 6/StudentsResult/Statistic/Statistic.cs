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

            examController
                 = (ExamController)fc.CreateController(ControllersFormat.Exam);
        }

        FactoryControllers fc;
        ResultController resultController;
        StudentController studentController;
        ScheduleController scheduleController;
        TeamController teamController;
        ExamController examController;

        List<Result> results;
        List<Schedule> schedules;
        List<Exam> exams;
        List<Student> students;
        List<Team> teams;
        string[] ColumnsNamesResult;

        //todo change loggic with one necessary sql query

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
            List<Schedule> schedules = GetSession(SessionNumber, ModifyResults);

            List<Result> ModyfiModifyResults = ModyfyResults(ModifyResults, schedules);

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

        public bool ExportSessionReSult(int SessionNumber, string Path)
        {
            if (results == null)
            {
                results = resultController.Reed(out ColumnsNamesResult);
            }

            //find right session
            List<Schedule> schedules = GetSession(SessionNumber, results);

            //modyfi results for ryght session
            List<Result> modifyResults = 
                ModyfyResults(results, schedules).Distinct().ToList<Result>();

            List<Student> students = new List<Student>();
            foreach (Result r in modifyResults)
            {
                students.Add(studentController.Reed(r.StudentsID));
            }

            List<Exam> exams = new List<Exam>();
            List<Team> teams = new List<Team>();
            foreach(Schedule sc in schedules)
            {
                exams.Add(examController.Reed(sc.ExamID));
                teams.Add(teamController.Reed(sc.TeamID));
            }

            //---------------EXPORT
            //delete dublicate
            List<Team> teamsMod = teams.Distinct().ToList<Team>();

            List<object[]>[] objss = new List<object[]>[teamsMod.Count()];
            List<object[]> objs = new List<object[]>();

            //add data               
            objs.Add(new object[] { "Team", "Student", "Subject", "Mark" });

            //finding on one line
            for (int j = 0; j < students.Count(); j++)
            {
                objs.Add(new object[] {
                            teams[j].Name,
                            students[j].Name,
                            exams[j].Name,
                            modifyResults[j].Mark});
            }

            //division into groups
            for (int i = 0; i < teamsMod.Count(); i++)
            {
                List<object[]> objs_1 = new List<object[]>();
                objs_1.Add(new object[] { "Team", "Student", "Subject", "Mark" });

                foreach (object[] o in objs)
                {
                    if (o[0].ToString() == teamsMod[i].Name)
                    {
                        objs_1.Add(o);
                    }
                }

                objss[i] = objs_1;

            }


            //для каждой группы своя таблица
            //должно быть соответствие названий групп тем названиям,
            //что находятся в i-ом objss
            int result = 0;          
            for(int i = 0; i < objss.Count(); i++)
            {
                //export data
                result += ExcelExport.Export(objss[i], 
                    Path,
                    @"Exported_Session_"+ SessionNumber +"_results_" + objss[i][1][0].ToString())
                ? 1 : 0;
            }

            return result > 0 ? true : false;
            
        }

        public bool ExportMiddleGroupResults(string Path)
        {

            if (results == null)
            {
                results = resultController.Reed(out ColumnsNamesResult);
            }

            //find existing sessions number
            List<Schedule> schedules = new List<Schedule>();
            foreach (Result r in results)
            {
                schedules.Add(scheduleController.Reed(r.ScheduleID));
            }

            List<Team> teams = new List<Team>();
            foreach (Schedule s in schedules)
            {
                teams.Add(teamController.Reed(s.TeamID));
            }

            List<object[]> ob = new List<object[]>();

            List<int> sessions = new List<int>();

            for (int i = 0; i < schedules.Count(); i ++)
            {
                ob.Add(new object[] {schedules[i].SessionNumber, teams[i].Name, results[i].Mark });

                sessions.Add(schedules[i].SessionNumber);
                
            }

            List<Team> teamsMod = teams.Distinct().ToList<Team>();

            //find original values in seccion numbers
            List<int> sessionsMod = sessions.Distinct().ToList<int>();

            List<object[]>[] objss= new List<object[]>[sessionsMod.Count()];

            //finding min max middle
            for(int i = 0; i < sessionsMod.Count(); i++)
            {
                List<object[]> objs = new List<object[]>();

                foreach (object[] o in ob)
                {
                    if(o[0].ToString() == sessionsMod[i].ToString())
                    {
                        objs.Add(o);
                    }
                }

                objss[i] = objs;
            }

            List<object[]> result = new List<object[]>();
            result.Add(new object[] {"Session_number", "Team", "Min_mark", "Middle_mark", "Max_mark" });

            foreach (List<object[]> obj in objss)
            {               
                foreach (Team t in teamsMod)
                {
                    int min = 100;
                    int max = 0;
                    float middle = 0;
                    int count = 0;

                    foreach (object[] o in obj)
                    {
                        if (o[1].ToString() == t.Name)
                        {
                            count++;
                            middle += (int)o[2];
                            if((int)o[2] > max)
                                max = (int)o[2];

                            if ((int)o[2] < min)
                                min = (int)o[2];
                        }
                    }

                    middle = middle / count;

                    result.Add(new object[] { obj[1][0], t.Name, min, middle, max });

                }
               
            }


            //---------------EXPORT

            ExcelExport.Export(result, Path, "Middle_groups_results");

            return true;
        }


        private List<Schedule> GetSession(int SessionNumber, List<Result> ModifyResults)
        {
            //find right session
            List<Schedule> schedules = new List<Schedule>();
            foreach (Result r in ModifyResults)
            {
                Schedule sc = scheduleController.Reed(r.ScheduleID);
                if (sc.SessionNumber == SessionNumber)
                {
                    schedules.Add(sc);
                }

            }

            return schedules;
        }

        //for finds necessary session results
        private List<Result> ModyfyResults(List<Result> ModifyResults, List<Schedule> schedules)
        {

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

            return ModyfiModifyResults;
        }



    }
}
