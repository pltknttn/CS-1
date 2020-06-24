using CS.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Homework6
{
    class Program
    {
        static void Task1()
        {
            ConsoleUtils.HomeworkTask(1, @"
Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
");

            double koeff = ConsoleUtils.ReadDouble("koeff =");
            double start = ConsoleUtils.ReadDouble("start =");
            double finish = ConsoleUtils.ReadDouble("finish =");
            double step = ConsoleUtils.ReadDouble("step =");

            ConsoleUtils.Print("a*x^2 =>");
            Functions.Table(Functions.MyFunc3, koeff, start, finish, step);

            ConsoleUtils.Print("a* Math.Tan(x) =>");
            Functions.Table(delegate (double a, double x) { return a * Math.Tan(x); }, koeff, start, finish, step);

            ConsoleUtils.Print("a*sin(x) =>");
            Functions.Table(Functions.MyFunc4, koeff, start, finish, step);

            ConsoleUtils.Print("a*Math.Cos(x) =>");
            Functions.Table((a, x) => a * Math.Cos(x), koeff, start, finish, step);

            ConsoleUtils.Print("a*Math.Log10(x) =>");
            Functions.Table((a, x) => a * Math.Log10(x), koeff, start, finish, step);

            ConsoleUtils.WaitNextPress();
        }

        static void Task2()
        {
            ConsoleUtils.HomeworkTask(2, @"
2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
б) Используйте массив (или список) делегатов, в котором хранятся различные функции.
в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она
возвращает минимум через параметр.
");

            ConsoleUtils.Print("Укажите отрезок для нахождения минимума:");

            double a = ConsoleUtils.ReadDouble("a =");
            double b = ConsoleUtils.ReadDouble("b =");
            double h = ConsoleUtils.ReadDouble("h =");

            string fileName = "data.bin";
            MyFun[] functions = Functions.MyFunctions;
            List<double> results;
            double min;
            MyFun fun;
            ConsoleKey key;
            do
            {
                fun = null;
                key = Menu(functions);
                if (key != ConsoleKey.Escape)
                {
                    foreach (MyFun myFun in functions)
                    {
                        if (myFun.ConsoleKeys.Contains(key))
                        {
                            fun = myFun;
                            break;
                        }
                    }

                    if (fun == null)
                        ConsoleUtils.Print("Такой функции нет!");
                    else
                    {                       
                        Functions.SaveFunc(fun.Function, fileName, a, b, h);

                        results = Functions.Load(fileName, out min);

                        ConsoleUtils.Print("Результат:");
                        foreach (double val in results)
                        {
                            ConsoleUtils.Print(val);
                        }

                        ConsoleUtils.WaitNextPress();
                    }
                }
            }
            while (key != ConsoleKey.Escape);
        }

        static void WriteStudent(string fileName, List<Student> students)
        {
            Console.WriteLine("Запись результата в файл {0}", fileName);
            StreamWriter sr = new StreamWriter(fileName);
            foreach (Student student in students)
            {
                sr.WriteLine(student.GetRow());
            }
            sr.Close();
        }
        static void Task3()
        {
            ConsoleUtils.HomeworkTask(3, @"
3. Переделать программу «Пример использования коллекций» для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;
д) разработать единый метод подсчета количества студентов по различным параметрам
выбора с помощью делегата и методов предикатов.
");

            List<Student> list = new List<Student>();
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students_4.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    Student t = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), Convert.ToInt32(s[6]), int.Parse(s[7]), s[8]);
                    list.Add(t);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            sr.Close();

            Dictionary<CourseEnum, int> countStudents = new Dictionary<CourseEnum, int>()
            {
                { CourseEnum.First, Student.CountStudents(list, 18, 20, (int)CourseEnum.First, Student.IsAge)},
                { CourseEnum.Two, Student.CountStudents(list, 18, 20, (int)CourseEnum.Two, Student.IsAge)},
                { CourseEnum.Three, Student.CountStudents(list, 18, 20, (int)CourseEnum.Three, Student.IsAge)},
                { CourseEnum.Four, Student.CountStudents(list, 18, 20, (int)CourseEnum.Four, Student.IsAge)},
                { CourseEnum.Five, Student.CountStudents(list, 18, 20, (int)CourseEnum.Five, Student.IsAge)},
                { CourseEnum.Six, Student.CountStudents(list, 18, 20, (int)CourseEnum.Six, Student.IsAge)},
            };

            Console.WriteLine("Всего студентов: " + list.Count);
            Console.WriteLine("Кол-во студентов, студентов учащихся на 5 и 6 курсах: {0}", Student.CountStudents(list, 5, 6, Student.IsCourse));
            Console.WriteLine("Кол-во студентов, студентов в возрасте от 18 до 20 лет: {0}", Student.CountStudents(list, 18, 20, Student.IsAge));

            foreach (KeyValuePair<CourseEnum, int> keyValuePair in countStudents)
            {
                Console.WriteLine("На курсе {0} учится {1} студентов в возрасте от 18 до 20 лет", (int)keyValuePair.Key, keyValuePair.Value);
            }

            Console.WriteLine(DateTime.Now - dt);

            Console.WriteLine("Сортировка по возрасту");
            dt = DateTime.Now;
            list.Sort(new Comparison<Student>(Student.CompareAge));
            Console.WriteLine(DateTime.Now - dt);
            WriteStudent("SortData1.csv", list);

            Console.WriteLine("Сортировка по курсу");
            dt = DateTime.Now;
            list.Sort(new Comparison<Student>(Student.CompareCourse));
            Console.WriteLine(DateTime.Now - dt);
            WriteStudent("SortData2.csv", list);

            Console.WriteLine("Сортировка по курсу и возрасту");
            dt = DateTime.Now;
            list.Sort(new Comparison<Student>(Student.CompareCourseAndAge));
            Console.WriteLine(DateTime.Now - dt);
            WriteStudent("SortData3.csv", list);
           
            ConsoleUtils.WaitNextPress();
        }

        static ConsoleKey Menu(Task[] tasks)
        {
            ConsoleUtils.Clear();
            ConsoleUtils.Print("", ConsoleColor.White);
            ConsoleUtils.HomeworkTitle(6);
            ConsoleUtils.Print("Выберите задачу (для выхода нажмите Esc):", ConsoleColor.DarkGreen);
            foreach (Task task in tasks)
            {
                ConsoleUtils.Print(task.Text);
            }
            ConsoleUtils.Print("", ConsoleColor.White);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
            return keyInfo.Key;
        }

        static ConsoleKey Menu(MyFun[] functions)
        {
            ConsoleUtils.Print("", ConsoleColor.White);
            ConsoleUtils.Print("Выберите функцию (для завершения нажмите Esc):", ConsoleColor.DarkGreen);
            for (int i = 0; i < functions.Length; i++)
            {
                MyFun fun = functions[i];
                ConsoleUtils.Print($"{i + 1} - функция {fun.FunctionText}");
            }
            ConsoleUtils.Print("", ConsoleColor.White);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
            return keyInfo.Key;
        }

        static void Main()
        {
            Task[] tasks = new Task[]
            {
                new Task(Task1, "1 - Задача №1", new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.NumPad1 }),
                new Task(Task2, "2 - Задача №2", new ConsoleKey[] { ConsoleKey.D2, ConsoleKey.NumPad2 }),
                new Task(Task3, "3 - Задача №3", new ConsoleKey[] { ConsoleKey.D3, ConsoleKey.NumPad3 }),
            };

            ConsoleKey key;
            bool errorKey;
            do
            {
                errorKey = false;
                key = Menu(tasks);
                if (key != ConsoleKey.Escape)
                {
                    errorKey = true;
                    foreach (Task task in tasks)
                    {
                        if (task.CanExecution(key))
                        {
                            task.Execution();
                            errorKey = false;
                            break;
                        }
                    }
                }

                if (errorKey) ConsoleUtils.Print("Такой задачи нет!");
            }
            while (key != ConsoleKey.Escape);
        }
    }
}
