using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace StudentsResult.DataBase
{
    public class Controller<T> : AbstractController<T, int> where T : class
    {
        public Controller(string DBName, string login, string password)
        {
            MySqlConnection connection = GetConnection(DBName, login, password);

            Name = typeof(T).FullName;
        }

        MySqlConnection connection;

        private string Name;
        List<string> Entrails;

        /// <summary>
        /// reflection for jeneric class
        /// </summary>
        /// <returns></returns>
        private List<string> GetEntrails()
        {
            List<string> strs = new List<string>();

            Type type = typeof(T);

            var Entrails = type.GetFields();

            foreach(FieldInfo fieldsInfo in Entrails)
            {
                strs.Add(fieldsInfo.Name);
            }

            return strs;
        }   

        public List<T[]> Reed(out string[] columnsNames)
        {
            List<T[]> entity = new List<T[]>();
            columnsNames = null;



            string sql = "select * from Students";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //take columns names
                    columnsNames = new string[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnsNames[i] = reader.GetName(i);
                    }
                    //entity.Add(names);

                    //take data
                    while (reader.Read())
                    {
                        T[] inside = new T[reader.FieldCount];
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

            return entity;
        }

        public override T[] Reed(int id)
        {
            return new T[2]; 
        }

        public override int Create(T obj)
        {
            throw new NotImplementedException();
        }

        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override int Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
