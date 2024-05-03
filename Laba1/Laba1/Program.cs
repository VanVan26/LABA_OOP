using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating rational numbers...");
            RationalNumber rational1 = new RationalNumber(1, 2);
            RationalNumber rational2 = new RationalNumber(1, 2);
            Console.WriteLine("Rational number 1: " + rational1);
            Console.WriteLine("Rational number 2: " + rational2);
            RationalNumber sum = rational1 + rational2;
            RationalNumber difference = rational1 - rational2;
            RationalNumber product = rational1 * rational2;
            RationalNumber quotient = rational1 / rational2;
            RationalNumber negation = -rational1;
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Difference: " + difference);
            Console.WriteLine("Product: " + product);
            Console.WriteLine("Quotient: " + quotient);
            Console.WriteLine("Negation of rational number 1: " + negation);
            Console.WriteLine("\nComparing rational numbers...");
            Console.WriteLine("Is rational1 equal to rational2? " + (rational1 == rational2));
            Console.WriteLine("Is rational1 not equal to rational2? " + (rational1 != rational2));
            RationalNumber userInput = RationalNumber.InputRationalNumber();
            Console.WriteLine("Entered rational number: " + userInput);
            Console.ReadKey();
        }
    }
}

