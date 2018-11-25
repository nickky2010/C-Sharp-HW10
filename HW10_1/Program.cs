//                                                      Задание 1.
//  int[] values1 = new int[5] { 1, 10, 5, 13, 4 };
//  int[] values2 = new int[5] { 19, 1, 4, 9, 8 };
//  1) Посчитать среднее значение четных элементов, которые больше 10. 
//  2) Выбрать только уникальные элементы из массивов values1 и values2.
//  3) Найти максимальный элемент массива values2, который есть в массиве values1.
//  4) Посчитать сумму элементов массивов values1 и values2, которые попадают в диапазон от 5 до 15.
//  5) Отсортировать элементы массивов values1 и values2 по убыванию.

using System;
using System.Collections.Generic;
using System.Linq;

namespace HW10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] values1 = new int[5] { 1, 10, 5, 13, 4 };
                int[] values2 = new int[5] { 19, 1, 4, 9, 8 };
                List<int> array1 = values1.ToList();
                List<int> array2 = values2.ToList();
                List<int> arrayUnion = values1.Concat(values2).ToList();
                Console.WriteLine("Исходные массивы:");
                Console.Write("Array1 = ");
                array1.ForEach(a => Console.Write(a + " "));
                Console.Write("\nArray2 = ");
                array2.ForEach(a => Console.Write(a + " "));

                //  1) Посчитать среднее значение четных элементов, которые больше 10.
                Console.WriteLine("\n\n1) Посчитать среднее значение четных элементов, которые больше 10.");
                try
                {
                    double averPosMoreTen = arrayUnion.Where(a => a % 2 == 0 && a > 10).Average(); 
                    Console.WriteLine("Среднее значение четных элементов, которые больше 10 = " + averPosMoreTen);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Четные элементы больше 10 отсутствуют в массивах");
                }

                //  2) Выбрать только уникальные элементы из массивов values1 и values2.
                Console.WriteLine("\n2) Выбрать только уникальные элементы из массивов values1 и values2.");
                arrayUnion.Distinct().ToList().ForEach(e => Console.Write(e + " "));

                //  3) Найти максимальный элемент массива values2, который есть в массиве values1.
                Console.WriteLine("\n\n3) Найти максимальный элемент массива values2, который есть в массиве values1.");
                try
                {
                    int maxElArr2InArr1 = array2.Intersect(array1).Max();
                    Console.WriteLine("Максимальный элемент массива values2, который есть в массиве values1 = " + maxElArr2InArr1);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Одинаковые элементы отсутвуют в массивах");
                }

                //  4) Посчитать сумму элементов массивов values1 и values2, которые попадают в диапазон от 5 до 15.
                Console.WriteLine("\n\n4) Посчитать сумму элементов массивов values1 и values2, которые попадают в диапазон от 5 до 15.");
                Console.WriteLine("Cумма элементов массивов values1 и values2, которые попадают в диапазон от 5 до 15 = " + 
                        array1.Where(a=>a>=5&&a<=15).Concat(array2.Where(a => a >= 5 && a <= 15)).Sum());

                //  5) Отсортировать элементы массивов values1 и values2 по убыванию.
                Console.WriteLine("\n5) Отсортировать элементы массивов values1 и values2 по убыванию.");
                Console.Write("Array1 = ");
                array1.Sort(new CompareDesc());
                array1.ForEach(a => Console.Write(a + " "));
                Console.Write("\nArray2 = ");
                array2.Sort(delegate (int x, int y) { return -(x.CompareTo(y)); });
                array2.ForEach(a => Console.Write(a + " "));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!! " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
