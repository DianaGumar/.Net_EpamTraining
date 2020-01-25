using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    public class ScheduleController : Controller<Objects.Schedule>, IController
    {
        private ScheduleController(string DBName, string login, string password)
           : base(DBName, login, password)
        {

        }

        public static ScheduleController Instance;

        public static ScheduleController getInstance(string DBName, string login, string password)
        {
            if (Instance == null)
                Instance = new ScheduleController(DBName, login, password);
            return Instance;
        }


        //todo переопределить методы удаления/обновления/добавления 
        // - с учётом внешних ключей  StudentsID и ScheduleID

    }
}
