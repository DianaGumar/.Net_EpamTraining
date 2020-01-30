using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Data.Linq;

using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace StudentsResult.DataBase
{
    public class Controller<T> : AbstractController_mssql<T, int> where T : class, new()
    {
        public Controller(string DBName, string login, string password)
        {
            connection = GetConnection(DBName, login, password);
        }

        DataContext connection;

        /// <summary>
        /// reed all objects in table
        /// </summary>
        /// <param name="columnsNames"></param>
        /// <returns>list by type T</returns>
        public List<T> Reed(out string[] columnsName)
        {
            columnsName = new string[] { };
            try
            {
                Table<T> entity = connection.GetTable<T>();
                return entity.ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine("Connect to bd exeption: ", e.Message);
            }

            return null;
        }

        public override T Reed(int id)
        {
            try
            {
                // get the table by the type passed in
                var table = connection.GetTable<T>();

                // get the metamodel mappings (database to domain objects)
                MetaModel modelMap = table.Context.Mapping;

                // get the data members for this type
                ReadOnlyCollection<MetaDataMember> dataMembers
                    = modelMap.GetMetaType(typeof(T)).DataMembers;

                // find the primary key field name
                // by checking for IsPrimaryKey
                string pk = (dataMembers.Single<MetaDataMember>(m => m.IsPrimaryKey)).Name;

                // return a single object where the id argument
                // matches the primary key field value
                return table.SingleOrDefault<T>(delegate (T t)
                {
                    //some reflection
                    Type type = typeof(T);
                    var Entrails = type.GetFields();
                    var ooo = Entrails[0].GetValue(t);

                    return (int)ooo == id;
                });

            }
            catch (Exception e)
            {
                Console.WriteLine("Connect to bd exeption: ", e.Message);
            }

            return null;
        }

        public override int Create(T obj)
        {
            try
            {
                var table = connection.GetTable<T>();

                table.InsertOnSubmit(obj);
                connection.SubmitChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine("Connect to bd exeption: ", e.Message);
            }

            return 1;
        }

        public override int Delete(T obj)
        {
            try
            {
                Type tType = obj.GetType();
                Object newObj = Activator.CreateInstance(tType, new object[0]);           

                // get the properties for the passed in object
                PropertyDescriptorCollection originalProps = TypeDescriptor.GetProperties(obj);

                // copy over the content of the passed in data
                // to the new object of the same type –
                // this gives us an object
                // that is not tied to any existing data context
                foreach (PropertyDescriptor currentProp in originalProps)
                {
                    if (currentProp.Attributes[typeof( System.Data.Linq.Mapping.ColumnAttribute)] !=  null)
                    {
                        object val = currentProp.GetValue(obj);
                        currentProp.SetValue(newObj, val);

                    }

                }

                // to work with disconnected data, attach the new                 
                // object to the table, call delete
                // on submit, and then submit changes

                var table = connection.GetTable<T>();
                table.Attach((T)newObj, true);
                table.DeleteOnSubmit((T)newObj);
                connection.SubmitChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine("Connect to bd exeption: ", e.Message);
            }

            return 1;
        }

        public override int Update(T obj)
        {
            try
            {
                // create a new instance of the object
                Object newObj = Activator.CreateInstance(typeof(T), new object[0]);

                PropertyDescriptorCollection originalProps = TypeDescriptor.GetProperties(obj);

                // set the new object to match the passed in object
                foreach (PropertyDescriptor currentProp in originalProps)
                {
                    if (currentProp.Attributes[typeof(System.Data.Linq.Mapping.ColumnAttribute)] != null)
                    {
                        object val = currentProp.GetValue(obj);
                        currentProp.SetValue(newObj, val);

                    }
                }

                // attach the new object to a new data context and
                // call submit changes on the context
                var table = connection.GetTable<T>();

                table.Attach((T)newObj, true);
                connection.SubmitChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine("Connect to bd exeption: ", e.Message);
            }

            return 1;
        }
    }
}
