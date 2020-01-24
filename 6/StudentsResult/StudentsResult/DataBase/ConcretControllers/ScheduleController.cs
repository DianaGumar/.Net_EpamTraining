using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    public class ScheduleController : Controller<Objects.Schedule>
    {
        public ScheduleController(string DBName, string login, string password)
           : base(DBName, login, password)
        {

        }

        //todo переопределить методы удаления/обновления/добавления 
        // - с учётом внешних ключей  StudentsID и ScheduleID

    }
}
