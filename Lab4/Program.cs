using System;
using System.Collections.Generic;
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
            ComplexNumber[] array =
            {
                new ComplexNumber(3,4),
                new ComplexNumber(1,-2),
                new ComplexNumber(-2,1),
                new ComplexNumber(5,12),
                new ComplexNumber(-3,-4)
            };
            Console.WriteLine("Original array:");
            foreach (var c in array)
            {
                Console.WriteLine(c.ToString());
            }

            Array.Sort(array);
            Console.WriteLine("\nSorted array by modulus:");
            foreach (var c in array)
            {
                Console.WriteLine(c);
            }

            var maxNumber = array.Max();
            Console.WriteLine($"\nComplex number with the largest modulus: {maxNumber.ToString()}");
            var minNumber = array.Min();
            Console.WriteLine($"\nComplex number with the smallest modulus: {minNumber.ToString()}");

            ComplexNumber[] array_1 = array.Where(c => c.Im >= 0).ToArray();
            foreach (var c in array_1)
            {
                Console.WriteLine($"\n With - {c.ToString()}");
            }
            Console.WriteLine();

            List<ComplexNumber> complexNumber = new List<ComplexNumber>
            {
                new ComplexNumber(3,4),
                new ComplexNumber(1,-2),
                new ComplexNumber(-2,1),
                new ComplexNumber(5,12),
                new ComplexNumber(-3,-4)
            };
            foreach (var c in complexNumber)
            {
                Console.WriteLine($"\n List - {c.ToString()}");
            }

            Console.WriteLine("\nSorting the list by modulus:");
            complexNumber.Sort();
            foreach (var c in complexNumber)
            {
                Console.WriteLine($"\n Sorted List - {c.ToString()}");
            }

            var min = complexNumber.Min();
            var max = complexNumber.Max();
            Console.WriteLine($"\n Minimum in the list: {min.ToString()}");
            Console.WriteLine($"\n Maximum in the list: {max.ToString()}");

            var filteredList = complexNumber.Where(c => c.Re >= 0).ToList();
            Console.WriteLine("\nFiltered list (Im part >= 0):");
            foreach (var c in filteredList)
            {
                Console.WriteLine($"\n Filtered List - {c.ToString()}");
            }

            Console.WriteLine("\nList after removing the second element:");
            complexNumber.Remove(complexNumber[1]);
            foreach (var c in complexNumber)
            {
                Console.WriteLine($"\n List - {c.ToString()}");
            }
            Console.WriteLine("This is ");

            complexNumber.Remove(min);
            Console.WriteLine("\nList after removing the minimum element:");
            foreach (var c in complexNumber)
            {
                Console.WriteLine($"\n List - {c.ToString()}");
            }

            complexNumber.Clear();
            Console.WriteLine("\nList after clearing all elements:");
            foreach (var c in complexNumber)
            {
                Console.WriteLine($"\n List - {c.ToString()}");
            }

            Console.WriteLine();

            Console.WriteLine("Demonstrating HashSet functionality:");
            HashSet<ComplexNumber> complexes = new HashSet<ComplexNumber>();
            ComplexNumber c1 = new ComplexNumber(6, 7);
            ComplexNumber c2 = new ComplexNumber(1, 2);
            ComplexNumber c3 = new ComplexNumber(6, 7);
            ComplexNumber c4 = new ComplexNumber(1, -2);
            ComplexNumber c5 = new ComplexNumber(-5, 9);
            complexes.Add(c1);
            complexes.Add(c2);
            complexes.Add(c3);
            complexes.Add(c4);
            complexes.Add(c5);
            foreach (var c in complexes)
            {
                Console.WriteLine($"\n HashSet - {c}");
            }
            Console.WriteLine("\nSorting the HashSet by modulus:");
            var sortedComplexes = complexes.OrderBy(c => c.Module()).ToList();
            foreach (var c in sortedComplexes)
            {
                Console.WriteLine($"\n Sorted HashSet - {c}");
            }
            Console.WriteLine();
            var setMin = complexes.Min();
            var setMax = complexes.Max();
            Console.WriteLine($"\n Minimum in the HashSet: {setMin}");
            Console.WriteLine($"\n Maximum in the HashSet: {setMax}");
            Console.WriteLine();
            var filteredSet = complexes.Where(c => c.Re >= 0).ToList();
            Console.WriteLine("\nFiltered HashSet (Re part >= 0):");
            foreach (var c in filteredSet)
            {
                Console.WriteLine($"\n Filtered HashSet - {c}");
            }
            Console.WriteLine();
            Dictionary<string, ComplexNumber> dict = new Dictionary<string, ComplexNumber>()
            {
                { "z1", new ComplexNumber(6,7)},
                { "z2", new ComplexNumber(1, 2)},
                { "z3", new ComplexNumber(6, 7)},
                { "z4", new ComplexNumber(1, -2)},
                { "z5", new ComplexNumber(-5, 9)}
            };
            foreach (var kvp in dict)
            {
                Console.WriteLine($"\n Dictionary - Key: {kvp.Key}, Value: {kvp.Value}");
            }
            Console.WriteLine();
            foreach (var key in dict.Keys)
            {
                Console.WriteLine($"\n Dictionary Key - {key}");
            }
            Console.WriteLine();
            foreach (var value in dict.Values)
            {
                Console.WriteLine($"\n Dictionary Value - {value}");
            }

            Console.WriteLine(dict.ContainsKey("z6"));

            Console.WriteLine();
            var dictMin = dict.Values.Min();
            var dictMax = dict.Values.Max();
            Console.WriteLine($"\n Minimum in the Dictionary: {dictMin}");
            Console.WriteLine($"\n Maximum in the Dictionary: {dictMax}");

            var filteredDict = dict.Values.Where(c => c.Im >= 0).ToList();
            foreach (var c in filteredDict)
            {
                Console.WriteLine($"\n Filtered Dictionary Value - {c}");
            }
            Console.WriteLine();
            dict.Remove("z3");
            foreach (var kvp in dict)
            {
                Console.WriteLine($"\n Dictionary after removal - Key: {kvp.Key}, Value: {kvp.Value}");
            }
            Console.WriteLine();
            var secondElement = dict.Keys.ElementAt(1);
            dict.Remove(secondElement);
            foreach (var kvp in dict)
            {
                Console.WriteLine($"\n Dictionary after removing second element - Key: {kvp.Key}, Value: {kvp.Value}");
            }
            Console.WriteLine();
            dict.Clear();
            Console.WriteLine("Dictionary after clearing all elements:");
        }
    }
    public class ComplexNumber : ICloneable, IEquatable, IModular, IComparable<ComplexNumber>
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
            string result = im >= 0 ? "+" : "-";
            return $"{re} {result} {Math.Abs(im)}i";
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
            if (ReferenceEquals(c1, c2))
            {
                return true;
            }
            if(c1 is null || c2 is null)
            {
                return false;
            }
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
            if (obj == null) return false;
            return re == ((ComplexNumber)obj).re && im == ((ComplexNumber)obj).im;
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
        public int CompareTo(ComplexNumber other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.Module().CompareTo(other.Module());
        }

    }
}

