using System; 

namespace ExchangeOfValues
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Программа обмена значениями между 2-мя переменными");
            Console.WriteLine("Автор: Полятыкина Татьяна Игоревна");
            Console.WriteLine();

            Console.Write($"Введите число a:\t");
            int.TryParse(Console.ReadLine(), out int a); // Присваиваем начальное значение  a

            Console.Write($"Введите число b:\t");
            int.TryParse(Console.ReadLine(), out int b); // Присваиваем начальное значение  b 

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"a={a}");            
            Console.WriteLine($"b={b}");

            Console.ForegroundColor = ConsoleColor.Green;
            int t = a;  
            Console.WriteLine($"В t запоминаем значение a (t = a), t={t}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            a = b;  
            Console.WriteLine($"В a записываем b (a = b), a={a}");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            b = t;  
            Console.WriteLine($"В b записываем сохраненное t (b = t), b={b}");

            Console.ForegroundColor = ConsoleColor.Green;
            t = b;
            Console.WriteLine($"В t записываем сохраненное b (t = b), t={t}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            b = a;
            Console.WriteLine($"В b записываем сохраненное a (b = a), b={b}");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            a = t;
            Console.WriteLine($"В a записываем сохраненное t (a = t), a={a}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"a={a}");
            Console.WriteLine($"b={b}");
            Console.ReadLine();
        }
    }
}
