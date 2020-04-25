using System;
using System.Collections.Generic;
using System.Text;
using Laba10;
namespace Lab11
{
    class NameComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            return string.CompareOrdinal(p1.Name, p2.Name);
        }
    }
}
