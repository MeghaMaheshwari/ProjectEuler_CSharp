using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace problem_76
{
    class Program
    {
        const int MaxValue = 99;
        const int TargetVal = 100;
        static int TotalWays = 0;

        static void Main(string[] args)
        {
            Stopwatch S = new Stopwatch();
            S.Start();
            for (int i = 1; i <= MaxValue; i++)
            {
                if (TargetVal % i == 0)
                {
                    TotalWays++;
                }
                for (int j = (TargetVal / i - 1); j >= 1; j--)
                {
                    int RemainingVal = TargetVal - (j * i);
                    if (RemainingVal < (i + 1))
                    {
                        continue;
                    }
                    GetWays(i + 1, RemainingVal);
                }
            }
            S.Stop();
            Console.WriteLine(S.ElapsedMilliseconds);
        }

        static void GetWays(int CurrentIndex, int ValToForm)
        {
            for (int j = CurrentIndex; j <= MaxValue; j++)
            {
                if (ValToForm < j)
                {
                    continue;
                }
                for (int k = (ValToForm / j); k >= 1; k--)
                {
                    int RemainVal = ValToForm - (k * j);
                    if (RemainVal == 0)
                    {
                        TotalWays++;
                    }
                    else
                    {
                        if (RemainVal < (j+1))
                        {
                            continue;
                        }
                        GetWays(j + 1, RemainVal);
                    }
                }
            }
        }
    }
}
