using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpSolutions.Tools
{
    public class Sequences
    {
        //Implementation of Sieve of Eratosthenes
        public static IEnumerable<int> Primes(int max)
        {
            var array = new BitArray(max + 1, true);
            var last = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(max)));
            for (int i = 2; i <= last; i++)
            {
                if (array[i] == true)
                {
                    for (int p = 2 * i; p <= max; p += i)
                        array.Set(p, false);
                }
            }

            for (int i = 2; i <= max; i++)
                if (array.Get(i))
                    yield return i;
        }
    }
}
