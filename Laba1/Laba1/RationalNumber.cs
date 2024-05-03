using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    public class RationalNumber
    {
        private int _numerator;
        private int _denominator;
        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            _numerator = numerator;
            _denominator = denominator;
            Simplify();
        }

        public override string ToString()
        {
            if (_denominator == 1)
                return _numerator.ToString();
            else
                return $"{_numerator}/{_denominator}";
        }

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(_numerator), Math.Abs(_denominator));
            _numerator /= gcd;
            _denominator /= gcd;
            if (_denominator < 0)
            {
                _numerator = -_numerator;
                _denominator = -_denominator;
            }
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static RationalNumber InputRationalNumber()
        {
            Console.WriteLine("Enter the numerator:");
            int numerator = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the denominator:");
            int denominator = int.Parse(Console.ReadLine());

            return new RationalNumber(numerator, denominator);
        }
        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            int numerator = r1._numerator * r2._denominator + r2._numerator * r1._denominator;
            int denominator = r1._denominator * r2._denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            int numerator = r1._numerator * r2._denominator - r2._numerator * r1._denominator;
            int denominator = r1._denominator * r2._denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            int numerator = r1._numerator * r2._numerator;
            int denominator = r1._denominator * r2._denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            int numerator = r1._numerator * r2._denominator;
            int denominator = r1._denominator * r2._numerator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber r)
        {
            return new RationalNumber(-r._numerator, r._denominator);
        }

        public static bool operator ==(RationalNumber r1, RationalNumber r2)
        {
            return r1._numerator == r2._numerator && r1._denominator == r2._denominator;
        }

        public static bool operator !=(RationalNumber r1, RationalNumber r2)
        {
            return !(r1 == r2);
        }
    }
}
