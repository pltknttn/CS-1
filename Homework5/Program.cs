using CS.Utils;
using System;
using System.Collections.Generic;
using System.IO; 
using System.Text;
using System.Text.RegularExpressions;

namespace Homework5
{
    class Program
    {
        /* Домашнее задание №5         
        Автор: Полятыкина Татьяна
       */

        static Random random = new Random();

        static void Task1()
        {
            ConsoleUtils.HomeworkTask(1, @"
Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
а) без использования регулярных выражений;
б) с использованием регулярных выражений.\n\r");

            string login = ConsoleUtils.Question("Введите логин:");

            ConsoleUtils.Print($"Результат проверки без использования регулярных выражений = {Login.IsValidViaChar(login)}");
            ConsoleUtils.Print($"Результат проверки с использованием регулярных выражений = {Login.IsValidViaRegex(login)}");
            ConsoleUtils.WaitNextPress();
        }

        static void Task2()
        {
            ConsoleUtils.HomeworkTask(2, @"
Разработать класс Message, содержащий следующие статические методы для обработки
текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
Продемонстрируйте работу программы на текстовом файле с вашей программой.\n\r");

            string fileName = "Message.txt";
            string fileResult = "Task2Result.txt";

            string row = string.Empty;
            StringBuilder builder = new StringBuilder();
            try
            {
                row = File.ReadAllText(fileName, Encoding.UTF8);

                builder.AppendLine($"Считали данные из файла: \n\r{row}\n\r");

                int countLetter = ConsoleUtils.ReadInt("Найдем слова не более n букв. Введите количество букв:");
                char ch = ConsoleUtils.ReadChar("Удалим слова, заканчиваются на заданный символ. Введите символ:");

                builder.AppendLine($"Слова, которые содержат не более {countLetter} букв:");
                string[] words = Message.GetWords(row, countLetter);
                if (words.Length == 0)
                    builder.AppendLine("Таких слов нет");
                else
                {
                    foreach (string word in words)
                    {
                        builder.AppendLine(word);
                    }
                }
                builder.AppendLine();

                string newRow = Message.Clear(row, ch);
                string maxWord = Message.MaxWord(row);
                string rowMaxWords = Message.GetRowMaxWords(row);

                builder.AppendLine($"Удалили из строки все слова, которые заканчиваются на {ch} символ. Результат:\n\r{newRow}\n\r");
                builder.AppendLine($"Самое длинное слово в строке: \n\r{maxWord}\n\r");
                builder.AppendLine($"Строка из самых длинных слов в строке: \n\r{rowMaxWords}\n\r");

            }
            catch (FileNotFoundException)
            {
                ConsoleUtils.Print($"Файл {fileName} не найден");
            }
            catch (Exception ex)
            {
                ConsoleUtils.Print($"При считывании файла {fileName} возникла ошибка: {ex.Message}");
            }

            ConsoleUtils.Print(builder.ToString());

            try
            {
                File.WriteAllText(fileResult, builder.ToString(), Encoding.UTF8);
            }
            catch (FileNotFoundException)
            {
                ConsoleUtils.Print($"Файл {fileName} не найден");
            }
            catch (Exception ex)
            {
                ConsoleUtils.Print($"При записи результатов в файл {fileResult} возникла ошибка: {ex.Message}");
            }

            ConsoleUtils.WaitNextPress();
        }

        static string Reverse(string input)
        {
            StringBuilder stringBuilder = new StringBuilder(input.Length * 2);

            for (int i = input.Length - 1; i >= 0; i--)
                stringBuilder.Append(input[i]);

            return stringBuilder.ToString();
        }

        static void Task3()
        {
            ConsoleUtils.HomeworkTask(3, @"
Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
а с использованием методов C#;
б *разработав собственный алгоритм.
Например:
            badc являются перестановкой abcd.\n\r");

            string row1 = ConsoleUtils.Question("Введите 1-у строку:");
            string row2 = ConsoleUtils.Question("Введите 2-у строку:");

            if (Reverse(row1).CompareTo(row2) == 0)
                ConsoleUtils.Print($"Строка \"{row1}\" является перестановкой \"{row2}\".");
            else
                ConsoleUtils.Print($"Строка \"{row1}\" НЕ является перестановкой \"{row2}\".");

            ConsoleUtils.WaitNextPress();
        }

        static void PrintBadMarks(Learner[] learners, double[] marks, double bestMark)
        {
            Array.Sort(marks);//отсортируем по возрастанию

            if (marks[0] == bestMark && bestMark > 0)
            {
                ConsoleUtils.Print($"Все ученики показали одинаковый средний балл.");
            }
            else if (bestMark == 0)
            {
                ConsoleUtils.Print($"Ученики показали плохой результат. Никто не набрал баллов.");
            }


            double badMark = 0;
            int printCountBadMark = 0;

            for (int i = 0; i < marks.Length; i++)
            {
                if (printCountBadMark >= 3) return;

                if (i > 0 && badMark == marks[i]) continue;

                badMark = marks[i];

                ConsoleUtils.Print($"Средний балл { badMark:f1} показали:");

                foreach (Learner learner in learners)
                {
                    if (learner.AverageMark == badMark)
                        ConsoleUtils.Print(learner.ToString());
                }

                printCountBadMark++;

                ConsoleUtils.Print();
            }
        }

        static void Task4()
        {
            ConsoleUtils.HomeworkTask(4, @"
Задача ЕГЭ.
На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не
превосходит 100, каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран
фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.\n\r");

            string fileName = "ExamResult.txt";
            StreamReader reader = null;
            int maxCountLerners = 100;
            try
            {
                reader = new StreamReader(fileName);

                int.TryParse(reader.ReadLine(), out int n);

                if (n >= 10 && n < maxCountLerners)
                {
                    int i = 0;
                    Learner[] learners = new Learner[n];
                    double[] marks = new double[n];
                    double bestMark = 0;
                    double averageMark = 0;
                    Regex regex = new Regex(@"^([a-zA-Zа-яА-я-]{1,20}) ([a-zA-Zа-яА-я-]{1,15}) (\d) (\d) (\d)$");
                    Match match = null;

                    while (!reader.EndOfStream && i < maxCountLerners && i < n)
                    {
                        match = regex.Match(reader.ReadLine());
                        if (!match.Success) continue;

                        learners[i] = new Learner(match.Groups[1].Value, match.Groups[2].Value, new int[] { int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value) });
                        averageMark = learners[i].AverageMark;
                        marks[i] = averageMark;
                        i++;

                        if (bestMark < averageMark)
                            bestMark = averageMark;
                    }

                    if (i < n)
                        ConsoleUtils.Print($"В файле {fileName} представлены некорректные данные. Данные учеников указываются в формате \"<Фамилия> <Имя> <оценки>\" определенной длины");
                    else
                        PrintBadMarks(learners, marks, bestMark);
                }
                else
                {
                    ConsoleUtils.Print($"В файле {fileName} указано некорректное число учеников. Число учеников не меньше 10, но не превосходит 100.");
                }
            }
            catch (FileNotFoundException)
            {
                ConsoleUtils.Print($"Файл {fileName} не найден");
            }
            catch (Exception ex)
            {
                ConsoleUtils.Print($"При считывании файла {fileName} возникла ошибка: {ex.Message}");
            }
            finally
            {
                reader?.Close();
            }

            ConsoleUtils.WaitNextPress();
        }

        static void Task5()
        {
            ConsoleUtils.HomeworkTask(5, @"
Написать игру «Верю. Не верю».
В файле хранятся вопрос и ответ, правда это или нет. 
Например: «Шариковую ручку изобрели в древнем Египте», «Да». 
Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку. 
Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ. 
Список вопросов ищите во вложении или воспользуйтесь интернетом.\n\r");

            string fileName = "Game.txt";
            try
            {
                string[] games = File.ReadAllLines(fileName);
                Dictionary<int, Puzzle> puzzles = new Dictionary<int, Puzzle>();
                Regex regex = new Regex(@"^(.+) \(([дДаАнНеЕтТ]{2,3})\)$");
                Match match = null;

                for (int i = 0; i < games.Length; i++)
                {
                    match = regex.Match(games[i]);
                    if (!match.Success) continue;

                    puzzles.Add(i + 1, new Puzzle(match.Groups[1].Value, match.Groups[2].Value));
                }

                int countPuzzle = puzzles.Count == 0 ? 0 : puzzles.Count < 5 ? puzzles.Count : 5;
                int rightAnswer = 0;
                int[] questionsIds = new int[countPuzzle];
                int id = 0;
                for (int i = 0; i < countPuzzle; i++)
                {
                    do
                    {
                        id = random.Next(1, countPuzzle + 1);
                        if (Array.IndexOf(questionsIds, id) < 0)
                            questionsIds[i] = id;
                    }
                    while (questionsIds[i] == 0);
                }

                foreach (int questionsId in questionsIds)
                {
                    Puzzle puzzle = puzzles[questionsId];
                    if (puzzle.CheckAnswer(ConsoleUtils.Question(puzzle.Question)))
                    {
                        rightAnswer++;
                        ConsoleUtils.Print("Вы ответили верно");
                    }
                    else ConsoleUtils.Print("Вы ответили не верно");
                }

                ConsoleUtils.Print($"\n\rВаш итог: \n\rВерно {rightAnswer}\n\rВсего вопросов {countPuzzle}\n\r {(rightAnswer == countPuzzle ? "Вы молодец!" : "")}");
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
            ConsoleUtils.Print("5 - Задача №5");
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
