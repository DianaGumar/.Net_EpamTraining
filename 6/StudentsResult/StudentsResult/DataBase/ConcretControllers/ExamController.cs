using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    public class ExamController : Controller<Objects.Exam>, IController
    {      
        private ExamController(string DBName, string login, string password)
            : base(DBName, login, password)
        { }

        public static ExamController Instance;

        public static ExamController getInstance(string DBName, string login, string password)
        {
            if (Instance == null)
                Instance = new ExamController(DBName, login, password);
            return Instance;
        }

    }

}
