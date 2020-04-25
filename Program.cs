using System;
using Laba10;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int choice = MainMenu();

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        FirstTask();
                        break;

                    case 2:
                        SecondTask();
                        break;

                    case 3:
                        ThirdTask();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }

            }
        }
        static int Input(string msg, int left, int right)
        {
            int x;
            Console.Write(msg);
            bool flag = int.TryParse(Console.ReadLine(), out x) && (x >= left) && (x <= right);

            if (flag) return x;
            else
            {
                Console.WriteLine($"Введите число из диапозона {left} - {right}");
                return Input(msg, left, right);
            }

        }
        
        public static void PrintList(List<Person> list)
        {
            Console.WriteLine(list.Count > 0 ? "Текущий список: " : "Список пуст");
            int i = 1;
            foreach (var obj in list)
            {
                Console.WriteLine($"{i}. {obj.ToString()}");
                i++;
            }
        }
        public static void PrintList(List<string> list)
        {
            Console.WriteLine(list.Count > 0 ? "Текущий список: " : "Список пуст");
            int i = 1;
            foreach (var obj in list)
            {
                Console.WriteLine($"{i}. {obj}");
                i++;
            }
        }
        static int MainMenu()
        {

            Console.WriteLine("1 - 1 задача \n" +
                "2 - 2 задача \n" +
                "3 - 3 задача \n" +
                "4 - Выход \n");

            int choice = Input("Выберите действие: ", 1, 3);
            return choice;
        }
        static int GetUserChoice(string msg, int left, int right)
        {
            Console.WriteLine(msg);
            int choice = Input("Выберите действие: ", left, right);
            return choice;
        }
        public static List<Person> AddObjToList(int objType, List<Person> list)
        {
            var newList = list;
            switch (objType)
            {
                case 1:
                    Person newPers = AddPerson();
                    newList.Add(newPers);
                    break;
                case 2:
                    Employee newEmp = AddEmployee();
                    newList.Add(newEmp);
                    break;
                case 3:
                    Employee newEng = AddEngineer();
                    newList.Add(newEng);
                    break;
                case 4:
                    Employee newAdmin = AddAdmin();
                    newList.Add(newAdmin);
                    break;
                case 5:
                    break;
            }

            return newList;
        }
        public static Person AddPerson()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            return new Person(name);
        }
        public static Employee AddEmployee()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            int salary = Input("Введите зарплату: ", 0, int.MaxValue);

            return new Employee(name, salary);
        }
        public static Engineer AddEngineer()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            int salary = Input("Введите зарплату: ", 0, int.MaxValue);
            int qual = Input("Введите уровень квалификации (от 0 до 10): ", 0, 10);
            return new Engineer(name, salary, qual);
        }
        public static Administrator AddAdmin()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            int salary = Input("Введите зарплату: ", 0, int.MaxValue);
            int level = Input("Введите уровень администратора (от 0 до 20): ", 0, 20);
            return new Administrator(name, salary, level);
        }
        static public void listRequests(List<Person> list)
        {
            int kEng = 0;

            foreach (var item in list)
            {
                if (item.GetType() == typeof(Employee))
                {
                    Employee mEmployee = (Employee)item;
                    // Запрос 1 - рабочий, зарплата больше 15000
                    Console.WriteLine("Запрос 1. Рабочие, З/П больше 15000");
                    if (mEmployee.Salary > 15000)
                    {
                        Console.WriteLine($"{mEmployee.GetInformation()} \n");
                    }
                }
                if (item is Administrator)
                {
                    Administrator mAdmin = (Administrator)item;
                    // Запрос 2 - администратор, зарплата больше 100 и квал. > 1
                    Console.WriteLine("Запрос 2. Администраторы, З/П больше 100 и квалификация больше 1");
                    if (mAdmin.Salary > 100 && mAdmin.Level > 1)
                    {
                        Console.WriteLine($"{mAdmin.GetInformation()} \n");
                    }
                }
                if (item is Engineer)
                {
                    Engineer mEngineer = (Engineer)item;
                    // Запрос 3 - инженер, зарплата больше 50000 и квал. > 1
                    if (mEngineer.Salary > 10000 && mEngineer.Qualification > 1)
                    {
                        kEng++;
                    }

                }
                
            }
            Console.WriteLine("Запрос 3. Количество инженеров, З/П больше 50000 и квалификация больше 1");
            Console.WriteLine($"{kEng} инженер \n");
        }
        static public void dictRequests(Dictionary<int, Person> dict)
        {
            int kEng = 0;

            foreach (var keyVal in dict)
            {
                if (keyVal.Value.GetType() == typeof(Employee))
                {
                    Employee mEmployee = (Employee)keyVal.Value;
                    // Запрос 1 - рабочий, зарплата больше 15000
                    Console.WriteLine("Запрос 1. Рабочие, З/П больше 15000");
                    if (mEmployee.Salary > 15000)
                    {
                        Console.WriteLine($"{mEmployee.GetInformation()} \n");
                    }
                }
                if (keyVal.Value is Administrator)
                {
                    Administrator mAdmin = (Administrator)keyVal.Value;
                    // Запрос 2 - администратор, зарплата больше 100 и квал. > 1
                    Console.WriteLine("Запрос 2. Администраторы, З/П больше 100 и квалификация больше 1");
                    if (mAdmin.Salary > 100 && mAdmin.Level > 1)
                    {
                        Console.WriteLine($"{mAdmin.GetInformation()} \n");
                    }
                }
                if (keyVal.Value is Engineer)
                {
                    Engineer mEngineer = (Engineer)keyVal.Value;
                    // Запрос 3 - инженер, зарплата больше 50000 и квал. > 1
                    if (mEngineer.Salary > 10000 && mEngineer.Qualification > 1)
                    {
                        kEng++;
                    }

                }

            }
            Console.WriteLine("Запрос 3. Количество инженеров, З/П больше 50000 и квалификация больше 1");
            Console.WriteLine($"{kEng} инженер \n");
        }
        public static List<Person> ClonedList(List<Person> list)
        {
            List<Person> newList = new List<Person>();
            foreach (var x in list)
            {
                newList.Add(x);
            }
            return newList;
        }
        public static Dictionary<int, Person> ClonedDict(Dictionary<int, Person> dict)
        {
            Dictionary<int, Person> newDict = new Dictionary<int, Person>();
            foreach (var keyVal in dict)
            {
                newDict.Add(keyVal.Key, keyVal.Value);
            }
            return newDict;
        }
        static void FirstTask()
        {
            List<Person> list = new List<Person> {  new Person("Sasha"), new Employee("Max", 16000), new Engineer("Oleg", 12000, 4),  new Administrator("Kirill", 7000, 2) };
            
            int key;
            do
            {
                PrintList(list);

                Console.WriteLine("");

                //получаем выбор пользователя 
                key = GetUserChoice("Выберите действие: \n" +
                "1 - Добавить объект в список \n" +
                "2 - Удалить объект из списка \n" +
                "3 - Демонстрация трех запросов \n"+
                "4 - Клонированная коллекция\n" +
                "5 - Сортировка списка и поиск элемента \n" +
                "6 - Назад \n", 1, 6);

                Console.Clear();
                switch (key)
                {
                    case 1:
                        int objType;
                        do
                        {
                            Console.WriteLine("Добавление объекта в список \n");
                            PrintList(list);
                            Console.WriteLine("");
                            objType = GetUserChoice("Выберите тип объекта: \n" +
                            "1 - Person \n" +
                            "2 - Employee \n" +
                            "3 - Engineer \n" +
                            "4 - Administrator \n" +
                            "5 - Назад \n", 1, 6);

                            Console.Clear();

                            list = AddObjToList(objType, list);

                            Console.Clear();

                        } while (objType != 5);
                        break;


                    case 2:
                        int choice;
                        do
                        {
                            Console.WriteLine("Удалить объект из списка \n");
                            PrintList(list);
                            Console.WriteLine("");

                            choice = GetUserChoice(
                            "1 - Удалить элемент \n" +
                            "2 - Назад \n", 1, 2);

                            if (choice != 2)
                            {
                                int index = Input("Введите номер элемента, который следует удалить: ", 1, list.Count);
                                list.RemoveAt(index - 1);
                            }
                            Console.Clear();
                        } while (choice != 2);
                        break;
                    case 3:
                        Console.Clear();
                        listRequests(list);

                        int uChoice = GetUserChoice("1 - Назад", 1, 1);
                        break;
                    case 4:
                        Console.Clear();
                        var newList = ClonedList(list);

                        Console.WriteLine("Клонированный список: ");
                        PrintList(newList);

                        int uc = GetUserChoice("1 - Назад", 1, 1);
                        break;
                    case 5:
                        int c;
                        Console.Clear();
                        do
                        {
                            Console.WriteLine("Отсортированный по имени список: ");
                            var nl = list.OrderBy(u => u.Name).ToList();
                            PrintList(nl);
                            Console.WriteLine("");

                            c = GetUserChoice(
                            "1 - Поиск элемента \n" +
                            "2 - Назад \n", 1, 2);

                            if (c != 2)
                            {
                                Console.Write("Введите имя для поиска: ");
                                string name = Console.ReadLine();
                                int index = list.BinarySearch(new Person(name), new NameComparer());

                                Console.WriteLine($"Найденный элемент: {list[index].ToString()} \n");
                            }
                        } while (c != 2);
                        break;
                       
                }

                Console.Clear();

            } while (key != 6);
        }
        public static void PrintDict(Dictionary<int, Person> dict)
        {
            Console.WriteLine(dict.Count > 0 ? "Текущий словарь: " : "Словарь пуст");
            foreach (var ketVal in dict)
            {
                Console.WriteLine($"{ketVal.Key} -- {ketVal.Value.ToString()}");
            }
        }
        public static void PrintDict(Dictionary<Person, Employee> dict)
        {
            Console.WriteLine(dict.Count > 0 ? "" : "Словарь пуст");
            foreach (var ketVal in dict)
            {
                Console.WriteLine($"{ketVal.Key} -- {ketVal.Value.ToString()}");
            }
        }
        public static void PrintDict(Dictionary<string, Employee> dict)
        {
            Console.WriteLine(dict.Count > 0 ? "" : "Словарь пуст");
            foreach (var ketVal in dict)
            {
                Console.WriteLine($"{ketVal.Key} -- {ketVal.Value.ToString()}");
            }
        }
        public static Dictionary<int, Person> AddObjToDict(int objType, Dictionary<int, Person> dict)
        {
            var newDict = dict;
            switch (objType)
            {
                case 1:
                    
                    Person newPers = AddPerson();
                    dict.Add(dict.Keys.Max() + 1, newPers);
                    break;
                case 2:
                    Employee newEmp = AddEmployee();
                    dict.Add(dict.Keys.Max() + 1, newEmp);
                    break;
                case 3:
                    Employee newEng = AddEngineer();
                    dict.Add(dict.Keys.Max() + 1, newEng);
                    break;
                case 4:
                    Employee newAdmin = AddAdmin();
                    dict.Add(dict.Keys.Max() + 1, newAdmin);
                    break;
                case 5:
                    break;
            }

            return newDict;
        }
        static void SecondTask()
        {
            Dictionary<int, Person> dict = new Dictionary<int, Person>();
            dict.Add(1, new Person("Sasha"));
            dict.Add(2, new Employee("Max", 16000));
            dict.Add(3, new Engineer("Oleg", 12000, 4));
            dict.Add(4, new Administrator("Kirill", 7000, 2));
            int key;
            do
            {
                PrintDict(dict);

                Console.WriteLine("");

                //получаем выбор пользователя 
                key = GetUserChoice("Выберите действие: \n" +
                "1 - Добавить объект в словарь \n" +
                "2 - Удалить объект из словаря \n" +
                "3 - Демонстрация трех запросов \n" +
                "4 - Клонированная коллекция\n" +
                "5 - Сортировка словаря и поиск элемента \n" +
                "6 - Назад \n", 1, 6);

                Console.Clear();
                switch (key)
                {
                    case 1:
                        int objType;
                        do
                        {
                            Console.WriteLine("Добавление объекта в словарь \n");
                            PrintDict(dict);
                            Console.WriteLine("");
                            objType = GetUserChoice("Выберите тип объекта: \n" +
                            "1 - Person \n" +
                            "2 - Employee \n" +
                            "3 - Engineer \n" +
                            "4 - Administrator \n" +
                            "5 - Назад \n", 1, 6);

                            Console.Clear();

                            dict = AddObjToDict(objType, dict);

                            Console.Clear();

                        } while (objType != 5);
                        break;


                    case 2:
                        int choice;
                        do
                        {
                            Console.WriteLine("Удалить объект из списка \n");
                            PrintDict(dict);
                            Console.WriteLine("");

                            choice = GetUserChoice(
                            "1 - Удалить элемент \n" +
                            "2 - Назад \n", 1, 2);

                            if (choice != 2)
                            {
                                int index = Input("Введите ключ элемента, который следует удалить: ", dict.Keys.Min(), dict.Keys.Max());
                                dict.Remove(index);
                            }
                            Console.Clear();
                        } while (choice != 2);
                        break;
                    case 3:
                        Console.Clear();
                        dictRequests(dict);

                        int uChoice = GetUserChoice("1 - Назад", 1, 1);
                        break;
                    case 4:
                        Console.Clear();
                        var newDict = ClonedDict(dict);

                        Console.WriteLine("Клонированный словарь: ");
                        PrintDict(newDict);

                        int uc = GetUserChoice("1 - Назад", 1, 1);
                        break;
                    case 5:
                        int c;
                        Console.Clear();
                        do
                        {
                            Console.WriteLine("Отсортированный по имени список: ");
                            var ndict = dict.OrderBy(u => u.Key).ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                            PrintDict(ndict);
                            Console.WriteLine("");

                            c = GetUserChoice(
                            "1 - Поиск элемента \n" +
                            "2 - Назад \n", 1, 2);

                            if (c != 2)
                            {
                                Console.Write("Поиск по ключу: ");
                                int k = Input("Введите ключ: ", dict.Keys.Min(), dict.Keys.Max());
                                Person p = dict[k];
                                Console.WriteLine($"Найденный элемент: {p.ToString()} \n");
                            }
                        } while (c != 2);
                        break;

                }

                Console.Clear();

            } while (key != 6);
        }
       
        public static void ThirdTask()
        {
            const int size = 10;
            TestCollections collections = new TestCollections(size);

            Console.WriteLine("listPeople: ");
            PrintList(collections.listPeople);
            Console.WriteLine("");
            Console.WriteLine("listString: ");
            PrintList(collections.listString);
            Console.WriteLine("");
            Console.WriteLine("dictPeople: ");
            PrintDict(collections.dictPeople);
            Console.WriteLine("");
            Console.WriteLine("dictString: ");
            PrintDict(collections.dictString);
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            // Добавление элемента
            Console.WriteLine("Добавление элемента");
            Console.WriteLine("");
            Employee Employee = new Employee(collections.GetRandomName());
            collections.Add(Employee);
            Console.WriteLine("--------------------------------");

            // Печать listPeople
            Console.WriteLine("listPeople:");
            PrintList(collections.listPeople);
            Console.WriteLine("");
            // Печать listString
            Console.WriteLine("listString:");
            PrintList(collections.listString);
            Console.WriteLine("");
            // Печать dictPeople
            Console.WriteLine("dictPeople:");
            PrintDict(collections.dictPeople);
            Console.WriteLine("");
            // Печать dictString
            Console.WriteLine("dictString:");
            PrintDict(collections.dictString);
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            // Удаление элемента
            Console.WriteLine("Удаление элемента");
            Console.WriteLine("");
            collections.Remove();
            Console.WriteLine("--------------------------------");

            // Печать listPeople
            Console.WriteLine("listPeople:");
            PrintList(collections.listPeople);
            Console.WriteLine("");
            // Печать listString
            Console.WriteLine("listString:");
            PrintList(collections.listString);
            Console.WriteLine("");
            // Печать dictPeople
            Console.WriteLine("dictPeople:");
            PrintDict(collections.dictPeople);
            Console.WriteLine("");
            // Печать dictString
            Console.WriteLine("dictString:");
            PrintDict(collections.dictString);
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine("Время поиска первого объекта в коллекции");
            bool yes = false;
            stopWatch.Start();
            foreach (var x in collections.listPeople)
            {
                if (x.Equals(collections.firstObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
            Console.WriteLine("Время поиска в listPeople = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");
            stopWatch.Start();
           
            Console.WriteLine(collections.listString.Contains(collections.firstObject.BasePerson.ToString()) ? "Объект найден" : "Объект не найден");
            stopWatch.Stop();
            Console.WriteLine("Время поиска в listString = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");
            yes = false;
            stopWatch.Start();
            foreach (var keyVal in collections.dictPeople)
            {
                if (keyVal.Value.Equals(collections.firstObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
            Console.WriteLine("Время поиска в dictPeople = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");
            stopWatch.Start();
            yes = false;
            foreach (var keyVal in collections.dictPeople)
            {
                if (keyVal.Value.Equals(collections.firstObject))
                {
                    yes = true;
                    break;
                }
            }
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
            stopWatch.Stop();
            Console.WriteLine("Время поиска в dictString = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");

            Console.WriteLine("-------------------------------");




            Console.WriteLine("Время поиска центрального объекта в коллекции");
            yes = false;
            stopWatch.Start();
            foreach (var x in collections.listPeople)
            {
                if (x.Equals(collections.middleObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
            Console.WriteLine("Время поиска в listPeople = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");
            stopWatch.Start();
            Console.WriteLine(collections.listString.Contains(collections.middleObject.BasePerson.ToString()) ? "Объект найден" : "Объект не найден");
            stopWatch.Stop();
            Console.WriteLine("Время поиска в listString = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");

            yes = false;
            stopWatch.Start();
            foreach (var keyVal in collections.dictPeople)
            {
                if (keyVal.Value.Equals(collections.middleObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
            Console.WriteLine("Время поиска в dictPeople = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");
            yes = false;
            stopWatch.Start();
            foreach (var keyVal in collections.dictPeople)
            {
                if (keyVal.Value.Equals(collections.middleObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
            Console.WriteLine("Время поиска в dictString = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");

            Console.WriteLine("-------------------------------");

            Console.WriteLine("Время поиска последнего объекта в коллекции");
            yes = false;
            stopWatch.Start();
            foreach (var x in collections.listPeople)
            {
                if (x.Equals(collections.lastObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
           
            Console.WriteLine("Время поиска в listPeople = " + stopWatch.ElapsedTicks);
            Console.WriteLine("");
            stopWatch.Start();
            Console.WriteLine(collections.listString.Contains(collections.lastObject.BasePerson.ToString()) ? "Объект найден" : "Объект не найден");
            stopWatch.Stop();
            Console.WriteLine("Время поиска в listString = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");
            yes = false;
            stopWatch.Start();
            foreach (var keyVal in collections.dictPeople)
            {
                if (keyVal.Value.Equals(collections.lastObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");

            Console.WriteLine("Время поиска в dictPeople = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");
            yes = false;
            stopWatch.Start();
            foreach (var keyVal in collections.dictPeople)
            {
                if (keyVal.Value.Equals(collections.lastObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
            Console.WriteLine("Время поиска в dictString = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");

            Console.WriteLine("-------------------------------");

            Console.WriteLine("Время поиска объекта, не входящего в коллекцию");
            Employee unknownObject = new Employee("adsasd", 1);
            yes = false;

            stopWatch.Start();
            foreach (var x in collections.listPeople)
            {
                if (x.Equals(unknownObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
            Console.WriteLine("Время поиска в listPeople = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");
            stopWatch.Start();

            Console.WriteLine(collections.listString.Contains(unknownObject.BasePerson.ToString()) ? "Объект найден" : "Объект не найден");
            stopWatch.Stop();
            Console.WriteLine("Время поиска в listString = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");
            yes = false;
            stopWatch.Start();
            foreach (var keyVal in collections.dictPeople)
            {
                if (keyVal.Value.Equals(unknownObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
            Console.WriteLine("Время поиска в dictPeople = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");
            yes = false;
            stopWatch.Start();
            foreach (var keyVal in collections.dictPeople)
            {
                if (keyVal.Value.Equals(unknownObject))
                {
                    yes = true;
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine(yes ? "Объект найден" : "Объект не найден");
            Console.WriteLine("Время поиска в dictString = " + stopWatch.ElapsedTicks);
            stopWatch.Reset();
            Console.WriteLine("");

            Console.WriteLine("-------------------------------");
        }
    }
}
