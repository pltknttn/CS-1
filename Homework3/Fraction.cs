using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Class
{
    public class Fraction
    {
        private int numerator;              // Числитель
        public int Numerator { get { return numerator; } set { numerator = value; } }

        private int denominator;			// Знаменатель
        public int Denominator { get { return denominator; } set { denominator = value; } } 

        // Возвращает наибольший общий делитель\знаменатель (Алгоритм Евклида)
        public static int GetGreatestCommonDivisor(int a, int b)
        {
            int temp = 0;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Возвращает наименьшее общее кратное
        public static int GetLeastCommonMultiple(int a, int b)
        {
            int greatestCommonDivisor = GetGreatestCommonDivisor(a, b);
            return greatestCommonDivisor != 0 ? a * b / greatestCommonDivisor : 0;
        }

        private int SimpleDivide(int a, int b)
        {
            if (b == 0) return 0;

            return a / b;
        }

        //сложение  
        public Fraction Plus(Fraction x)
        {
            int greatestCommonDivisor = GetLeastCommonMultiple(x.Denominator, denominator);

            Fraction y = new Fraction();
            y.denominator = greatestCommonDivisor;
            y.numerator = numerator * SimpleDivide(greatestCommonDivisor, denominator) + x.Numerator * SimpleDivide(greatestCommonDivisor, x.Denominator);
            return y;
        }
        
                        
        //вычитание 
        public Fraction Minus(Fraction x)
        {
            int greatestCommonDivisor = GetLeastCommonMultiple(x.Denominator, this.denominator);

            Fraction y = new Fraction();
            y.denominator = greatestCommonDivisor;
            y.numerator = numerator * SimpleDivide(greatestCommonDivisor, denominator) - x.Numerator * SimpleDivide(greatestCommonDivisor, x.Denominator);
            return y;
        }

        // произведение 
        public Fraction Multi(Fraction x)
        {
            Fraction y = new Fraction();
            y.denominator = denominator * x.Denominator;
            y.numerator = numerator * x.Numerator;
            return y;
        }

        // деление 
        public Fraction Divide(Fraction x)
        {
            Fraction y = new Fraction();
            y.denominator = denominator * x.Numerator;
            y.numerator = numerator * x.Denominator;
            return y;
        }
        
        public Fraction Reduction()
        {
            int greatestCommonDivisor = GetGreatestCommonDivisor(numerator, denominator);

            Fraction y = new Fraction();
            y.denominator = greatestCommonDivisor != 0 && denominator % greatestCommonDivisor == 0 ? SimpleDivide(denominator, greatestCommonDivisor) : denominator;
            y.numerator = greatestCommonDivisor != 0 && numerator % greatestCommonDivisor == 0 ? SimpleDivide(numerator, greatestCommonDivisor) : numerator;
            return y;
        }

        public double Point
        {
            get {
                if (denominator == 0) new ArgumentException("Знаменатель не может быть равен \"0\"");

                return (numerator * 0.01) / denominator;
            }
        }

        public override string ToString()
        {
            return numerator + "/" + denominator;
        }

    }
}
