using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CSharpSolutions.Problems
{
    /*
    2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    What is the sum of the digits of the number 2^1000?
    */
    class Problem16
    { 
        //Solution: 1366
        public static int Solve()
        {
            var power = BigInteger.Pow(2, 1000);
            var digits = power.ToString().Select(d => char.GetNumericValue(d));
            return (int)digits.Aggregate(0.0, (acc, d) => acc + d);
        }
    }
}
