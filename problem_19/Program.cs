using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler_problem19
{
    class Program
    {
        const int NoOfDaysInNonLeapYear = 365;

        const int NoOfDaysInLeapYear = 366;

        const int NoOfDaysInFourWeeks = 28;

        const int NoOfDaysInFebLeapYear = 29;

        static string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        // the first entry has been mde 0 to sync the array index with the month numbers
        static int[] DaysInMonth = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        // look up table to store the number of Sundays based on the starting day of the month for a non leap year
        static Dictionary<string, int> StartDayVsSundaysNonleap = new Dictionary<string, int>();

        // look up table to store the number of Sundays based on the starting day of the month for a leap year
        static Dictionary<string, int> StartDayVsSundayleap = new Dictionary<string, int>();

        //Jan 1st 1901 was a tuesday
        static int StartDayOfTheYear = 1;
        static bool IsLeapYear = false;

        static void Main(string[] args)
        {
            int TotalNumberofSundays = 0;

            // Store the number of Sundays if the starting day of the year is a Mon, Tues,Wed etc for a leap year and non leap year
            for (int i = 0; i < days.Length; i++)
            {
                int StartDay = i;
                StartDayVsSundaysNonleap.Add(days[i], GetNumberOfSundays(i, false));
                StartDayVsSundayleap.Add(days[i], GetNumberOfSundays(i, true));
            }
            for (int i = 1901; i <= 2000; i++)
            {
                IsLeapYear = false;
                if ((i % 4 == 0) || ((i % 4 == 0) && (i % 400 == 0)))
                {
                    IsLeapYear = true;
                }
                int SundaysInThisYear = (IsLeapYear) ? StartDayVsSundayleap[days[StartDayOfTheYear]] : StartDayVsSundaysNonleap[days[StartDayOfTheYear]];
                TotalNumberofSundays = TotalNumberofSundays + SundaysInThisYear;
                int NumberOfDaysInTheYear = (IsLeapYear) ? NoOfDaysInLeapYear : NoOfDaysInNonLeapYear;
                StartDayOfTheYear = (StartDayOfTheYear + NumberOfDaysInTheYear) % 7;
            }
        }

        static int GetNumberOfSundays(int StartDay, bool IsleapYear)
        {
            int TotalSundays = 0;
            for (int i = 1; i < DaysInMonth.Length; i++)
            {
                if (days[StartDay] == "Sunday")
                {
                    TotalSundays++;
                }
                // each month will have 4 complete weeks and some remaining days depending upon the number of days. Based on the Start day this remaining
                //days will determine if the start day of the next month was a Sunday. 
                int NumberOfDaysinMonth = (i == 2 && IsleapYear) ? NoOfDaysInFebLeapYear : DaysInMonth[i];
                int NumberOfNonWeekDays = NumberOfDaysinMonth - NoOfDaysInFourWeeks;
                StartDay = (StartDay + NumberOfNonWeekDays) % 7;
            }
            return TotalSundays;
        }
    }
}
