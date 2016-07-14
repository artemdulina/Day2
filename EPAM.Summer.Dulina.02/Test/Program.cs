using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputationalMethods;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randValues = new Random();
            int[] testValues = new int[1000000];
            for (int i = 0; i < testValues.Length; i++)
            {
                testValues[i] = randValues.Next();
            }
            //
            //Root of degree N
            //
            double n = 2;
            double value = 2;
            double answer = Algebra.RootOfDegreeN(value, n);
            double standartAnswer = Math.Pow(value, 1 / n);
            Console.WriteLine("n = {1}, value = {2}, Result of RootOfDegreeN: {0}", answer, n, value);
            Console.WriteLine("n = {1}, value = {2}, Result of Math.Pow: {0}", standartAnswer, n, value);
            n = 56;
            value = 400;
            answer = Algebra.RootOfDegreeN(value, n);
            standartAnswer = Math.Pow(value, 1 / n);
            Console.WriteLine("n = {1}, value = {2}, Result of RootOfDegreeN: {0}", answer, n, value);
            Console.WriteLine("n = {1}, value = {2}, Result of Math.Pow: {0}", standartAnswer, n, value);
            //
            //Evklid GCD
            //
            TimeSpan time;
            Console.WriteLine("\nEvklid GCD \n");
            Console.WriteLine(Algebra.GreatestCommonDivision(1071, 462, out time));
            Console.WriteLine("Time in milliseconds: {0}", time.TotalMilliseconds);

            Console.WriteLine(Algebra.GreatestCommonDivision(-5, 10));
            Console.WriteLine(Algebra.GreatestCommonDivision(0, 6));
            Console.WriteLine(Algebra.GreatestCommonDivision(-585, 81, -189));

            Console.WriteLine(Algebra.GreatestCommonDivision(out time, testValues));
            Console.WriteLine("Time in milliseconds: {0}", time.TotalMilliseconds);
            //
            //Binary GCD
            //
            Console.WriteLine("\nBinary GCD \n");
            Console.WriteLine(Algebra.GreatestCommonDivisionBinary(1071, 462, out time));
            Console.WriteLine("Time in milliseconds: {0}", time.TotalMilliseconds);

            Console.WriteLine(Algebra.GreatestCommonDivisionBinary(-5, 10));
            Console.WriteLine(Algebra.GreatestCommonDivisionBinary(0, 6));
            Console.WriteLine(Algebra.GreatestCommonDivisionBinary(-585, 81, -189));

            Console.WriteLine(Algebra.GreatestCommonDivisionBinary(out time, testValues));
            Console.WriteLine("Time in milliseconds: {0}", time.TotalMilliseconds);


            n = 5000;
            value = 100;
            Console.WriteLine(Math.Pow(value, 1 / n));
            Console.WriteLine(Algebra.RootOfDegreeN(value, n, 0.0001));
            // Console.WriteLine(double.PositiveInfinity/double.PositiveInfinity);
        }
    }
}
