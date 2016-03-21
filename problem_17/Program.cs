using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numtowords
{
    class Program
    {
        static string[] Onedigits = new string[20] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven",
                                                "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};

        static string[] Tendigits = new string[8] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        const string thousand = "onethousand";

        const string hundredand = "hundredand";


        static void Main(string[] args)
        {
            int SumUntilNine = 0;
            int SumFromTenToNineteen = 0;
            int SumOfTens = 0;
            int HundredSum = 0;

            SumUntilNine = GetTotalNumber(Onedigits, 1, 10);
            SumFromTenToNineteen = GetTotalNumber(Onedigits, 10, 20);
            SumOfTens = GetTotalNumber(Tendigits, 0, 8);
            // 20 to 29, 30 to 39, hence each of twenty, thirty occur ten times.
            // One to Nine occur a total of 8 times from 21 to 99.
            int SumFromTwentyToNinetyNine = SumOfTens * 10 + SumUntilNine * 8;
            int total = SumUntilNine + SumFromTenToNineteen + SumFromTwentyToNinetyNine;

            for (int i = 1; i <= 9; i++)
            {
                string val = Onedigits[i] + hundredand;
                // subract 3 as onehundred, twohundred, threehundred etc do not contain and.
                // Since we have the sum from one to ninetynine already, the only extra things
                // are onehundredand, twohundredand , threehundredand etc that will occur 100 times each.
                HundredSum = (HundredSum + val.Length * 100 + total) - 3;
            }

            // add the only onethousand
            total = total + HundredSum + thousand.Length;

        }

        static int GetTotalNumber(string[] array, int Startindex, int EndIndex)
        {
            int sum = 0;
            for (int i = Startindex; i < EndIndex; i++)
            {
                sum = sum + array[i].Length;
            }
            return sum;
        }
    }
}