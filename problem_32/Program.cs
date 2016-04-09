using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace problem32
{
    class Program
    {


        static List<int> PandigitalProd = new List<int>();
        static List<int> DiscardedDigits = new List<int>();

        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch s = new Stopwatch();
            s.Start();
            for (int i = 1; i < 99; i++)
            {
                DiscardedDigits.Clear();
                if (IsDistinctDigit(i))
                {
                    if (NotUsedDigits(i))
                    {
                        for (int j = 123; j <= 9876; j++)
                        {
                            if (IsDistinctDigit(j))
                            {
                                if (NotUsedDigits(j))
                                {
                                    int prod = i * j;

                                    if (prod.ToString().Length == 4)
                                    {
                                        if (IsDistinctDigit(prod))
                                        {
                                            if (NotUsedDigits(prod))
                                            {
                                                int total = i.ToString().Length + j.ToString().Length + prod.ToString().Length;
                                                if (total == 9)
                                                {
                                                    PandigitalProd.Add(prod);
                                                }
                                                else
                                                {
                                                    DiscardValue(prod);
                                                    DiscardValue(j);
                                                    NotUsedDigits(i);
                                                }
                                            }
                                            else
                                            {
                                                DiscardValue(prod);
                                                DiscardValue(j);
                                                NotUsedDigits(i);
                                            }
                                        }
                                        else
                                        {
                                            DiscardValue(j);
                                            NotUsedDigits(i);
                                        }

                                    }
                                    else
                                    {
                                        DiscardValue(j);
                                        NotUsedDigits(i);
                                    }
                                }
                                else
                                {
                                    DiscardValue(j);
                                    NotUsedDigits(i);
                                }
                            }
                        }
                    }
                }
            }
            int Sum = PandigitalProd.Distinct().Sum();
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);

        }

        static bool IsDistinctDigit(int number)
        {
            int[] used = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool ReturnVal = true;

            while (number != 0)
            {
                // we need pandigital numbers only from 1 to 9, so zero should be ignored
                if ((used[number % 10] == 1) || (number % 10 == 0))
                {
                    ReturnVal = false;
                }
                used[number % 10] = 1;
                number = number / 10;
            }
            return ReturnVal;
        }

        static bool NotUsedDigits(int number)
        {
            bool ReturnVal = true;
            while (number != 0)
            {
                if (!DiscardedDigits.Contains(number % 10))
                {
                    DiscardedDigits.Add(number % 10);                  
                }
                else
                {
                    ReturnVal = false;                   
                }
                number = number / 10;
            }
            return ReturnVal;
        }

        static void DiscardValue(int number)
        {
            while (number != 0)
            {
                if (number % 10 == 0)
                {                    
                    continue;
                }
                if (DiscardedDigits.Contains(number % 10))
                {
                    DiscardedDigits.Remove(number % 10);                 
                }
                number = number / 10;               
            }            
        }       

    }
}
