using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progr_var_5
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 10.123;
            _2List list = new _2List(x);
            list.Add(13.123);
            list.Add(100.222);
            list.Add(3.34);
            list.Add(4.453);
            list.Add(18.5);
            list.Add(6.456);
            list.Add(9.547);
            list.Add(18.78);
            list.Add(9.456);
            list.Add(100.8);
            list.Add(14.67);
            list.Add(0.223);
            
            string s = "0123456789012";
            Console.WriteLine(s);
            Console.WriteLine(_2List.PrintConsole(list));

            _2List listS = MergeSort(list);
            Console.WriteLine(_2List.PrintConsole(listS));
            Console.ReadKey();
        }

        static _2List MergeSort(_2List list)
        {
            if (list.Count == 1)
            {
                return list;
            }

            int middle = list.Count / 2;
            int[] x = new int[1];
            return Merge(MergeSort(list.Remove(middle)), MergeSort(list.Remove(0,middle)));
        }

        static _2List Merge(_2List arr1, _2List arr2)
        {
            int ptr1 = 0, ptr2 = 0;
            _2List tmp=null;

            for (int i = 0; i < arr1.Count + arr2.Count; ++i) 
            {
                if (ptr1 < arr1.Count && ptr2 < arr2.Count)
                {
                    if (arr1.GetElement(ptr1) > arr2.GetElement(ptr2))
                        tmp += arr2.GetElement(ptr2++);
                    else
                        tmp += arr1.GetElement(ptr1++);
                }
                else
                {
                    if (ptr2 < arr2.Count)
                        tmp += arr2.GetElement(ptr2++);
                    else
                        tmp += arr1.GetElement(ptr1++);
                }
            }

            return tmp;
        }



    }
}
