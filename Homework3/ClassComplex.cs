using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Class
{
    public class Complex
    {
        double im; 
        double re; 

        public Complex()
        {
            im = 0;
            re = 0;
        }

        public Complex(double re, double im) : this()
        {
            this.re = re;
            this.im = im;
        }

        //сложение  
        public Complex Plus(Complex x)
        {
            Complex y = new Complex();
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        // произведение 
        public Complex Multi(Complex x)
        {
            Complex y = new Complex();
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }

        //вычитание 
        public Complex Minus(Complex x)
        {
            Complex y = new Complex();
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
         
        public double Im
        {
            get { return im; }
            set
            {
                im = value;
            }
        }

        public double Re
        {
            get { return re; }
            set
            {
                re = value;
            }
        }

        public override string ToString()
        {
            return re + "+" + im + "i";
        }
    }
}
