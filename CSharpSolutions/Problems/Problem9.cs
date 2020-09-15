using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpSolutions.Problems
{
    /// <summary>
    ///There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    ///Find the product abc.
    ///Solution: 31875000
    /// </summary>
    class Problem9
    {
        public static int Solve()
        { //since c > a or b, we only need to look at a and b < 500
            var prod = 0;
            foreach (int a in Enumerable.Range(1, 500))
                foreach (int b in Enumerable.Range(1, a))
                {
                    var c = Math.Sqrt(a * a + b * b);
                    if (a + b + c == 1000)
                    {
                        prod = Convert.ToInt32(a * b * c);
                        return prod;
                    }
                }

            return prod;
        }
    }
}
