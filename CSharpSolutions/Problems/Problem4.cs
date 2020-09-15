using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace CSharpSolutions.Problems
{
    /// <summary>
    ///A palindromic number reads the same both ways.The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    ///Find the largest palindrome made from the product of two 3-digit numbers.
    ///Solution: 906609
    /// </summary>
    public class Problem4
    {
        //products of two 3 digit numbers have 5 or 6 digits
        private static bool IsPalindrome (int p)
        {
            var s = p.ToString();
            if (s.Length == 5)
            {
                return s[0] == s[4] && s[1] == s[3];
            }
            else
                return s[0] == s[5] && s[1] == s[4] && s[2] == s[3];
        }

        private static IEnumerable<int> Products
        {
            get
            {
                for (int i  = 100; i < 1000; i++)
                    for (int j = 100; j < i; j++)
                        yield return i * j;
            }
        }

        public static string Solve()
        {
            var palindromes = Products.Where(p => IsPalindrome(p));
            return palindromes.Max().ToString();
        }
    }
}
