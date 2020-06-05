using System; 

namespace DistanceBetweenPoints
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

        static double CalcDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        static void Main()
        {
            Print("------------------------------------\n\r");
            Print("Программа \"Расстояние между точками\". \n\rПрограмма расчитывает расстояние между двумя точками."); 
            Print("Автор: Полятыкина Татьяна Игоревна");
            Print("------------------------------------\n\r");

            int.TryParse(Question("Введите координату X первой точки:"), out int x1);
            int.TryParse(Question("Введите координату Y первой точки:"), out int y1);
            int.TryParse(Question("Введите координату X второй точки:"), out int x2);
            int.TryParse(Question("Введите координату Y второй точки:"), out int y2);

            Print($"Расстояние между точками равно {CalcDistance(x1, y1, x2 ,y2):f2}");
            Pause("Пауза. Для выхода нажмите любую клавишу...\n\r");
        }
    }
}
