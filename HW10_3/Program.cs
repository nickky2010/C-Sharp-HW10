//Написать программу, выполняющую следующие функции:
//- Считывание из текстового файла информации о сотрудниках фирмы, записанных в формате csv(Фамилия, должность, отдел, возраст)
//- Формирование коллекции объектов класса Сотрудник
//- Считывание из текстового файла информации о зарплатах, записанных в формате csv(должность, размер зарплаты)
//- Формирование коллекции объектов класса Зарплата
//- Вывод списка сотрудников моложе 30 лет в алфавитном порядке с указанием возраста
//- Вывод списка отделов(без повторений)
//- Определение среднего возраста сотрудников для каждого отдела.Выводить название отдела и средний возраст в порядке убывания возраста.
//- Вывод списка сотрудников заданного отдела с указанием зарплаты и должности
//- Определение отдела с максимальной средней зарплатой
//- Определение количества сотрудников в каждом отделе
//- Определение минимального возраста для каждой должности
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HW10_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Salary> salaries = new List<Salary>();
                List<Employers> employers = new List<Employers>();
                string[] temp;
                using (StreamReader reader = new StreamReader(@"Salaries.dat", Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        temp = reader.ReadLine().Split(';'); //считывание из файла 
                        salaries.Add(new Salary { Position = temp[0], Zarpl = Convert.ToDecimal(temp[1]) });
                    }
                }
                using (StreamReader reader1 = new StreamReader(@"employees.dat", Encoding.Default))
                {
                    while (!reader1.EndOfStream)
                    {
                        temp = reader1.ReadLine().Split(';'); //считывание из файла 
                        employers.Add(new Employers { Surname = temp[0], Position = temp[1], Department = temp[2], Age = Convert.ToInt32(temp[3]) });
                    }
                }
                Console.WriteLine("Данные считанные по зарплатам сотрудников:");
                salaries.ForEach(s => Console.WriteLine(s.Position + " " + s.Zarpl));
                Console.WriteLine("\nДанные считанные по сотрудникам:");
                employers.ForEach(e => Console.WriteLine(e.Surname + " " + e.Position + " " + e.Department + " " + e.Age));

                //- Вывод списка сотрудников моложе 30 лет в алфавитном порядке с указанием возраста
                Console.WriteLine("\nСписок сотрудников моложе 30 лет в алфавитном порядке с указанием возраста:");
                employers.Where(e => e.Age < 30).OrderBy(e => e.Surname).ToList().ForEach(e => Console.WriteLine(e.Surname+" " +e.Age));

                //- Вывод списка отделов(без повторений)
                Console.WriteLine("\nСписок отделов без повторений:");
                employers.Select(e => e.Department).Distinct().ToList().ForEach(e => Console.WriteLine(e));

                //- Определение среднего возраста сотрудников для каждого отдела.Выводить название отдела и средний возраст в порядке убывания возраста.
                Console.WriteLine("\nCредний возраст сотрудников для каждого отдела:");
                employers.GroupBy(e => e.Department).Select(gr =>new { gr.Key, Average = gr.Average(e => e.Age) }).
                    OrderByDescending(o => o.Average).ToList().ForEach(e => Console.WriteLine(e.Key+" = "+ Math.Round(e.Average,2)));

                //- Вывод списка сотрудников заданного отдела с указанием зарплаты и должности
                Console.WriteLine("\nCписок сотрудников заданного отдела с указанием зарплаты и должности");
                Console.Write("Введите название отдела: ");
                string depName = Console.ReadLine();
                employers.Join(salaries, e => e.Position, s => s.Position, (emp, sal) =>
                    new { emp.Surname, emp.Position, emp.Department, Salary = sal.Zarpl }).
                    Where(ed => ed.Department == depName).ToList().ForEach(e => Console.WriteLine(e.Surname+" "+ e.Position+" "+e.Salary));

                //- Определение отдела с максимальной средней зарплатой
                Console.WriteLine("\nОтдел с максимальной средней зарплатой:");
                var depAverageSalary = employers.GroupJoin(salaries, e => e.Position, s => s.Position, (emp, sal) =>
                     new { emp.Department, AverageSalary = sal.Average(sl => sl.Zarpl) }).GroupBy(d=>d.Department).Select(gr=>
                     new { gr.Key, Average = gr.Average(e=>e.AverageSalary)}).OrderByDescending(o=>o.Average).ToList();
                var depMaxAverageSalary = depAverageSalary.First(m => (m.Average == depAverageSalary.Max(mm => mm.Average)));
                Console.WriteLine(depMaxAverageSalary.Key + " " + Math.Round(depMaxAverageSalary.Average,2));

                //- Определение количества сотрудников в каждом отделе
                Console.WriteLine("\nКоличество сотрудников в каждом отделе:");
                employers.GroupBy(e => e.Department).Select(ee => new { ee.Key, CountEmployers = ee.Count() }).ToList().
                ForEach(e => Console.WriteLine(e.Key + " " + e.CountEmployers));

                //- Определение минимального возраста для каждой должности
                Console.WriteLine("\nМинимальный возраст для каждой должности:");
                employers.GroupBy(e => e.Position).Select(ee => new { ee.Key, MinAge = ee.Min(e=>e.Age) }).ToList().
                ForEach(e => Console.WriteLine(e.Key+" "+e.MinAge));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка!!! Файлы для считывания данных не найдены");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка преобразования данных в число!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка!!! "+ex.Message);
            }
            Console.ReadKey();
        }
    }
}
