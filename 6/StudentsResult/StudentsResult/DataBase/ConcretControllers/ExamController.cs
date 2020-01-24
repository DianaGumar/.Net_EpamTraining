using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    public class ExamController : Controller<Objects.Exam>
    {
        public ExamController(string DBName, string login, string password)
            : base(DBName, login, password)
        {

        }



    }
}
