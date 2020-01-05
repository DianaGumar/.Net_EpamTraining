using System;
using System.Collections;
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
    public class BynaryTree <T> : IEnumerable where T : ITreePart<T>, IComparable
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

        /// <summary>
        /// just drop root tree
        /// </summary>
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

        public IEnumerator InOrderTraversal()
        {
            if (Root != null)
            {
                // Стек для сохранения пропущенных узлов.
                Stack stack = new Stack();

                T current = Root;

                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.LChild != null)
                        {
                            stack.Push(current);
                            current = current.LChild;
                        }
                    }

                    yield return current;

                    if (current.RChild != null)
                    {
                        current = current.RChild;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = (T)stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }


        public IEnumerator GetEnumerator()
        {
            return InOrderTraversal();
        }

    }
}
