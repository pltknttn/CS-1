using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Program
    {
        static void SumAB()
        {
            double x;
            double y;
            
            Console.Write("Введите первое число: ");
            
            string str = Console.ReadLine();
            x = Convert.ToDouble(str);
            
            Console.Write("Введите второе число: ");
            
            y = Convert.ToDouble(Console.ReadLine());
            double z = x + y;
            
            Console.WriteLine(x + "+" + y + "=" + z); // Преобразование в строку
            Console.ReadLine();
        }

        static void Func()
        {
            double a = 1;
            double b = 1;
            double c = 1;
            double x;
            
            Console.Write("Введите значение x: ");
            
            string s = Console.ReadLine();
            x = Convert.ToDouble(s);
            double f = a * Math.Pow(x, 2) + b * x + c;

            Console.WriteLine("{0}*x^2+{1}*x+{2}, при x={3}, f={4}", a, b, c, x, f);
            Console.ReadLine();
        }

        static void AB()
        {
            int a = 10; // Присваиваем начальное значение
            Console.WriteLine($"a={a}");
            int b = 20; // Присваиваем начальное значение
            Console.WriteLine($"b={b}");
            int t = a; // В t запоминаем значение a
            Console.WriteLine($"t = a, t={t}");
            a = b; // В a записываем b
            Console.WriteLine($"a = b, a={a}");
            b = t; // В b записываем сохраненное a
            Console.WriteLine($"b = t, b={b}");
            Console.ReadLine();
        }

        static bool Odd(int n)
        {
            return n % 2 == 0;
        }

        static void Print(string msg, int x, int y)
        {
            // Установим позицию курсора на экране
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }

        static void Print(string msg, ConsoleColor foregroundcolor)
        {
            // Установим цвет символов
            Console.ForegroundColor = foregroundcolor;
            Console.WriteLine(msg);
        }

        static bool IsTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && c + b > a;
        }
        static double S(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static void Main()
        {
            SumAB();
            Func();
            AB();

            int value = 100500;
            Console.WriteLine(Odd(value));
            Console.ReadLine();

            Print("Привет!\n", 10, 10);
            Print("Привет еще раз!", ConsoleColor.Red);
            Console.ReadLine();

            Console.Write("Введите a:");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите b:");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите c:");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Может существовать треугольник с такими сторонами: " + IsTriangle (a, b, c));
            Console.WriteLine("Площадь треугольника:" + S(a, b, c));
            Console.ReadLine();


        }
    }
}
