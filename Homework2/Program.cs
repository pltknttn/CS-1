using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Utils;

namespace Homework2
{
    class Program
    {      
        /*Домашнее задание №2         
          Автор: Полятыкина Татьяна
         */

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
            ConsoleUtils.Print("6 - Задача №6");
            ConsoleUtils.Print("7 - Задача №7");
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
                        Homework.Task1(); 
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Homework.Task2(); 
                        break;
                    case ConsoleKey.D3:
                        Homework.Task3(); 
                        break;
                    case ConsoleKey.D4:
                        Homework.Task4(); 
                        break;
                    case ConsoleKey.D5:
                        Homework.Task5(); 
                        break;
                    case ConsoleKey.D6:
                        Homework.Task6(); 
                        break;
                    case ConsoleKey.D7:
                        Homework.Task7(); 
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
