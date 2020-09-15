using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace CSharpSolutions.Problems
{
    /*How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
     Solution: 171*/
    class Problem19
    {
        private static int CountSundaysOnFirst(int year)
        {
            int count = 0;
            for (int month = 1; month <= 12; month++)
            {
                var firstOfMonth = new DateTime(year, month, 1);
                if (firstOfMonth.DayOfWeek == DayOfWeek.Sunday)
                    count++;
            }
            return count;
        }
        public static int Solve()
        {
            var count = 0;
            for (int year = 1901; year <= 2000; year++)
                count += CountSundaysOnFirst(year);
            return count;
        }
    }
}
