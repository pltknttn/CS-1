using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public delegate double Fun(double x);
    public delegate double Fun2(double a, double x);

    public class MyFun {
        public Fun Function { get; set; }
        public string FunctionText { get; set; }
        public ConsoleKey[] ConsoleKeys { get; set; }

        public MyFun(Fun fun, string functionText, ConsoleKey[] consoleKeys)
        {
            Function = fun;
            FunctionText = functionText;
            ConsoleKeys = consoleKeys;
        }

        public override string ToString()
        {
            return FunctionText;
        }
    }

    public static class Functions
    {
        public static void Table(Fun f, double start, double finish, double h)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (start <= finish)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", start, f?.Invoke(start));
                start += h;
            }
            Console.WriteLine("---------------------");
        }

        public static void Table(Fun2 f, double koeff, double start, double finish, double h)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (start <= finish)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", start, f?.Invoke(koeff, start));
                start += h;
            }
            Console.WriteLine("---------------------");
        }

        public static double MyFunc(double x)
        {
            return x * x * x;
        }

        public static double MyFunc2(double x)
        {
            return Math.Cos(Math.Log(x));
        }

        public static double MyFunc3(double a, double x)
        {
            return a * x * x;
        }

        public static double MyFunc4(double a, double x)
        {
            return a * Math.Sin(x);
        }

        public static MyFun[] MyFunctions = new MyFun[]
        {
             new MyFun((x)=>{ return x*x - 50*x+10; }, "x*x - 50*x+10", new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.NumPad1 }),
             new MyFun((x)=>{ return x*x*x; }, "x*x*x", new ConsoleKey[] { ConsoleKey.D2, ConsoleKey.NumPad2 }),
             new MyFun((x)=>{ return Math.Sin(x); }, "Math.Sin(x)", new ConsoleKey[] { ConsoleKey.D3, ConsoleKey.NumPad3 }),
             new MyFun((x)=>{ return Math.Cos(x); }, "Math.Cos(x)", new ConsoleKey[] { ConsoleKey.D4, ConsoleKey.NumPad4 }),
             new MyFun((x)=>{ return x*x + Math.Log(x); }, "x*x + Math.Log(x);", new ConsoleKey[] { ConsoleKey.D5, ConsoleKey.NumPad5 }),
             new MyFun((x)=>{ return Math.Sqrt(x); }, "Math.Sqrt(x)", new ConsoleKey[] { ConsoleKey.D6, ConsoleKey.NumPad6 }),
        };

        public static void SaveFunc(Fun f, string fileName, double a, double b, double h)
        {            
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                if (f == null) return;

                bw = new BinaryWriter(fs);                
                double x = a;

                while (x <= b && f != null)
                {
                    bw.Write(f.Invoke(x));
                    x += h;
                }                
            }
            finally
            {
                bw?.Close();
                fs?.Close();
            }
        }

        public static List<double> Load(string fileName, out double min)
        {
            min = double.MaxValue;            
            FileStream fs = null;
            BinaryReader br = null;
            List<double> values = new List<double>();
            double d;

            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                
                for (int i = 0; i < fs.Length / sizeof(double); i++)
                {
                    // Считываем значение и переходим к следующему
                    d = br.ReadDouble();
                    values.Add(d);
                    if (d < min) min = d;
                }
            }
            finally
            {
                br?.Close();
                fs?.Close();
            }
            return values;
        }
    }
}
