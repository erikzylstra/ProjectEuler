using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CSharpSolutions.Problems
{
    /*n! means n × (n − 1) × ... × 3 × 2 × 1
    For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
    Find the sum of the digits in the number 100!*/
    class Problem20
    {
        private static BigInteger Factorial(int n)
        {
            return Enumerable.Range(1, n).Aggregate((BigInteger)1, (acc, i) => acc * i);
        }

        //Solution: 648
        public static int Solve()
        {
            var digits = Factorial(100).ToString().Select(c => char.GetNumericValue(c));
            return (int)digits.Aggregate(0.0, (acc, d) => acc + d);
        }
    }
}
