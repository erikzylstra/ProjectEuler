using CSharpSolutions.Tools;
using System.Linq;

namespace CSharpSolutions.Problems
{
    /// <summary>
    ///The prime factors of 13195 are 5, 7, 13 and 29.
    ///What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    public class Problem3
    {
        private const long num = 600851475143;

        /// Solution: 6857
        public static string Solve()
        {
            var factors = Factor.Primes(num);
            return factors.Max().ToString();
        }
    }
}
