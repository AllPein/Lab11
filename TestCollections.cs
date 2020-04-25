using System;
using System.Collections.Generic;
using System.Text;
using Laba10;
namespace Lab11
{
    class TestCollections
    {
        public string[] names = new string[] { "Максим", "Алексей", "Ольга", "Андрей", "Александр", "Артур", "Ирина", "Елена", "Олеся", "Богдан" };
        Random rand = new Random();

        public List<Person> listPeople;
        public List<string> listString;
        public Dictionary<Person, Employee> dictPeople;
        public Dictionary<string, Employee> dictString;

        public Employee firstObject;
        public Employee middleObject;
        public Employee lastObject;
        public TestCollections()
        {
            listPeople = new List<Person>();
            listString = new List<string>();
            dictPeople = new Dictionary<Person, Employee>();
            dictString = new Dictionary<string, Employee>();

        }
        public string GetRandomName()
        {
            return names[rand.Next(0, 10)];
        }
        public TestCollections(int count)
        {
            listPeople = new List<Person>();
            listString = new List<string>();
            dictPeople = new Dictionary<Person, Employee>();
            dictString = new Dictionary<string, Employee>();

            for (int i = 0; i < count; i++)
            {

                Employee employee = new Employee(GetRandomName());
                Person person = employee.BasePerson;
                
                listPeople.Add(person);
                listString.Add(person.ToString());
                dictPeople.Add(person, employee);
                dictString.Add(person.GetHashCode().ToString(), employee);

                if (i == 0) firstObject = employee;
                if (i == count / 2) middleObject = employee;
                if (i == count - 1) lastObject = employee;
            }
        }
        public void Add(Employee employee)
        {
            Person person = employee.BasePerson;

            listPeople.Add(person);
            listString.Add(person.ToString());
            dictPeople.Add(person, employee);
            dictString.Add(person.GetHashCode().ToString(), employee);

        }
        public void Remove()
        {
            Person deletedPerson = listPeople[listPeople.Count - 1];
            listPeople.RemoveAt(listPeople.Count - 1);
            listString.RemoveAt(listString.Count - 1);
            dictPeople.Remove(deletedPerson);
            dictString.Remove(deletedPerson.GetHashCode().ToString());
        }
        public void RefactorObjects()
        {
            int i = 0;
            foreach (Person person in listPeople)
            {
                Employee employee = dictPeople[person];

                if (i == 0) firstObject = employee;
                if (i == listPeople.Count / 2) middleObject = employee;
                if (i == listPeople.Count - 1) lastObject = employee;
                i++;
            }
        }
    }
}
