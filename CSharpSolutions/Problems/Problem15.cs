using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace CSharpSolutions.Problems
{
    /*Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
    How many such routes are there through a 20×20 grid?
    Solution: 137846528820*/
    class Problem15
    {
        private static BigInteger Factorial(int n)
        {
            return Enumerable.Range(1, n).Aggregate((BigInteger)1, (acc, n) => acc * n);
        }

        private static BigInteger Square(BigInteger n)
        {
            return n * n;
        }

        //the number of ways to order n rights and n downs is (2n)!/((n!)^2).
        public static BigInteger Solve()
        {
            int n = 20;
            return Factorial(2 * n) / Square(Factorial(n));
        }
    }
}
