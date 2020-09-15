using CSharpSolutions.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpSolutions.Problems
{
    /// <summary>
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// Find the sum of all the primes below two million.
    /// Solution: 142913828922
    /// </summary>
    class Problem10
    {
        private const int TwoMillion = 2000000;

        public static long Solve()
        {
            var primes = Sequences.Primes(TwoMillion);
            var longPrimes = primes.Select(p => Convert.ToInt64(p));
            return longPrimes.Aggregate(0L, (acc, p) => acc + p);
        }
    }
}
