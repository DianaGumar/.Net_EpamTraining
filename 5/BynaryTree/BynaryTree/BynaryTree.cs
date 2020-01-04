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
    class BynaryTree <T> where T : ITreePart<T>, IComparable
    {

        public T Root;
        public int CountNodes = 0;


        /// <summary>
        /// add new item
        /// </summary>
        /// <param name="t"></param>
        public void Add(T t)
        {
            if(Root == null)
            {
                Root = t;
            }
            else
            {
                AddRecursive(Root, t);
            }
          
            CountNodes++;
        }

        /// <summary>
        /// find right plase to add tree's element (bynary tree balans)
        /// </summary>
        /// <param name="t"></param>
        /// <param name="Root"></param>
        private void AddRecursive(T Root, T t)
        {
            if (t.CompareTo(Root) < 0)
            {
                if(Root.LChild == null)
                {
                    Root.LChild = t;
                }
                else
                {
                    AddRecursive(Root.LChild, t);
                }
            }
            else
            {
                if (Root.RChild == null)
                {
                    Root.RChild = t;
                }
                else
                {
                    AddRecursive(Root.RChild, t);
                }
            }
        }

        public void DeleteOll()
        {
            //gc will do other work
            Root = null;
            CountNodes = 0;
        }

        //todo реализовать для проверки алгоритма балансировки
        public bool Delete(T value)
        {

            return true;
        }

        /// <summary>
        /// find and return bool value
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Find(T t)
        {
            T parent;
            return FindWithParent(t, out parent) != null;
        }

        /// <summary>
        /// find and return finding value with parant
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private T FindWithParent(T value, out T parent)
        {
            T current = Root;
            parent = null;

            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result > 0)
                {
                    //if finding value < - turn to left

                    parent = current;
                    current = current.LChild;
                }
                else if (result < 0)
                {
                    //if finding value > - turn to right
                    parent = current;
                    current = current.RChild;
                }
                else
                {
                    // if equals - stop
                    break;
                }
            }

            return current;
        }

        //todo алгоритм балансировки
        public bool Balanse()
        {
            return true;
        }

        /// <summary>
        /// treveling tree
        /// </summary>
        /// <returns></returns>
        private List<T> Print()
        {
            return new List<T>();
        }





        /// <summary>
        /// print to string sorted
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            List<T> list = Print();
            StringBuilder sb = new StringBuilder();
            foreach(T l in list)
            {
                sb.Append(l.ToString());
                sb.Append("\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// setialisation to xml
        /// </summary>
        /// <returns></returns>
        public bool ToXML()
        {
            List<T> list = Print();

            return true;
        }

        public bool FromXML(string fileName)
        {
            return true;
        }

    }
}
