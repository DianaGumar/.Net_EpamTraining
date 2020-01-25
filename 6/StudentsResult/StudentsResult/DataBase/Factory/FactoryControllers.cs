using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsResult.Objects;
using StudentsResult.DataBase.ConcretControllers;

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
        public FactoryControllers(string dbName, string login, string password)
        {
            DbName = dbName;
            Login = login;
            Password = password;
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
