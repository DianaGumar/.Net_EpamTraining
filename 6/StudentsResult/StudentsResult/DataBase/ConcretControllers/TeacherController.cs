using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    public class TeacherController : Controller<Objects.Teacher>, IController
    {
        private TeacherController(string DBName, string login, string password)
           : base(DBName, login, password)
        {

        }

        public static TeacherController Instance;

        public static TeacherController getInstance(string DBName, string login, string password)
        {
            if (Instance == null)
                Instance = new TeacherController(DBName, login, password);
            return Instance;
        }


    }
}
