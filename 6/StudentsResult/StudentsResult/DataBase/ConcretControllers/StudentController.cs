using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    public class StudentController : Controller<Objects.Student>
    {
        public StudentController(string DBName, string login, string password) 
            : base (DBName, login, password)
        {

        }



    }
}
