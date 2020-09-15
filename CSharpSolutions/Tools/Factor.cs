using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace CSharpSolutions.Tools
{
    public class Factor
    {
        //mathematically guaranteed to be prime
        private static long SmallestDivisor(long n)
        {   //n must be >= 2
            int div = 2;

            while (n % div != 0)
                div++;

            return div;
        }

        public static IEnumerable<long> Primes(long n)
        {
            if (n <= 1L) { yield return n; }

            while (n > 1)
            {
                var div = SmallestDivisor(n);
                n /= div;
                yield return div;
            }
        }

        public static IEnumerable<long> Primes(int n)
        {
            var l = Convert.ToInt64(n);
            return Primes(l);
        }

        //public static List<int> Divisors(int n)
        //{
            
        //    var divisors = new List<int>();
        //    divisors.Add(1);

        //    var primeDivisors = Primes(n);

        //    foreach (int prime in primeDivisors)
        //    {
        //        foreach (int div in divisors)
        //        {
                    
        //        }
        //    }

        //    yield return n;
        //}
    }
}
