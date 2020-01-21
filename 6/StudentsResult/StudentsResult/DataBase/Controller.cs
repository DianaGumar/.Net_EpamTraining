using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StudentsResult.DataBase
{
    public class Controller<T> : AbstractController<Object, int>
    {
        public Controller(string DBName, string login, string password)
        {
            this.DBName = DBName;
            this.login = login;
            this.password = password;
        }

        private readonly string sql;
        private readonly string DBName;
        private readonly string login;
        private readonly string password;

        public override List<Object[]> Reed()
        {
            List<Object[]> entity = new List<Object[]>();
            MySqlConnection connection = GetConnection(DBName, login, password);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //take columns names
                    Object[] names = new Object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        names[i] = reader.GetName(i);
                    }
                    entity.Add(names);

                    //take data
                    while (reader.Read())
                    {
                        Object[] inside = new Object[reader.FieldCount];
                        reader.GetValues(inside);
                        entity.Add(inside);

                    }

                    reader.NextResult();
                }
                reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Connect to bd exeption: ", e.Message);
            }
            finally { connection.Close(); }

            //List<T[]> ent = T.Parse(entity);
            return entity;
        }

        public List<Object> Reed(int id)
        {
            return new List<object>();
        }

        public override int Create(Object obj)
        {
            throw new NotImplementedException();
        }

        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override int Update(Object obj)
        {
            throw new NotImplementedException();
        }
    }
}
