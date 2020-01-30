using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
using System.Data.Linq;


namespace StudentsResult.DataBase
{
    //Abstract dao controller
    public abstract class AbstractController_mssql<E, K>
    {

        public abstract E Reed(K id);

        public abstract int Create(E obj);

        public abstract int Delete(E obj);

        public abstract int Update(E obj);

        public static DataContext GetConnection(string DBName, string login, string password)
        {

            string str = @"Data Source=.\SQLEXPRESS;Initial Catalog="+ DBName +";Integrated Security=True";

            DataContext conn = new DataContext(str);

            return conn;
        }

    }
}
