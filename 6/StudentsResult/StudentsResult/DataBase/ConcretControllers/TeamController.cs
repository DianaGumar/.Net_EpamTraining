using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult.DataBase.ConcretControllers
{
    public class TeamController : Controller<Objects.Team>, IController
    {
        private TeamController(string DBName, string login, string password)
           : base(DBName, login, password)
        {

        }

        public static TeamController Instance;

        public static TeamController getInstance(string DBName, string login, string password)
        {
            if (Instance == null)
                Instance = new TeamController(DBName, login, password);
            return Instance;
        }


    }
}
