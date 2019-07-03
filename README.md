# C# - Home work 10
***
#### Task 1. 

```C#
  int[] values1 = new int[5] { 1, 10, 5, 13, 4 }; 
  int[] values2 = new int[5] { 19, 1, 4, 9, 8 };
```

1) Посчитать среднее значение четных элементов, которые больше 10.
 
2) Выбрать только уникальные элементы из массивов `values1` и `values2`.
 
3) Найти максимальный элемент массива `values2`, который есть в массиве `values1`.
 
4) Посчитать сумму элементов массивов `values1` и `values2`, которые попадают в диапазон от 5 до 15.

5) Отсортировать элементы массивов `values1` и `values2` по убыванию.


***
#### Task 2. 
```C#
class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DepId { get; set; }
}
class Department
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}

List<Department> departments = new List<Department>()
{
    new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
    new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
    new Department(){ Id = 3, Country = "France", City = "Paris" },
    new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
};
List<Employee> employees = new List<Employee>()
{
    new Employee(){Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2},
    new Employee(){Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1},
    new Employee(){Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3},
    new Employee(){Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2},
    new Employee(){Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4},
    new Employee(){Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2},
    new Employee(){Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4}
};
```
1) Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине. Выполнить запрос немедленно.
 
2) Отсортировать сотрудников по возрастам, по убыванию. Вывести `Id`, `FirstName`, `LastName`, `Age`. Выполнить запрос немедленно. 

3) Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.


***
#### Task 3.


Написать программу, выполняющую следующие функции:
* Считывание из текстового файла информации о сотрудниках фирмы, записанных в формате `csv` (Фамилия, должность, отдел, возраст)
* Формирование коллекции объектов класса Сотрудник
* Считывание из текстового файла информации о зарплатах, записанных в формате `csv` (должность, размер зарплаты)
* Формирование коллекции объектов класса Зарплата
* Вывод списка сотрудников моложе 30 лет в алфавитном порядке с указанием возраста
* Вывод списка отделов (без повторений) 
* Определение среднего возраста сотрудников для каждого отдела. Выводить название отдела и средний возраст в порядке убывания возраста.
* Вывод списка сотрудников заданного отдела с указанием зарплаты и должности
* Определение отдела с максимальной средней зарплатой
* Определение количества сотрудников в каждом отделе
* Определение минимального возраста для каждой должности
