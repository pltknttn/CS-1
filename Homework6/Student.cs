using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public delegate bool IsStudent(Student s);
    public delegate bool IsStudent2(Student s, int a, int b);

    public enum CourseEnum
    {
        None = 0,
        First = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        All = -1
    }

    public sealed class Student
    {
        //автоматические свойства
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Univercity { get; private set; }
        public string Faculty { get; private set; }
        public int Course { get; private set; }
        public string Department { get; private set; }
        public int Group { get; }
        public string City { get; private set; }
        public int Age { get; private set; }

        //Создаем конструктор
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

        public static int CompareCourse(Student st1, Student st2) 
        {
            if (st1.Course > st2.Course) return 1;
            if (st1.Course < st2.Course) return -1;
            return 0; 
        }

        public static int CompareAge(Student st1, Student st2) 
        {
            if (st1.Age > st2.Age) return 1;
            if (st1.Age < st2.Age) return -1;
            return 0;
        }

        public static int CompareCourseAndAge(Student st1, Student st2)
        {
            int compareCourse = CompareCourse(st1, st2);
            if (compareCourse == 0)
               return CompareAge(st1, st2);

            return compareCourse;
        }

        public static bool IsAgeBigger18(Student student)
        {
            return student.Age > 18;
        }

        public static bool IsAge(Student student, int a, int b)
        {
            return student.Age >= a && student.Age <= b;
        }

        public static bool IsCourse(Student student, int a, int b)
        {
            return student.Course >= a && student.Course <= b;
        }

        public static bool IsMagistr(Student student)
        {
            return student.Course == (int)CourseEnum.Six;
        }

        public static int CountStudents(List<Student> students, IsStudent IS)
        {
            int count = 0;
            foreach (Student student in students)
            {
                if (IS(student)) count++;
            }
            return count;
        }

        public static int CountStudents(List<Student> students, int a, int b, IsStudent2 IS, CourseEnum course = CourseEnum.All)
        {
            int count = 0;
            foreach (Student student in students)
            {
                if ((course == CourseEnum.All || student.Course == (int)course) && IS(student, a, b)) count++;
            }
            return count;
        }
    }
}
