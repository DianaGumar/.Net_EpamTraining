﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace StudentsResult.DataBase
{
    public class Controller<T> : AbstractController<T, int> where T : class, new()
    {
        public Controller(string DBName, string login, string password)
        {
            connection = GetConnection(DBName, login, password);

            Entrails = GetEntrails();
            Name = typeof(T).Name;

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

        public override T Reed(int id)
        {
            T entity = new T();

            string sql = "select * from " + Name + "s where " + Entrails[0] + "=" + id ;

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
            throw new NotImplementedException();
        }

        public override int Delete(int id)
        {
            string sql = "delete * from " + Name + "s where " + Entrails[0] + "=" + id;
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
            StringBuilder sb = new StringBuilder();
            sb.Append("update" + Name + "s set ");
            for(int i = 1; i < Entrails.Count-1; i++)
            {
                sb.Append(Entrails[i] + "= ,");
            }
            sb.Append(Entrails[Entrails.Count] + "= ");
            sb.Append("where " + Entrails[0] + "= ");

            string sql = sb.ToString();
           // update comission.entrants set EntrantName = 'Igor', ScoreDiploma = 8, Student = 0 where EntrantID = 6;
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
    }
}
