﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace StudentsResult.DataBase
{
    public class Controller_recursy<T> : AbstractController<T, int> where T : class, new()
    {
        public Controller_recursy(string DBName, string login, string password)
        {
            connection = GetConnection(DBName, login, password);

            Entrails = GetEntrailsTypesNames();
            Name = typeof(T).Name;

        }

        MySqlConnection connection;

        private string Name;
        List<string>[] Entrails;

        /// <summary>
        /// reflection for jeneric class
        /// </summary>
        /// <returns></returns>
        private List<string>[] GetEntrailsTypesNames()
        {
            List<string>[] strs = new List<string>[2] { new List<string>(), new List<string>() };         

            Type type = typeof(T);

            var Entrails = type.GetFields();

            foreach(FieldInfo fieldsInfo in Entrails)
            {
                strs[0].Add(fieldsInfo.FieldType.Name);
                strs[1].Add(fieldsInfo.Name);
            }

            return strs;
        }

        /// <summary>
        /// reflection for jeneric class
        /// </summary>
        /// <returns></returns>
        private List<object> GetEntrailsValues(T obj)
        {
            List<object> strs = new List<object>();
            Type type = typeof(T);

            var Entrails = type.GetFields();

            foreach (FieldInfo fieldsInfo in Entrails)
            {
                strs.Add(fieldsInfo.GetValue(obj));
            }

            return strs;
        }


        /// <summary>
        /// set fields 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private T ReflectionWork(object[] obj)
        {
            T t = new T();

            Type type = typeof(T);            
            var fields = type.GetFields();

            int i = 0;
            foreach(FieldInfo fieldInfo in fields)
            {
                fieldInfo.SetValue(t, obj[i]);
                i++;
            }

            return t;
        }

        /// <summary>
        /// reed all objects in table
        /// </summary>
        /// <param name="columnsNames"></param>
        /// <returns>list by type T</returns>
        public List<T> Reed(out string[] columnsNames)
        {
            List<T> entity = new List<T>();
            columnsNames = null;

            string sql = "select * from " + Name + "s";

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


                    //take data
                    while (reader.Read())
                    {
                        object[] inside = new object[reader.FieldCount];
                        reader.GetValues(inside);
                        //возвращает объект T, todo
                        //полученный из массива значений Object
                        T t = ReflectionWork(inside);
                        entity.Add(t);

                    }

                    //reader.NextResult();
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

        public override T Reed(int id)
        {
            T entity = new T();

            string sql = "select * from " + Name + "s where " + Entrails[1][0] + "=" + id ;

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    object[] inside = new object[reader.FieldCount];
                    reader.GetValues(inside);
                    entity = ReflectionWork(inside);

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

        public override int Create(T obj)
        {
            //create sql query
            List<object> values = GetEntrailsValues(obj);

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into " + Name + "s (");
            int count = Entrails[0].Count;
            for (int i = 1; i < count - 1; i++)
            {
                sb.Append(Entrails[1][i] + ",");
            }
            sb.Append(Entrails[1][count - 1]);
            sb.Append(") values( ");
            for (int i = 1; i < count - 1; i++)
            {
                if (Entrails[0][i].Equals("DateTime"))
                {
                    values[i] = ((DateTime)values[i]).ToString("yyyy-MM-dd");
                }
                sb.Append("'" + values[i] + "', ");
            }
            if (Entrails[0][count - 1].Equals("DateTime"))
            {
                values[count - 1] = ((DateTime)values[count - 1]).ToString("yyyy-MM-dd");
            }
            sb.Append(values[count-1] + " )");

            string sql = sb.ToString();
//            insert into comission.entrants(EntrantName, ScoreDiploma, Student)
//            values('Mik', '5', 0);
            int countRowsUffected = 0;

            //----------------------------------

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                countRowsUffected = command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Connect to bd exeption: ", e.Message);
            }
            finally { connection.Close(); }

            return countRowsUffected;
        }

        public override int Delete(int id)
        {
            string sql = "delete * from " + Name + "s where " + Entrails[1][0] + "=" + id;
            int countRowsUffected = 0;

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                countRowsUffected = command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Connect to bd exeption: ", e.Message);
            }
            finally { connection.Close(); }

            return countRowsUffected;
        }

        public override int Update(T obj)
        {
            //create sql query
            List<object> values = GetEntrailsValues(obj);

            StringBuilder sb = new StringBuilder();
            sb.Append("update " + Name + "s set ");
            int count = Entrails[0].Count;
            for (int i = 1; i < count - 1; i++)
            {
                //проверка на злощастный тип даты- из за несовпдения форматов
                if (Entrails[0][i].Equals("DateTime"))
                {
                    values[i] = ((DateTime)values[i]).ToString("yyyy-MM-dd");
                }
                sb.Append(Entrails[1][i] + "= '" + values[i] + "', ");
            }
            if (Entrails[0][count - 1].Equals("DateTime"))
            {
                values[count - 1] = ((DateTime)values[count - 1]).ToString("yyyy-MM-dd");
            }
            sb.Append(Entrails[1][count-1] + "= '" + values[count-1] + "'");
            sb.Append(" where " + Entrails[1][0] + "= " + values[0]);

            string sql = sb.ToString();
            // update comission.entrants set EntrantName = 'Igor', ScoreDiploma = 8, Student = 0 
            //where EntrantID = 6;
            int countRowsUffected = 0;

            //----------------------------------

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                countRowsUffected = command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Connect to bd exeption: ", e.Message);
            }
            finally { connection.Close(); }

            return countRowsUffected;
        }
    }
}
