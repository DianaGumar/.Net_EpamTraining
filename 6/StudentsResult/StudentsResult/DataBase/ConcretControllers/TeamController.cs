using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    public class TeamController : Controller<Objects.Team>
    {
        public TeamController(string DBName, string login, string password)
           : base(DBName, login, password)
        {

        }

    }
}
