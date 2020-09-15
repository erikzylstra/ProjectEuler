using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSolutions.Problems
{
    /// <summary>
    ///If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    ///Find the sum of all the multiples of 3 or 5 below 1000.
    ///Solution: 233168
    /// </summary>
    public class Problem1
    {
        private static int SumOfMultiples (int i)
        {
            var multiple = i;
            var sum = 0;

            while (multiple < 1000)
            {
                sum += multiple;
                multiple += i;
            }

            return sum;
        }

        public static string Solve()
        {
            var solution = SumOfMultiples(3) + SumOfMultiples(5) - SumOfMultiples(15);
            return solution.ToString();
        }
    }
}
