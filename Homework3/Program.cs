using Struct = Homework3.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Utils;

namespace Homework3
{
    class Program
    {
        /* Домашнее задание №3         
          Автор: Полятыкина Татьяна
         */

        static void SetComplex(ref Struct.Complex complex, int num)
        {
            ConsoleUtils.Print($"Задаем {num}-ое комплексное число", ConsoleColor.DarkYellow);  
            complex.re = ConsoleUtils.ReadInt($"Введите вещественную часть {num}-го числа:");
            complex.im = ConsoleUtils.ReadInt($"Введите мнимую часть {num}-го числа:");
            ConsoleUtils.Print($"Задано {num}-ое комплексное число: {complex.ToString()}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void SetComplex(Class.Complex complex, int num)
        {
            ConsoleUtils.Print($"Задаем {num}-ое комплексное число", ConsoleColor.DarkYellow);
            complex.Re = ConsoleUtils.ReadInt($"Введите вещественную часть {num}-го числа:");
            complex.Im = ConsoleUtils.ReadInt($"Введите мнимую часть {num}-го числа:");
            ConsoleUtils.Print($"Задано {num}-ое комплексное число: {complex.ToString()}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Task1()
        {
            ConsoleUtils.HomeworkTask(1, "Демонстрация стуктуры Complex, вычитание комплексных чисел");
                        
            Struct.Complex complex1 = new Struct.Complex();            
            SetComplex(ref complex1, 1);
             
            Struct.Complex complex2 = new Struct.Complex();
            SetComplex(ref complex2, 2); 

            Struct.Complex result = complex1.Plus(complex2);
            ConsoleUtils.Print($"{complex1.ToString()} + {complex2.ToString()} = " + result.ToString());

            result = complex1.Multi(complex2);
            ConsoleUtils.Print($"{complex1.ToString()} * {complex2.ToString()} = " + result.ToString());

            result = complex1.Minus(complex2);
            ConsoleUtils.Print($"{complex1.ToString()} - {complex2.ToString()} = " + result.ToString());

            ConsoleUtils.WaitNextPress();
        }

        static void Task2()
        {
            ConsoleUtils.HomeworkTask(2, "Демонстрация класса Complex, вычитание и произведение комплексных чисел");

            Class.Complex complex1 = new Class.Complex();
            SetComplex(complex1, 1);

            Class.Complex complex2 = new Class.Complex();
            SetComplex(complex2, 2);

            Class.Complex result = complex1.Plus(complex2);
            ConsoleUtils.Print($"{complex1.ToString()} + {complex2.ToString()} = " + result.ToString());

            result = complex1.Multi(complex2);
            ConsoleUtils.Print($"{complex1.ToString()} * {complex2.ToString()} = " + result.ToString());

            result = complex1.Minus(complex2);
            ConsoleUtils.Print($"{complex1.ToString()} - {complex2.ToString()} = " + result.ToString());

            ConsoleUtils.WaitNextPress();
        }

        static void Task3()
        {
            ConsoleUtils.HomeworkTask(3, "Добавить диалог с использованием switch демонстрирующий работу класса Complex");
            
            Class.Complex complex1 = new Class.Complex();
            SetComplex(complex1, 1);

            Class.Complex complex2 = new Class.Complex();
            SetComplex(complex2, 2);

            Class.Complex result;

            switch (ConsoleUtils.ReadInt("Выберите операцию: 1 - сложить, 2 - разница, 3 - умножение"))
            {
                case 1:
                    result = complex1.Plus(complex2);
                    ConsoleUtils.Print($"{complex1.ToString()} + {complex2.ToString()} = " + result.ToString());
                    break;
                case 2:
                    result = complex1.Minus(complex2);
                    ConsoleUtils.Print($"{complex1.ToString()} - {complex2.ToString()} = " + result.ToString());
                    break;
                case 3:
                    result = complex1.Multi(complex2);
                    ConsoleUtils.Print($"{complex1.ToString()} * {complex2.ToString()} = " + result.ToString());
                    break;
                default:
                    ConsoleUtils.Print("Такой операции нет");
                    break;
            }

            ConsoleUtils.WaitNextPress();
        }

        static void Task4()
        {
            ConsoleUtils.HomeworkTask(4, "Посчитать сумму всех нечетных положительных чисел");
            ConsoleUtils.Print("Введите целые числа (для остановки введите 0):");
            
            string oddNumbers = string.Empty;
            bool stop = false;
            long number = 0;
            long sum = 0;

            while(!stop)
            {
                if (!long.TryParse(Console.ReadLine(), out number) || number < 0) continue; 

                stop = number == 0;

                if (!MathUtils.IsOddNumber(number)) continue;

                sum += number;
                oddNumbers = $"{oddNumbers};{number}";
            }

            oddNumbers.TrimStart(';'); 

            ConsoleUtils.Print($"Сумма нечетных положительных чисел \"{oddNumbers}\" равна {sum}");
            ConsoleUtils.WaitNextPress();
        }

        static void SetFraction(Class.Fraction fraction, int num)
        {
            ConsoleUtils.Print($"Задаем {num}-ое дробное число число", ConsoleColor.DarkYellow);
            fraction.Numerator = ConsoleUtils.ReadInt($"Введите числитель {num}-го числа:");
            fraction.Denominator = ConsoleUtils.ReadInt($"Введите знаменатель {num}-го числа:");
            ConsoleUtils.Print($"Задано {num}-ое дробное число: {fraction.ToString()}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Task5()
        {
            /*
            Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
            Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать
            программу, демонстрирующую все разработанные элементы класса.
            - Добавить свойства типа int для доступа к числителю и знаменателю;
            - Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
            - Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
            - Добавить упрощение дробей*/


            ConsoleUtils.HomeworkTask(5, @"Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
            Предусмотреть методы сложения, вычитания, умножения и деления дробей.Написать
            программу, демонстрирующую все разработанные элементы класса.
            - Добавить свойства типа int для доступа к числителю и знаменателю;
            - Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
            - Добавить проверку, чтобы знаменатель не равнялся 0.Выбрасывать исключение ArgumentException(\""Знаменатель не может быть равен \"");
            - Добавить упрощение дробей");

            Class.Fraction fraction1 = new Class.Fraction();
            SetFraction(fraction1, 1);

            Class.Fraction fraction2 = new Class.Fraction();
            SetFraction(fraction2, 2);

            Class.Fraction result;

            int answer = 0;

            do
            {

                answer = ConsoleUtils.ReadInt("Выберите операцию: 1 - сложить, 2 - разница, 3 - умножение, 4 - деление, 5 - упрощение, 6 - десятичная дробь, 0 - завершить");

                switch (answer)
                {
                    case 0: break;
                    case 1:
                        result = fraction1.Plus(fraction2);
                        ConsoleUtils.Print($"{fraction1.ToString()} + {fraction2.ToString()} = " + result.ToString());
                        break;
                    case 2:
                        result = fraction1.Minus(fraction2);
                        ConsoleUtils.Print($"{fraction1.ToString()} - {fraction2.ToString()} = " + result.ToString());
                        break;
                    case 3:
                        result = fraction1.Multi(fraction2);
                        ConsoleUtils.Print($"{fraction1.ToString()} * {fraction2} = " + result.ToString());
                        break;
                    case 4:
                        result = fraction1.Divide(fraction2);
                        ConsoleUtils.Print($"{fraction1.ToString()} * {fraction2.ToString()} = " + result.ToString());
                        break;
                    case 5:
                        result = fraction1.Reduction();
                        ConsoleUtils.Print($"{fraction1.ToString()} = " + result.ToString());
                        result = fraction2.Reduction();
                        ConsoleUtils.Print($"{fraction2.ToString()} = " + result.ToString());
                        break;
                    case 6:
                        ConsoleUtils.Print($"{fraction1.ToString()} = " + fraction1.Point.ToString());
                        ConsoleUtils.Print($"{fraction2.ToString()} = " + fraction2.Point.ToString());
                        break;
                    default:
                        ConsoleUtils.Print("Такой операции нет");
                        break;
                }
            }
            while (answer != 0);

            ConsoleUtils.WaitNextPress();
        }

        static ConsoleKey Menu()
        {
            ConsoleUtils.Clear();
            ConsoleUtils.HomeworkTitle(2);
            ConsoleUtils.Print("Выберите задачу (для выхода нажмите Esc):");
            ConsoleUtils.Print("1 - Задача №1");
            ConsoleUtils.Print("2 - Задача №2");
            ConsoleUtils.Print("3 - Задача №3");
            ConsoleUtils.Print("4 - Задача №4");
            ConsoleUtils.Print("5 - Задача №5");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
            return keyInfo.Key;
        }

        static void Main()
        {
            ConsoleKey key;
            do
            {
                key = Menu();
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Task1();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Task2();
                        break;
                    case ConsoleKey.D3:
                        Task3();
                        break;
                    case ConsoleKey.D4:
                        Task4();
                        break;
                    case ConsoleKey.D5:
                        Task5();
                        break;
                    case ConsoleKey.Escape:
                        ConsoleUtils.Print("Выход!");
                        break;
                    default:
                        ConsoleUtils.Print("Такого задания не было!");
                        break;
                }
            }
            while (key != ConsoleKey.Escape);
        }
    }
}
