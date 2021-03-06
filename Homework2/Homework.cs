﻿using CS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public static class Homework
    {         
        /// <summary>
        /// Задача №1
        /// </summary>
        public static void Task1()
        {
            ConsoleUtils.HomeworkTask(1, "Вычисление минимального из трёх чисел");
            decimal a = ConsoleUtils.ReadDecimal("Введите 1-ое число:");
            decimal b = ConsoleUtils.ReadDecimal("Введите 2-ое число:");
            decimal c = ConsoleUtils.ReadDecimal("Введите 3-ое число:");
            ConsoleUtils.Print($"Минимальное число ({a}, {b}, {c}) равно {MathUtils.Min(a, b, c)}");
            ConsoleUtils.WaitNextPress();
        }

        /// <summary>
        /// Задача №2
        /// </summary>
        public static void Task2()
        {
            ConsoleUtils.HomeworkTask(2, "Подсчет количества цифр числа");
            long num = ConsoleUtils.ReadLong("Введите целое число:");
            ConsoleUtils.Print($"Количество цифр в числе {num} равно {MathUtils.CountDigits(num)}");
            ConsoleUtils.WaitNextPress();
        }

        /// <summary>
        /// Задача №3
        /// </summary>
        public static void Task3()
        {
            ConsoleUtils.HomeworkTask(3, "Посчитать сумму всех нечетных положительных чисел");
            long number = 0;
            long sum = 0;
            do
            {
                number = ConsoleUtils.ReadLong("Введите целое положительное число (для остановки введите 0):");
                if (number < 0) continue;

                sum += MathUtils.IsOddNumber(number) ? number : 0;
            }
            while (number != 0);

            ConsoleUtils.Print($"Сумма нечетных чисел равна {sum}");
            ConsoleUtils.WaitNextPress();
        }

        
        static bool Login()
        {            
            string login = string.Empty;
            string password = string.Empty;
            int attempCountMax = 3;
            bool isAutorize = false;

            do
            {
                login = ConsoleUtils.Question("Введите логин:");
                password = ConsoleUtils.Question("Введите пароль:");
                isAutorize = AppUtils.IsAutorize(login, password);

                if (!isAutorize)
                    ConsoleUtils.Print("Пароль и\\или логин введены неверно");
            }
            while (!isAutorize && --attempCountMax > 0);

            if (isAutorize)
            {
                ConsoleUtils.Print("Проверка пройдена. Спасибо!");
                return true;
            }

            ConsoleUtils.Print("Проверка не пройдена. Попытки исчерпаны...");
            return false;
        }

        /// <summary>
        /// Задача №4
        /// </summary> 
        public static void Task4()
        {
            ConsoleUtils.HomeworkTask(4, "Проверка логина и пароля");
            if (Login())
                ConsoleUtils.Print("Авторизация пройдена.");
            else
                ConsoleUtils.Print("Авторизация не пройдена.");
            ConsoleUtils.WaitNextPress();
        }

        /// <summary>
        /// Задача №5
        /// </summary> 
        public static void Task5()
        {
            double norma_min = 18.5;
            double norma_max = 25.0;

            ConsoleUtils.HomeworkTask(5, "Посчитать индекс массы тела (ИМТ) и провести анализ лишнего веса");      
            ConsoleUtils.Print($"Норма ИМТ {norma_min:f2} от до {norma_max:f2}.");

            int growth = ConsoleUtils.ReadInt("Ваш рост (в сантиметрах)?");
            double weight = ConsoleUtils.ReadDouble("Ваш вес (в килограммах)?");
            double bmi = MathUtils.CalcBodyMassaIndex(0.01 * growth, weight);
           
            ConsoleUtils.Print($"Ваш ИМТ равен {bmi:f2}");
            
            if (bmi > norma_max)
                ConsoleUtils.Print($"У Вас лишний вес, необходимо похудеть на {MathUtils.CalcBodyMassaToNorm(growth, norma_max):f2} кг до нормы.");
            else if (bmi < norma_min)
                ConsoleUtils.Print($"У Вас дефицит в весе, необходимо набрать {MathUtils.CalcBodyMassaToNorm(growth, norma_min):f2} кг до нормы.");
            else
                ConsoleUtils.Print($"У Вас нормальный вес.");

            ConsoleUtils.WaitNextPress();
        }

        /// <summary>
        /// Задача №6
        /// </summary> 
        public static void Task6()
        {
            ConsoleUtils.HomeworkTask(6, "Посчитать количество \"хороших\" числа в диапазоне от 1 до 1 000 000 000");
            DateTime start = DateTime.Now;
            int countGoodNumbers = 0;
            int max = 1000000000;

            for (int i = 1; i <= max; i++)
            {
                if (!MathUtils.IsGoodNumber(i)) continue;
                countGoodNumbers+=1;
                if (i % 10000000 == 0)
                    ConsoleUtils.Print($"Считаем {i}...");
            }

            TimeSpan finish = DateTime.Now - start;
            ConsoleUtils.Print($"Количество хороших чисел равно {countGoodNumbers}.");
            ConsoleUtils.Print($"Время выполнения равно {finish}"); 
            ConsoleUtils.WaitNextPress();
        }

        static void Loop(int a, int b)
        {
            if (a % 1000 == 0)
                Console.WriteLine("{0,6}", a);
            else if (a > 1000)
                Console.Write("{0,6}", a);
            else if (a > 100)
                Console.Write("{0,5}", a);
            else
                Console.Write("{0,4}", a);

            if (a < b)
                Loop(a + 1, b);
        }

        static long SumLoop(int a, int b)
        {
            long sum = 0;
            if (a < b) sum += SumLoop(a + 1, b);        
            return sum += a;
        }

        /// <summary>
        /// Задача №7
        /// </summary> 
        public static void Task7()
        {
            ConsoleUtils.HomeworkTask(7, "Вывести на экран числа от a до b (a < b), посчитать сумму этих числел");

            int a = ConsoleUtils.ReadInt("Введите a:");
            int b = ConsoleUtils.ReadInt("Введите b:");

            ConsoleUtils.Print("Получаем последовательность: ");
            
            Loop(a, b);

            ConsoleUtils.Print("");
            ConsoleUtils.Print($"Сумма чисел будет равна {SumLoop(a, b)}");
            ConsoleUtils.WaitNextPress();
        }
    }
}
