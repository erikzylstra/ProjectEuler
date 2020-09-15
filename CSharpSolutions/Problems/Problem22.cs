using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSharpSolutions.Problems
{
    /*
    Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

    For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

    What is the total of all the name scores in the file?

    Solution: 871198282
    */

    public class Problem22
    {
        private static int LetterScore(char letter)
        {
            if (letter == '\"') return 0;
            else return letter - 64; //leverage unicode value
        }

        private static int NameScore(string name, int index)
        {
            var letters = name.ToCharArray();
            var score = 0;
            foreach (var letter in letters)
                score += LetterScore(letter);
            score *= index;
            return score;
        }

        public static int Solve()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("p022_names.txt"));
            string[] names;

            using (var reader = new StreamReader(assembly.GetManifestResourceStream(resourceName)))
            {
                names = reader.ReadToEnd().Split(",");
            }

            Array.Sort(names);

            var totalScore = 0;
            for (int i = 0; i < names.Length; i++)
                totalScore += NameScore(names[i], i + 1);
            return totalScore;
        }
    }
}
