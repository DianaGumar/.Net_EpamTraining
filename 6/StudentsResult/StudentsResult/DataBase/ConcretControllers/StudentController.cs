using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    public class StudentController : Controller<Objects.Student>, IController
    {
        private StudentController(string DBName, string login, string password) 
            : base (DBName, login, password)
        {

        }

        public static StudentController Instance;

        public static StudentController getInstance(string DBName, string login, string password)
        {
            if (Instance == null)
                Instance = new StudentController(DBName, login, password);
            return Instance;
        }

    }
}
