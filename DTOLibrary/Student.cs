using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLibrary
{
    public sealed class Student
    { 
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Univercity { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public string Department { get; set; }
        public int Group { get; }
        public string City { get; set; }
        public int Age { get; set; }

        public Student() { }
         
        public Student(string firstName, string lastName, string univercity, string faculty, string department, int age, int course, int group, string city)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Univercity = univercity;
            this.Faculty = faculty;
            this.Department = department;
            this.Course = course;
            this.Age = age;
            this.Group = group;
            this.City = city;
        }

        public override string ToString()
        {
            return String.Format("{0,15} {1,15} {2,15} {3,15} {4,15} {5,15} {6,15} {7,5} {8,10}", FirstName, LastName, Univercity, Faculty, Department, Age, Course, Group, City);
        }

        public string GetRow()
        {
            return String.Format("{0,15};{1,15};{2,15};{3,15};{4,15};{5,15};{6,15};{7,5};{8,10}", FirstName, LastName, Univercity, Faculty, Department, Age, Course, Group, City);
        }
    }
}
