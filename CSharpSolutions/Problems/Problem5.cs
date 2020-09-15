using CSharpSolutions.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace CSharpSolutions.Problems
{
    /// <summary>
    ///2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    ///What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    ///Solution: 232792560
    /// </summary>
    class Problem5
    {
        private const int RangeMax = 20;

        public static string Solve()
        {
            var range = Enumerable.Range(1, RangeMax).ToList();

            for (int i = 0; i < range.Count; i++)
                for (int j = i + 1; j < range.Count; j++)
                    if (range[j] % range[i] == 0)
                        range[j] = range[j] / range[i];

            return range.Aggregate(1, (acc, r) => acc * r).ToString();
        }
    }
}
