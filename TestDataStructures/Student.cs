using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDataStructures
{
    public class Student : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            var student2 = obj as Student;
            if (student2 == null)
                return 1;
            else
                return this.Id.CompareTo(student2.Id);             
        }

        public override string ToString()
        {
            return string.Format("{{{0}, {1}}}", this.Id, this.Name);
        }
    }
}
