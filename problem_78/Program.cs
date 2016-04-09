using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace problem78_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch s = new Stopwatch();
            s.Start();
            int smallestval = 0;
            int target = 100000;
            int[] ways = new int[target + 1];
            ways[0] = 1;

            for (int i = 1; i < target; i++)
            {
                for (int j = i; j <= target; j++)
                {
                    ways[j] = (ways[j] + ways[j - i]) % 1000000;
                }
                if (ways[i] == 0)
                {
                    smallestval = i;
                    break;
                }
            }
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
        }      
    }
}
