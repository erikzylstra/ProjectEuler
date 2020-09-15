using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace CSharpSolutions.Problems
{
    /// <summary>
    ///The sum of the squares of the first ten natural numbers is 385
    ///The square of the sum of the first ten natural numbers is 3025
    ///Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025−385=2640.
    ///Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
    class Problem6
    {
        private static int Sum(IEnumerable<int> nums)
        {
            return nums.Aggregate(0, (acc, i) => acc + i);
        }

        private static int SumOfSquares(IEnumerable<int> nums)
        {
            var squares = nums.Select(i => i * i);
            return Sum(squares);
        }

        private static int SquareOfSum(IEnumerable<int> nums)
        {
            var sum = Sum(nums);
            return sum * sum;
        }

        ///Solution: 25164150
        public static int Solve()
        {
            var naturals = Enumerable.Range(1, 100);
            return SquareOfSum(naturals) - SumOfSquares(naturals);
        }
    }
}
