using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    public class ResultController : Controller<Objects.Result>, IController
    {
        private ResultController(string DBName, string login, string password)
            : base(DBName, login, password)
        {

        }

        public static ResultController Instance;

        public static ResultController getInstance(string DBName, string login, string password)
        {
            if (Instance == null)
                Instance = new ResultController(DBName, login, password);
            return Instance;
        }

        //todo переопределить методы удаления/обновления/добавления 
        // - с учётом внешних ключей TeamID и ExamID


    }
}
