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
    public class Controller<T> : AbstractController_mssql<T, int> where T : class, IIntKey, new()
    {
        public Controller(string DBName, string login, string password)
        {

            this.DBName = DBName;
            this.login = login;
            this.password = password;
        }

        string DBName;
        string login;
        string password;


        /// <summary>
        /// reed all objects in table
        /// </summary>
        /// <param name="columnsNames"></param>
        /// <returns>list by type T</returns>
        public List<T> Reed(out string[] columnsName)
        {
            columnsName = new string[] { };
            using (var connection = GetConnection(DBName, login, password))
            {
                Table<T> entity = connection.GetTable<T>();
                return entity.ToList();

            }

        }

        public override T Reed(int id)
        {
            using (var connection = GetConnection(DBName, login, password))
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

        }

        public override int Create(T obj)
        {
            using (var connection = GetConnection(DBName, login, password))
            {
                var table = connection.GetTable<T>();

                table.InsertOnSubmit(obj);
                connection.SubmitChanges();

            }

            return 1;
        }

        public override int Delete(T obj)
        {
            if (Reed((int)obj.GetID()) != null)
            {
                using (var connection = GetConnection(DBName, login, password))
                {
                    var table = connection.GetTable<T>();
                    table.Attach(obj);
                    table.DeleteOnSubmit(obj);
                    connection.SubmitChanges();
                }
            }

            return 1;
        }

        public override int Update(T obj)
        {           

            //if object exist
            //var table = connection.GetTable<T>().Where(t => (int)t.GetID() == (int)obj.GetID());

            if (Reed((int)obj.GetID()) != null)
            {
                using (var con = GetConnection(DBName, login, password))
                {
                    con.GetTable<T>().Attach(obj);
                    con.Refresh(RefreshMode.KeepCurrentValues, obj);
                    con.SubmitChanges();
                }
            }

            return 1;
        }
    }
}
