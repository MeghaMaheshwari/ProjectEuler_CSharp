using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace problem_31
{
    class Program
    {
        static int  TargetVal = 200;
        static int[] coins = new int[] {1, 2, 5, 10, 20, 50, 100, 200 };
        static int TotalWays = 0;
     
        static void Main(string[] args)
        {
            for (int i = 0; i < coins.Length; i++)
            {
                if (TargetVal % coins[i] == 0)
                {
                    TotalWays++;
                }
                for (int j = (TargetVal/coins[i]-1); j >= 1; j--)
                {
                    int RemainingVal = TargetVal - (j*coins[i]);
                    if(RemainingVal < coins[i+1])
                    {
                        continue;
                    }
                    GetWays(i+1, RemainingVal);
                }
            }
        }

        static void GetWays(int CurrentIndex, int ValToForm)
        {
            for (int j = CurrentIndex; j < coins.Length; j++)
            {
                if (ValToForm < coins[j])
                {
                    continue;
                }
                for (int k = (ValToForm / coins[j]); k >= 1; k--)
                {
                    int RemainVal = ValToForm - (k * coins[j]);
                    if (RemainVal == 0)
                    {
                        TotalWays++;
                    }
                    else
                    {
                        if (RemainVal < coins[j + 1])
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
