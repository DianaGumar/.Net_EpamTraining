using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BynaryTree
{
    /// <summary>
    /// future part of bynary tree
    /// </summary>
    [Serializable]
    public class Test : ITreePart<Test>, IComparable
    {
        /// <summary>
        /// standart constructor for possibility to serialisable
        /// </summary>
        public Test()
        {

        }

        public Test(string StudentName, int TestName, DateTime PassTestDate, int Mark)
        {
            this.StudentName = StudentName;
            this.TestName = TestName;
            this.PassTestDate = PassTestDate;
            this.Mark = Mark;
        }

        public string StudentName;
        public int TestName;
        public DateTime PassTestDate;
        public int Mark;

        /// <summary>
        /// from Icomparable
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Test t = obj as Test;

            if(t != null)
            {
                return this.TestName - t.TestName;
            }
            else
                throw new Exception("Error. Can't compare two objects");
        }
    }
}
