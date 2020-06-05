using System; 

namespace MyProfile
{
    class Program
    {
        /// <summary>
        /// Печать
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="foregroundColor"></param>
        static void Print(string msg, int x, int y, ConsoleColor foregroundColor)
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
        static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }

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
        /// Пауза
        /// </summary>
        static void Pause()
        {
            Console.ReadKey();
        }

        static void Main()
        {
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("------------------------------------\n\r");
            Console.WriteLine("Программа рассказывает обо мне и выводит текст в разных местах экрана");
            Console.WriteLine("Автор: Полятыкина Татьяна Игоревна");
            Console.WriteLine("------------------------------------\n\r");

            var msg = "Полятыкина Татьяна проживаю в г.о. Люберцы (Московская область)";

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(msg);
            Print(msg, 25, 25, ConsoleColor.Red);
            Print(msg, 10, 35, ConsoleColor.DarkGreen);
            Print("Пауза. Для выхода нажмите любую клавишу...\n\r", 0, 45, ConsoleColor.Gray);
            Pause();
        }
    }
}
