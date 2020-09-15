using CSharpSolutions.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace CSharpSolutions.Problems
{
    /// <summary>
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    ///What is the 10 001st prime number?
    ///Solution: 104743
    /// </summary>
    class Problem7
    {
        //use the prime number theorem to estimate the size of the sieve we will need to get 10000 primes.
        //the prime number theorem says that the number of primes less than n, p(n), is ~ n/ln(n)
        //the ratio p(n) to n/ln(n) is always < 1.3, but we will double our estimate for simplicity

        private static int PrimeCounter (int n) { return Convert.ToInt32(n / Math.Log(n)); }

        public static int Solve()
        {
            var DesiredPrime = 10001;

            var n = 2;
            while (PrimeCounter(n) < 2 * DesiredPrime)
            {
                n *= 2;
            }

            var primes = Sequences.Primes(n);
            return primes.ElementAt(DesiredPrime - 1);
        }
    }
}
