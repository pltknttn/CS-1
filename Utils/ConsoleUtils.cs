using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Utils
{
    /*Автор: Полятыкина Татьяна*/

    public static partial class ConsoleUtils
    {
        /// <summary>
        /// Печать
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="foregroundColor"></param>
        public static void Print(string msg, int x, int y, ConsoleColor foregroundColor)
        {
            //Установим позицию курсора на экране
            Console.SetCursorPosition(x, y);
            //Установим цвет символов
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Печать
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Печать
        /// </summary>
        /// <param name="msg"></param>
        public static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Пауза с параметром
        /// </summary>
        public static void Pause(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        /// <summary>
        /// Пауза
        /// </summary>
        public static void Pause()
        {
            Console.ReadKey();
        }

        public static void WaitKeyPress()
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static long ReadLong(string msg)
        {
            Console.Write($"{msg}\t");
            long.TryParse(Console.ReadLine(), out long result);
            return result;
        }

        public static int ReadInt(string msg)
        {
            Console.Write($"{msg}\t");
            int.TryParse(Console.ReadLine(), out int result);
            return result;
        }

        public static double ReadDouble(string msg)
        {
            Console.Write($"{msg}\t");
            double.TryParse(Console.ReadLine().Replace('.', ','), out double result);
            return result;
        }

        public static decimal ReadDecimal(string msg)
        {
            Console.Write($"{msg}\t");
            decimal.TryParse(Console.ReadLine().Replace('.', ','), out decimal result);
            return result;
        }

        /// <summary>
        /// Запрос значения
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string Question(string msg)
        {
            Console.Write($"{msg}\t");
            return Console.ReadLine();
        }

        public static void HomeworkTitle(int lesson)
        {            
            ConsoleUtils.Print($"Домашнее задание к уроку №{lesson}.");
            ConsoleUtils.Print("Автор: Полятыкина Татьяна"); 
        }

        public static void HomeworkTask(int task, string text)
        {
            ConsoleUtils.Print($"Задача № {task}.");
            ConsoleUtils.Print(text);
            ConsoleUtils.Print("Автор: Полятыкина Татьяна");
        }
    }
}
