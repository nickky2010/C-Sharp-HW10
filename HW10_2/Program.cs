//                                                      Задание 2.
//1)  Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине. Выполнить запрос немедленно. 
//2)  Отсортировать сотрудников по возрастам, по убыванию. Вывести Id, FirstName, LastName, Age. Выполнить запрос немедленно.
//3)  Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>() {
                new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
            };
            List<Employee> employees = new List<Employee>() {
                new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee() { Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 }
            };
            // 1) Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине. Выполнить запрос немедленно.
            Console.WriteLine("1) Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине.");
            employees.Join(departments, e => e.DepId, d=>d.Id, (e, d) => new {e.Id, e.FirstName, e.LastName, e.Age, d.Country, d.City}).
                OrderByDescending(c => c.Country == "Ukraine").ThenBy(n => n.FirstName).ThenBy(n => n.LastName).
                ToList().ForEach(e => Console.WriteLine(e.Id+" "+e.FirstName+" "+e.LastName+" "+e.Age+" "+e.Country+" "+e.City));

            // 2) Отсортировать сотрудников по возрастам, по убыванию. Вывести Id, FirstName, LastName, Age. Выполнить запрос немедленно.
            Console.WriteLine("\n2) Отсортировать сотрудников по возрастам, по убыванию. Вывести Id, FirstName, LastName, Age.");
            employees.OrderByDescending(a => a.Age).ToList().ForEach(s=>Console.WriteLine(s.Id+" "+s.FirstName+" "+s.LastName+" "+s.Age));

            //3)  Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.
            Console.WriteLine("\n3) Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.");
            employees.GroupBy(a => a.Age).Select(ag => new { ag.Key, Count = ag.Count() }).ToList().
                ForEach(a => Console.WriteLine("возраст: "+a.Key+" - встречается раз: "+a.Count));

            Console.ReadKey();

        }
    }
}
