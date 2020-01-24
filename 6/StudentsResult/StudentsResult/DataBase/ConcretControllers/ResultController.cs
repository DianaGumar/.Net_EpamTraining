using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    class ResultController : Controller<Objects.Result>
    {
        public ResultController(string DBName, string login, string password)
            : base(DBName, login, password)
        {

        }

        //todo переопределить методы удаления/обновления/добавления 
        // - с учётом внешних ключей TeamID и ExamID


    }
}
