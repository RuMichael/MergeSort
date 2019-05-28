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
            _2List list = null;

            string s;                                               // строка для сбора информации из консоли
            Console.WriteLine("Напиши stop, чтобы закончить заполнение списка");
            do
            {
                Console.Write("Введи число: ");
                s = Console.ReadLine();                             // запоминаем то что ввели в консоли
                double value;
                if (double.TryParse(s, out value))                  // проверяем что мы ввели в консоли, если соответствует типа double то передаем значение в переменную value и добавляем в наш список
                    list = (list == null) ? new _2List(value) : list + new Element(value);
            }
            while (s.IndexOf("stop") < 0 && s.IndexOf("test") < 0);
            if (s.IndexOf("test") >= 0)
                list = TestList();
            Console.WriteLine(_2List.PrintConsole(list));
            _2List listSort = MergeSort(list);
            Console.WriteLine(_2List.PrintConsole(listSort));
            Console.ReadKey();
        }

        static _2List MergeSort(_2List list)                        // сортировка слиянием
        {
            if (list.Count == 1)
            {
                return list;
            }

            int middle = list.Count / 2;            // находим середину списка
            return Merge(MergeSort(list.Remove(middle)), MergeSort(list.Remove(0,middle))); //возвращаем новый отсортированный список(сортируем через рекурсию)
        }






        static _2List Merge(_2List arr1, _2List arr2)               // слияние списков
        {
            int ptr1 = 0, ptr2 = 0;                            //индексы узлов в списке 1 и 2 соответствено
            _2List tmp = null;

            for (int i = 0; i < arr1.Count + arr2.Count; i++)   // цикл для перебора всех узлов списка 1 и 2
            {
                if (ptr1 < arr1.Count && ptr2 < arr2.Count)     // если еще не перебрали 1 и 2 списки полностью
                {
                    if (arr1.GetElement(ptr1) > arr2.GetElement(ptr2))
                        tmp += arr2.GetElement(ptr2++);
                    else
                        tmp += arr1.GetElement(ptr1++);
                }
                else                                            // если один из списков пуст
                {
                    if (ptr2 < arr2.Count)
                        tmp += arr2.GetElement(ptr2++);
                    else
                        tmp += arr1.GetElement(ptr1++);
                }
            }

            return tmp;                                         //возвращаем отсортированный, слитый список
        }

        static _2List TestList()
        {
            _2List list = new _2List(10.123);
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
            return list;
        }



    }
}
