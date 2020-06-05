using System;

namespace Profile
{
    /*Автор: Полятыкина Татьяна*/

    class Program
    {        
        /// <summary>
        /// Печать
        /// </summary>
        /// <param name="msg"></param>
        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }
                 
        /// <summary>
        /// Пауза с параметром
        /// </summary>
        static void Pause(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        /// <summary>
        /// Запрос значения
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        static string Question(string msg)
        {
            Console.Write($"{msg}\t");
            return Console.ReadLine();
        }
               
        /// <summary>
        /// Расчет индекса массы тела
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        static double CalcBMI(double height, double weight)
        {
            if (height == 0) return 0;

            return weight / (height * height);
        }

        static void Main()
        {
            Print("------------------------------------\n\r");
            Print("Программа \"Анкета\". \n\rПоследовательно задаются вопросы (имя, фамилия, рост, вес).");
            Print("Результат выводится в одну строчку 3-мя способами: \n\rа) используя склеивание; \n\rб) используя форматированный вид; \n\rв) используя вывод со знаком $");
            Print("Автор: Полятыкина Татьяна Игоревна");
            Print("------------------------------------\n\r");

            string firstname = Question("Ваше имя?");
            string surname = Question("Ваша фамилия?");
            int.TryParse(Question("Ваш рост (в сантиметрах)?"), out int growth);
            double.TryParse(Question("Ваш вес (в килограммах)?").Replace('.',','), out double weight);

            Print("\n\rРезультаты:");
            Print(surname + " " + firstname + " рост " + growth + ", вес " + weight);            
            Print(string.Format("{0} {1} рост {2}, вес {3}", surname, firstname, growth, weight));
            Print($"{surname} {firstname} рост {growth}, вес {weight}");
            Pause("Пауза. Для продолжения нажмите любую клавишу...\n\r");

            Print("------------------------------------\n\r");
            Print($"{firstname}, Ваш ИМТ (индекс массы тела) равен {(CalcBMI(0.01*growth, weight)):f2}");
            Pause("Пауза. Для выхода нажмите любую клавишу...\n\r");
        }
    }
}
