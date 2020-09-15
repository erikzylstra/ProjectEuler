using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CSharpSolutions.Problems
{
    /*Work out the first ten digits of the sum of the following one-hundred 50-digit numbers. (contained in text file)
     Solution: 5537376230*/
    class Problem13
    {
        //use of the BigInteger class avoids the size limitations of Int32, Int64 etc.
        public static string Solve()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("p013_numbers.txt"));

            List<BigInteger> nums = new List<BigInteger>();
            using (var reader = new StreamReader(assembly.GetManifestResourceStream(resourceName)))
            {
                while (!reader.EndOfStream)
                    nums.Add(BigInteger.Parse(reader.ReadLine()));
            }

            var sum = nums.Aggregate((BigInteger)0, (acc, n) => acc + n);
            return sum.ToString().Substring(0, 10);
        }
    }
}
