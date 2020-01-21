using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StudentsResult.DataBase
{
    //Abstract dao controller
    public abstract class AbstractController<E, K>
    {

        public abstract E[] Reed(K id);

        public abstract int Create(E obj);

        public abstract int Delete(K id);

        public abstract int Update(E obj);

        public static MySqlConnection GetConnection(string DBName, string login, string password)
        {

            string str = "Server=localhost;Database=" + DBName + ";Uid=" + login + ";Pwd=" + password;

            MySqlConnection conn = new MySqlConnection(str);

            return conn;
        }


    }
}
