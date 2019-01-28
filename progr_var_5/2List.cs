using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progr_var_5
{
    class _2List
    {
        Element head;
        int count;

        public int Count
        {
            get { return count; }
        }

        public Element Head
        {
            get { return head; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public _2List(double val)
        {
            count = 1;
            head = new Element(val);            
        }

        public void Add(double val)
        {
            Element New = new Element(val);
            Element tmpFind = FindLast();
            tmpFind.Next = New;
            New.Prev = tmpFind;
            count++;
        }

        private Element FindLast()
        {
            Element tmp = head;
            while (tmp.Next != null)
                tmp = tmp.Next;
            return tmp;
        }

        /// <summary>
        /// Поиск элемента по номеру [0..n]
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public Element GetElement(int val)
        {
            if (head != null)
            {
                Element tmp = head;
                for (int i = 0; i < val; i++)                
                    tmp = tmp.Next;                
                return tmp;
            }
            else return null;
                    
        }

        /// <summary>
        /// поиск элемента по значению
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public Element Find(double val)
        {
            if (head != null)
            {
                Element tmp = head;
                while (tmp != null && tmp.Value != val)
                    tmp = tmp.Next;
                return tmp;
            }
            else return null;
        }

        /// <summary>
        /// Возврощает новый список, в котором с указанной позиции были удалены элементы.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public _2List Remove(int index)
        {
            if (index > 0 && index < Count)
            {
                _2List New = new _2List(head.Value);
                Element tmp = new Element();
                tmp = head.Next;
                while (index > 1)
                {
                    New.Add(tmp.Value);
                    tmp = tmp.Next;
                    index--;
                }
                return New;
            }
            else return null;
        }

        /// <summary>
        /// возвращает новый список, в котором с указанной позиции index было удалено указанное кол-во елементов val.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public _2List Remove(int index, int val)
        {
            _2List tmpLeft = this.Remove(index);
            Element tmpRight = this.GetElement(index + val);
            while (tmpRight !=null)
            {
                if (tmpLeft == null)
                    tmpLeft = new _2List(tmpRight.Value);
                else
                    tmpLeft.Add(tmpRight.Value);
                tmpRight = tmpRight.Next;
            }
            return tmpLeft;
        }

        public static string PrintConsole(_2List list)
        {
            string s="";
            Element tmp = list.head;
            while (tmp != null)
            {
                s += tmp.Value + " ";
                tmp = tmp.Next;
            }
            return s;
        }
        

        public static _2List operator +(_2List l1, Element e2)
        {
            if (l1 == null && e2 == null)
                return null;
            else
            {
                if (l1 == null || e2 == null)
                    if (l1 == null) return new _2List(e2.Value);
                    else
                    {
                        _2List tmp = new _2List(l1.head.Value);
                        Element tmpE = l1.head.Next;
                        while (tmpE != null)
                        {
                            tmp.Add(tmpE.Value);
                            tmpE = tmpE.Next;
                        }
                        return tmp;
                    }
                else
                {
                    _2List tmp = new _2List(l1.head.Value);
                    Element tmpE = l1.head.Next;
                    while (tmpE != null)
                    {
                        tmp.Add(tmpE.Value);
                        tmpE = tmpE.Next;
                    }
                    tmp.Add(e2.Value);
                    return tmp;
                }
            }
        }

        public static _2List operator +(Element e1, _2List l2)
        {
            if (e1 == null && l2 == null)
                return null;
            else
            {
                if (e1 == null || l2 == null)
                    if (e1 == null) return l2;
                    else return new _2List(e1.Value);
                else
                {
                    _2List tmp = new _2List(e1.Value);
                    Element tmpE = l2.head;
                    while (tmpE != null)
                    {
                        tmp.Add(tmpE.Value);
                        tmpE = tmpE.Next;
                    }
                    return tmp;
                }
            }
        }

        public static _2List operator +(_2List l1, _2List l2)
        {
            if (l1 == null && l2 == null)
                return null;
            else
            {
                if (l1 == null || l2 == null)
                    if (l1 == null) return l2;
                    else return l1;
                else
                {
                    _2List tmp = l1;
                    Element tmpE = l2.head;
                    while (tmpE != null)
                    {
                        tmp.Add(tmpE.Value);
                        tmpE = tmpE.Next;
                    }
                    return tmp;
                }
            }
        }

    }
}
