using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projecteuler_prob43
{
    class Program
    {
        static int[] prime = new int[] { 17, 13, 11, 7, 5, 3, 2, 1 };
        static List<int> DiscardedDigits = new List<int>();
        static List<Int64> PandigitalNumber = new List<Int64>();

        // The solution runs in 1 msec

        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
            s.Start();
            // since the 3 digit numbers that are divisible by 17 fall in the range of 102 and 986, we use only this range to loop
            // and increment the loop by 17 to get only those numbers that are divisble by 17.
            for (int i = 102; i <= 986; i = i + 17)
            {
                DiscardedDigits.Clear();
                if (IsDistinctDigit(i))
                {
                    StoreDigits(i);
                    int FirstTwoDigit = i / 10;
                    GetPandigitalNumber(FirstTwoDigit, 1, i.ToString());
                }
            }
            Int64 Sum = PandigitalNumber.ToArray().Sum();
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
        }

        static bool IsDistinctDigit(int number)
        {
            int[] used = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool ReturnVal = true;

            while (number != 0)
            {
                if (used[number % 10] == 1)
                {
                    ReturnVal = false;
                }
                used[number % 10] = 1;
                number = number / 10;
            }
            return ReturnVal;
        }

        static void StoreDigits(int number)
        {
            while (number != 0)
            {
                DiscardedDigits.Add(number % 10);
                number = number / 10;
            }
        }

        static void GetPandigitalNumber(int TwoDigitNumber, int index, string NumUntilNow)
        {
            for (int i = 0; i <= 9; i++)
            {
                if (!DiscardedDigits.Contains(i))
                {
                    string FormedNo = string.Concat(i.ToString(), TwoDigitNumber.ToString());
                    // this is needed since 01 is stored as 1 in integer and we need the 0 in front to form the next three digit number
                    if (TwoDigitNumber < 10)
                    {
                        FormedNo = i.ToString() + "0" + TwoDigitNumber.ToString();
                    }
                    if (int.Parse(FormedNo) % prime[index] == 0)
                    {
                        DiscardedDigits.Add(i);
                        NumUntilNow = i.ToString() + NumUntilNow;
                        if (index + 1 < prime.Length)
                        {
                            GetPandigitalNumber(int.Parse(FormedNo) / 10, index + 1, NumUntilNow);
                        }
                        else
                        {
                            PandigitalNumber.Add(Int64.Parse(NumUntilNow));
                        }
                        // This is needed to ensure that we are able to reconsider those digits by other prime numbers that could not result in
                        // a valid combination with the prime number in consideration. We also need to remove the last digit even if it formed a valid combination
                        // so that we can consider other digits with the same prime number. Say, i is 6 and 6153 gave us a vlid combinmation. Now, in order to check
                        // if 7153 is valid, we need to remove 6 and check with 7153.
                        DiscardedDigits.Remove(i);
                        // Since the last integer that we added cannot form a valid sequence we remove it from out formed number.
                        NumUntilNow = NumUntilNow.Remove(0, 1);
                    }
                }
            }
        }
    }
}