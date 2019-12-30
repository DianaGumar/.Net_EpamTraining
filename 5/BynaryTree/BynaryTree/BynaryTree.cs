using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BynaryTree
{
    /// <summary>
    /// jeneric class bynary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BynaryTree <T> where T : IComparable
    {


        List<T> Data;

        private void Ballans()
        {

        }

        /// <summary>
        /// bouble sorted with compareTo method
        /// </summary>
        /// <param name="mas"></param>
        /// <returns></returns>
        private List<T> Sort(List<T> mas)
        {

            T temp;
            for (int i = 0; i < mas.Count - 1; i++)
            {
                for (int j = 0; j < mas.Count - i - 1; j++)
                {
                    if (mas[j + 1].CompareTo(mas[j]) > 0)
                    {
                        temp = mas[j + 1];
                        mas[j + 1] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;

        }

        /// <summary>
        /// add new item
        /// </summary>
        /// <param name="t"></param>
        public void Add(T t)
        {
            Data.Add(t);
        }

        /// <summary>
        /// print to string sorted
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Sort(this.Data);

            return base.ToString();
        }

        /// <summary>
        /// setialisation to xml
        /// </summary>
        /// <returns></returns>
        public bool ToXML()
        {
            Sort(this.Data);

            return true;
        }

    }
}
