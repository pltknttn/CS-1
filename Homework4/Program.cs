using CS.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Program
    {
        /* Домашнее задание №4         
         Автор: Полятыкина Татьяна
        */

        static void Task1()
        {
            ConsoleUtils.HomeworkTask(1, @"
Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые
значения от –10 000 до 10 000 включительно.Заполнить случайными числами.Написать
программу, позволяющую найти и вывести количество пар элементов массива, в которых только
одно число делится на 3.В данной задаче под парой подразумевается два подряд идущих
элемента массива.");

            Random random = new Random();
            int arraySize = 20;
            int min = -10000;
            int max = 10000;
            int[] intArray = new int[arraySize];
            int part1 = 0;
            int part2 = 0;
            int number = 0;
            int countPair = 0;

            for (int i = 0; i < arraySize; i++)
            {
                number = random.Next(min, max + 1);
                intArray[i] = number;

                if ((i + 1) % 2 == 0)
                    part2 = number;
                else
                    part1 = number;

                if (i > 1 && (part1 % 3 == 0 || part2 % 3 == 0) && (part1 % 3 != 0 || part2 % 3 != 0))
                    countPair += 1;
            }

            ConsoleUtils.Print($"Сгенерирован массив:\n\r{string.Join(";", intArray)}\n\r");
            ConsoleUtils.Print($"Количество пар, в которых только одно число делится на 3, равно {countPair}");
            ConsoleUtils.WaitNextPress();
        }

        static void Task2()
        {
            ConsoleUtils.HomeworkTask(2, @"2. 
а) Дописать класс MyArray для работы с одномерным массивом. 
Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом. 
Создать свойство Sum, которые возвращают сумму элементов массива, 
метод Inverse, меняющий знаки у всех элементов массива, 
метод Multi, умножающий каждый элемент массива на определенное число, 
свойство MaxCount, возвращающее количество максимальных элементов, создать индексирующее свойство, 
свойство Length, возвращающая длину массива, 
метод Merge объединяющий два массива в один и возвращающий объединенный массив, 
метод Copy(), возвращающий копию массива, 
метод Resize(int newSize) изменяющий размер массива, 
свойство GetArray с помощью которого можно получить ссылку на массив. 
В Main продемонстрировать работу класса.
б)*Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.");

            MyArray myArray = new MyArray(20, -10, 500, 4);

            ConsoleUtils.Print($"Сгенерирован массив (размерность 20, элементы от -10 до 500, шаг 20):\n\r{myArray}\n\r");
            ConsoleUtils.Print($"Sum [{myArray}]:\n\r{myArray.Sum}\n\r");
            ConsoleUtils.Print($"Inverse [{myArray}]:\n\r{string.Join(";", myArray.Inverse())}\n\r");
            ConsoleUtils.Print($"Multi(*10) [{myArray}]:\n\r{string.Join(";", myArray.Multi(10))}\n\r");
            ConsoleUtils.Print($"MaxCount [{myArray}]:\n\r{myArray.MaxCount}\n\r");
            ConsoleUtils.Print($"Length [{myArray}]:\n\r{myArray.Length}\n\r");

            MyArray myArray2 = new MyArray(30, 0, 999, 1);
            MyArray mergeArray = MyArray.Merge(myArray, myArray2);
            ConsoleUtils.Print($"Merge [{myArray}] c массивом [{myArray2}]: \n\r{mergeArray}\n\r");

            MyArray copyMyArray = MyArray.Copy(myArray);
            ConsoleUtils.Print($"Copy [{myArray}]:\n\r{copyMyArray}\n\r");

            MyArray.Resize(ref copyMyArray, 15);
            ConsoleUtils.Print($"Resize (newSize = 15) [{myArray}]:\n\r{copyMyArray}\n\r");

            int[] array = myArray.GetArray();
            ConsoleUtils.Print($"GetArray [{myArray}]:\n\r{array}{{{string.Join(";", array)}}}\n\r");

            string fileName = "data1.txt";
            try
            {
                myArray = new MyArray(fileName);
                ConsoleUtils.Print($"Считали массив из файла {fileName}: \n\r{myArray}\n\r");
            }
            catch(FileNotFoundException)
            {
                ConsoleUtils.Print($"Файл {fileName} не найден");
            }
            catch(Exception ex)
            {
                ConsoleUtils.Print($"При считывании файла {fileName} возникла ошибка: {ex.Message}");
            }

            try
            {
                ConsoleUtils.Print($"Записать значения массива \n\r[{mergeArray}] \n\rв файл {fileName}");
                
                MyArray.WriteToFile(fileName, mergeArray.GetArray());

                ConsoleUtils.Print($"Результат\n\r{string.Join(";", MyArray.ReadToFile(fileName))}\n\r");
            }
            catch (FileNotFoundException)
            {
                ConsoleUtils.Print($"Файл {fileName} не найден");
            }
            catch (Exception ex)
            {
                ConsoleUtils.Print($"При записи значений массива\n\r[{mergeArray}]\n\rв файла {fileName} возникла ошибка:\n\r{ex.Message}");
            }
            ConsoleUtils.WaitNextPress(); 
        }

        static bool Login(Accounts accounts)
        {
            if (accounts == null) return false;

            string login = string.Empty;
            string password = string.Empty;
            int attempCountMax = 3;
            bool isAutorize = false;

            do
            {
                login = ConsoleUtils.Question("Введите логин:");
                password = ConsoleUtils.Question("Введите пароль:");
                isAutorize = accounts.IsCheck(login, password);

                if (!isAutorize)
                    ConsoleUtils.Print("Пароль и\\или логин введены неверно");
            }
            while (!isAutorize && --attempCountMax > 0);

            if (isAutorize)
            {
                ConsoleUtils.Print("Проверка пройдена.");
                return true;
            }

            ConsoleUtils.Print("Проверка не пройдена. Попытки исчерпаны...");
            return false;
        }

        static void Task3()
        {
            ConsoleUtils.HomeworkTask(3, @"
Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив. 
Создайте структуру Account, содержащую Login и Password.");

            string fileName = "data2.txt"; 
            
            try
            {
                Accounts accounts = new Accounts(fileName);

                if (Login(accounts))
                    ConsoleUtils.Print("Авторизация пройдена.");
                else
                    ConsoleUtils.Print("Авторизация не пройдена.");
            }
            catch (FileNotFoundException)
            {
                ConsoleUtils.Print($"Файл {fileName} не найден");
            }
            catch (Exception ex)
            {
                ConsoleUtils.Print($"При считывании файла {fileName} возникла ошибка: {ex.Message}");
            }
            
            ConsoleUtils.WaitNextPress();
        }

        static void Task4()
        {
            ConsoleUtils.HomeworkTask(4, @"
а) Реализовать класс для работы с двумерным массивом. 
Реализовать конструктор, заполняющий массив случайными числами. 
Создать методы, которые возвращают сумму всех элементов массива, 
сумму всех элементов массива больше заданного, 
свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, 
метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
в) Обработать возможные исключительные ситуации при работе с файлами.");

            MyArrayTwoDim myArrayTwoDim = new MyArrayTwoDim(20, -45, 999);

            ConsoleUtils.Print($"Массив:\n\r{myArrayTwoDim}\n\r");
            ConsoleUtils.Print($"Sum = {myArrayTwoDim.Sum()}");
            ConsoleUtils.Print($"Sum( val > 100) = {myArrayTwoDim.Sum(100)}");
            ConsoleUtils.Print($"Min = {myArrayTwoDim.Min}");
            ConsoleUtils.Print($"Max = {myArrayTwoDim.Max}");

            myArrayTwoDim.MaxElementIndex(out int i, out int j);
            ConsoleUtils.Print($"Максимальный элемент находится в ячейке [{i + 1}, {j + 1}] (нумерация от 1)");

            string fileName = "data3.txt";

            try
            {
                MyArrayTwoDim myArrayTwoDim2 = new MyArrayTwoDim(fileName);
                ConsoleUtils.Print($"\n\rСчитали массив из файла {fileName}: \n\r{myArrayTwoDim2}\n\r");
            }
            catch(DirectoryNotFoundException)
            {
                ConsoleUtils.Print($"\n\rПри считывании файла {fileName} возникла ошибка: Каталог не существует");
            }
            catch (FileNotFoundException)
            {
                ConsoleUtils.Print($"\n\rФайл {fileName} не найден");
            }
            catch (Exception ex)
            {
                ConsoleUtils.Print($"\n\rПри считывании файла {fileName} возникла ошибка:\n\r{ex.Message}");
            }

            try
            {
                ConsoleUtils.Print($"\n\rЗаписать значения массива \n\r[{myArrayTwoDim}] \n\rв файл {fileName}\n\r");

                MyArrayTwoDim.WriteToFile(fileName, myArrayTwoDim.GetArray());

                ConsoleUtils.Print($"\n\rРезультат\n\r{MyArrayTwoDim.GetElements(MyArrayTwoDim.ReadToFile(fileName))}");
            }
            catch (DirectoryNotFoundException)
            {
                ConsoleUtils.Print($"\n\rПри считывании файла {fileName} возникла ошибка: Каталог не существует");
            }
            catch (FileNotFoundException)
            {
                ConsoleUtils.Print($"\n\rФайл {fileName} не найден");
            }
            catch (Exception ex)
            {
                ConsoleUtils.Print($"\n\rПри записи значений массива \n\r[{myArrayTwoDim}] \n\rв файла {fileName} возникла ошибка:\n\r{ex.Message}");
            }
            ConsoleUtils.WaitNextPress();
        }

        static ConsoleKey Menu()
        {
            ConsoleUtils.Clear();
            ConsoleUtils.Print("", ConsoleColor.White);
            ConsoleUtils.HomeworkTitle(2);
            ConsoleUtils.Print("Выберите задачу (для выхода нажмите Esc):", ConsoleColor.DarkGreen);
            ConsoleUtils.Print("1 - Задача №1");
            ConsoleUtils.Print("2 - Задача №2");
            ConsoleUtils.Print("3 - Задача №3");
            ConsoleUtils.Print("4 - Задача №4"); 
            ConsoleUtils.Print("", ConsoleColor.White);
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
