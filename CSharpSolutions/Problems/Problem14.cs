using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpSolutions.Problems
{
    /*The following iterative sequence is defined for the set of positive integers:

    n → n/2 (n is even)
    n → 3n + 1 (n is odd)

    Using the rule above and starting with 13, we generate the following sequence:
    13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

    It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
    Which starting number, under one million, produces the longest chain?
    NOTE: Once the chain starts the terms are allowed to go above one million.

    Solution: 837799*/
    class Problem14
    {
        private static Dictionary<long, int> lengths = new Dictionary<long, int>() { { 1, 1 } };

        private static long Iterate(long n)
        {
            if (n % 2 == 0)
                return n / 2;
            else
                return 3 * n + 1;
        }

        private static void CalculateChainLength(long n)
        {
            int counter = 1;
            long iter = n;

            while (iter != 1)
            {
                iter = Iterate(iter);
                if (lengths.ContainsKey(iter))
                {
                    counter += lengths[iter];
                    lengths.Add(n, counter);
                    return;
                }
                else
                    counter++;
            }
        }

        public static int Solve()
        {
            int largestChain = 1;
            foreach (int n in Enumerable.Range(2, 999999))
            {
                CalculateChainLength(n);
                if (lengths[n] > lengths[largestChain])
                    largestChain = n;
            }
            return largestChain;
        }
    }
}
