using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Utils
{
    public static partial class MathUtils
    {
        #region Min

        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }

        public static int Min(int a, int b, int c)
        {
            return Min(Min(a, b), c);
        }

        public static long Min(long a, long b)
        {
            return a < b ? a : b;
        }

        public static long Min(long a, long b, long c)
        {
            return Min(Min(a, b), c);
        }

        public static double Min(double a, double b)
        {
            return a < b ? a : b;
        }

        public static double Min(double a, double b, double c)
        {
            return Min(Min(a, b), c);
        }

        public static decimal Min(decimal a, decimal b)
        {
            return a < b ? a : b;
        }

        public static decimal Min(decimal a, decimal b, decimal c)
        {
            return Min(Min(a, b), c);
        }

        #endregion

        #region Max

        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public static int Max(int a, int b, int c)
        {
            return Max(Max(a, b), c);
        }

        public static long Max(long a, long b)
        {
            return a > b ? a : b;
        }

        public static long Max(long a, long b, long c)
        {
            return Max(Max(a, b), c);
        }

        public static double Max(double a, double b)
        {
            return a > b ? a : b;
        }

        public static double Max(double a, double b, double c)
        {
            return Max(Max(a, b), c);
        }

        public static decimal Max(decimal a, decimal b)
        {
            return a > b ? a : b;
        }

        public static decimal Max(decimal a, decimal b, decimal c)
        {
            return Max(Max(a, b), c);
        }

        #endregion

        public static int CountDigits(long number)
        {
            int count = (number == 0) ? 1 : 0;
            while (number != 0)
            {
                count++;
                number /= 10;
            }
            return count;
        }         

        public static int NumberSum(int num)
        {
            int val = Math.Abs(num);
            int sum = 0;
            while(val != 0)
            {
                sum = sum + val % 10;
                val = val / 10;
            }
            return sum;
        }

        public static long NumberSum(long num)
        {
            long val = Math.Abs(num);
            long sum = 0;
            while (val != 0)
            {
                sum = sum + val % 10;
                val = val / 10;
            }
            return sum;
        }

        public static bool IsEvenNumber(int num)
        {
            return num % 2 == 0;
        }

        public static bool IsEvenNumber(long num)
        {
            return num % 2 == 0;
        }

        public static bool IsOddNumber(int num)
        {
            return num % 2 != 0;
        }

        public static bool IsOddNumber(long num)
        {
            return num % 2 != 0;
        }

        public static bool IsGoodNumber(int num)
        {
            return num == 0 ? false : num % NumberSum(num) == 0;
        }

        public static bool IsGoodNumber(long num)
        {
            return num == 0 ? false : num % NumberSum(num) == 0;
        }

        public static bool IsSimpleNumber(int num)
        {
            if (num < 2) return false;

            for (int i = 2; i <= num / 2; i++)
                if (num % i == 0) return false;

            return true;
        }

        public static bool IsSimpleNumber(long num)
        {
            if (num < 2) return false;

            for (int i = 2; i <= num / 2; i++)
                if (num % i == 0) return false;

            return true;
        }

        public static bool IsPrimeNumber(int num)
        {
            if (num < 2) return false;

            int d = 2;

            while (d * d <= num && num % d != 0) 
                d += 1;

            return d * d > num;
        }

        public static bool IsPrimeNumber(long num)
        {
            if (num < 2) return false;

            int d = 2;

            while (d * d <= num && num % d != 0)
                d += 1;

            return d * d > num;
        }

        public static int SimpleDivide(int a, int b)
        {
            if (b == 0) return 0;

            return a / b;
        }
    }
}
