using System;
using StudentsResult.DataBase.ConcretControllers;
using System.Configuration;
using System.Collections.Specialized;

namespace StudentsResult.DataBase.Factory
{
    /// <summary>
    /// for comfortable
    /// </summary>
    public enum ControllersFormat { Student, Exam, Result, Schedule, Team }

    /// <summary>
    /// factory method
    /// </summary>
    public class FactoryControllers
    {
        public FactoryControllers()
        {

            DbName = ConfigurationManager.AppSettings["DBName"];
            Login = ConfigurationManager.AppSettings["Login"];
            Password = ConfigurationManager.AppSettings["Password"];

        }

        string DbName;
        string Login;
        string Password;

        public IController CreateController (ControllersFormat cont)
        {
            switch (cont)
            {
                case ControllersFormat.Exam:
                    return ExamController.getInstance(DbName, Login, Password);

                case ControllersFormat.Student:
                    return StudentController.getInstance(DbName, Login, Password);

                case ControllersFormat.Result:
                    return ResultController.getInstance(DbName, Login, Password);

                case ControllersFormat.Schedule:
                    return ScheduleController.getInstance(DbName, Login, Password);

                case ControllersFormat.Team:
                    return TeamController.getInstance(DbName, Login, Password);

                default:
                    throw new ArgumentException("Invalid format: " + cont.ToString());
            }
        }

    }

}
