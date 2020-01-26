using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic
{
    public class Sort
    {
        public static List<object[]> sortBy(int column, bool isString, List<object[]> obj)
        {
            object[] names = obj[0];
            //remove names line
            obj.Remove(obj[0]);

            IEnumerable<object[]> objSorted;

            if (isString == false)
            {
                objSorted = obj.OrderBy(i => i[column]);
            }
            else
            {
                objSorted = obj.OrderBy(i => i[column]);
                //todo nead to use IComparer for good string sort
            }

            List<object[]> objSort = objSorted.ToList();

            obj.Clear();

            //return names at first row
            obj.Add(names);
            //add the remaining values
            foreach (object[] o in objSort)
                obj.Add(o);


            return obj;
        }

    }
}
