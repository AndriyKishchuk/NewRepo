using System;
namespace Program
{
    interface ICloneable
    {
        ComplexNumber Clone();
    }
    interface IEquatable
    {
        bool Equals(object obj);
    }
    interface IModular
    {
        double Module();
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber number1 = new ComplexNumber(3, 4);
            ComplexNumber number2 = new ComplexNumber(1, -2);
            ComplexNumber number3 = number1.Clone();
            Console.WriteLine($"Number 1: {number1}");
            Console.WriteLine($"Number 2: {number2}");
            Console.WriteLine($"Number 3 (clone of Number 1): {number3}");

        }
    }
    public class ComplexNumber : ICloneable, IEquatable, IModular
    {
        private double re;
        private double im;

        public double Re
        {
            get { return re; }
            set { re = value; }
        }
        public double Im
        {
            get { return im; }
            set { im = value; }
        }

        public ComplexNumber(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        public override string ToString()
        {
            string result = im >= 0 ? $"{re}+{im}i" : $"{re}{im}i";
            return $"{result}{Math.Abs(im)}i";
        }
        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.re + c2.re, c1.im + c2.im);
        }
        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.re - c2.re, c1.im - c2.im);
        }
        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            double real = c1.re * c2.re - c1.im * c2.im;
            double imagine = c1.re * c2.im + c1.im * c2.re;
            return new ComplexNumber(real, imagine);
        }
        public static bool operator ==(ComplexNumber c1, ComplexNumber c2)
        {
            return (c1.re == c2.re) && (c1.im == c2.im);
        }
        public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
        {
            return !(c1 == c2);
        }

        public static ComplexNumber operator -(ComplexNumber c)
        {
            return new ComplexNumber(c.re, -c.im);
        }
        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber c)
            {
                return (this.re == c.re) && (this.im == c.im);

            }
            return false;
        }
        public override int GetHashCode()
        {
            return re.GetHashCode() ^ im.GetHashCode();
        }
        public ComplexNumber Clone()
        {
            ComplexNumber clone = new ComplexNumber(this.re, this.im);
            return clone;
        }
        public double Module()
        {
            return Math.Sqrt(re * re + im * im);

        }
       
    }
}

