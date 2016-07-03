using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ComputationalMethods
{
    public static class Algebra
    {
        /// <summary>
        /// Returns root of degree n from a value. Algorithm is based on Newton method. 
        /// </summary>
        /// <param name="value">A double-precision floating-point number to be raised to a power.</param>
        /// <param name="n">A double-precision floating-point number that specifies a power.</param>
        /// <param name="accuracy">Computing accuracy</param>
        /// <returns>The number value raised to the power 1/n.</returns>   
        /// <exception cref="ArgumentException">Negative value or accuracy.</exception>
        public static double RootOfDegreeN(double value, double n, double accuracy = 0.00001)
        {
            if (accuracy < 0)
                throw new ArgumentException("Accuracy can't be a negative value");
            if (value < 0)
                throw new ArgumentException("Value can't be negative");
            if (n == 0)
                return double.PositiveInfinity;
            if (value == 0)
                return 0;
            double currentX = 1; //initial approximation
            double previousX = currentX;
            do
            {
                previousX = currentX;
                currentX = ((n - 1) * previousX + value / Math.Pow(previousX, n - 1)) / n;
            }
            while (Math.Abs(currentX - previousX) > accuracy);
            return currentX;
        }

        /// <summary>
        /// Returns greatest common division of two numbers. Algorithm is based on Evklid method. 
        /// </summary>
        /// <returns>Greatest common division of two numbers.</returns>   
        /// <exception cref="ArgumentException">Both zero values</exception>
        public static int GreatestCommonDivision(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException("Greatest common division of pair(0,0) is not exist");
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a = a % b;
                else
                    b = b % a;
            }
            return a == 0 ? b : a;
        }

        /// <summary>
        /// Returns greatest common division of two numbers. Algorithm is based on Evklid method. 
        /// </summary>
        /// <param name="time">TimeSpan object which represents a running time</param>
        /// <returns>Greatest common division of two numbers.</returns>   
        /// <exception cref="ArgumentException">Both zero values</exception>
        public static int GreatestCommonDivision(int a, int b, out TimeSpan time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = GreatestCommonDivision(a, b);
            timer.Stop();
            time = timer.Elapsed;
            return result;
        }

        /// <summary>
        /// Returns greatest common division of list of values. Algorithm is based on Evklid method. 
        /// </summary>
        /// <returns>Greatest common division of list of numbers.</returns>   
        /// <exception cref="ArgumentException">Number of values less than 2</exception>
        public static int GreatestCommonDivision(params int[] values)
        {
            if (values.Length < 2)
                throw new ArgumentException("Number of parameters must be greater than 2");
            int gcd = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                gcd = GreatestCommonDivision(values[i], gcd);
            }
            return gcd;
        }

        /// <summary>
        /// Returns greatest common division of list of values. Algorithm is based on Evklid method. 
        /// </summary>
        /// <param name="time">TimeSpan object which represents a running time</param>
        /// <returns>Greatest common division of list of numbers.</returns>   
        /// <exception cref="ArgumentException">Number of values less than 2</exception>
        public static int GreatestCommonDivision(out TimeSpan time, params int[] values)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = GreatestCommonDivision(values);
            timer.Stop();
            time = timer.Elapsed;
            return result;
        }

        /// <summary>
        /// Returns greatest common division of two numbers. Algorithm is based on Stain method. 
        /// </summary>
        /// <returns>Greatest common division of two numbers.</returns>   
        /// <exception cref="ArgumentException">Both zero values</exception>
        public static int GreatestCommonDivisionBinary(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException("Greatest common division of pair(0,0) is not exist");
            a = Math.Abs(a);
            b = Math.Abs(b);
            int multiplier = 1;
            while (true)
            {
                if (a == 0 || b == 0) return (a + b) * multiplier;
                if (a == b) return a * multiplier;
                if (a == 1 || b == 1) return multiplier;
                if ((a & 1) == 0 && (b & 1) == 0)
                {
                    multiplier = multiplier << 1;
                    a = a >> 1;
                    b = b >> 1;
                }
                else if ((a & 1) == 0)
                    a = a >> 1;
                else if ((b & 1) == 0)
                    b = b >> 1;
                else if (b > a)
                    b = (b - a) >> 1;
                else
                    a = (a - b) >> 1;
            }
        }

        /// <summary>
        /// Returns greatest common division of two numbers. Algorithm is based on Stain method. 
        /// </summary>
        /// <param name="time">TimeSpan object which represents a running time</param>
        /// <returns>Greatest common division of two numbers.</returns>   
        /// <exception cref="ArgumentException">Both zero values</exception>
        public static int GreatestCommonDivisionBinary(int a, int b, out TimeSpan time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = GreatestCommonDivisionBinary(a, b);
            timer.Stop();
            time = timer.Elapsed;
            return result;
        }

        /// <summary>
        /// Returns greatest common division of list of values. Algorithm is based on Stain method. 
        /// </summary>
        /// <returns>Greatest common division of list of numbers.</returns>   
        /// <exception cref="ArgumentException">Number of values less than 2</exception>
        public static int GreatestCommonDivisionBinary(params int[] values)
        {
            if (values.Length < 2)
                throw new ArgumentException("Number of parameters must be greater than 2");
            int gcd = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                gcd = GreatestCommonDivisionBinary(values[i], gcd);
            }
            return gcd;
        }

        /// <summary>
        /// Returns greatest common division of list of values. Algorithm is based on Stain method. 
        /// </summary>
        /// <param name="time">TimeSpan object which represents a running time</param>
        /// <returns>Greatest common division of list of numbers.</returns>   
        /// <exception cref="ArgumentException">Number of values less than 2</exception>
        public static int GreatestCommonDivisionBinary(out TimeSpan time, params int[] values)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = GreatestCommonDivisionBinary(values);
            timer.Stop();
            time = timer.Elapsed;
            return result;
        }

    }
}
