using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Using_Datetime_Format
{
    class Program
    {
        static void Main(string[] args)
        {
            // TimeZone();

            // substringDate();

            S();
        }

        public static void DatetimeFormat()
        {
            //string formatString = "yyyyMMddHHmmss";
            //string sample = "20100611221912";

            string formatString = "yyMMddHHmmss";
            string sample = "201031161612";
            DateTime dt = DateTime.ParseExact(sample, formatString, null);

            Console.Write("Datetime : " + dt);
            Console.ReadKey();
        }

        public static void UniversalTime()
        {
            DateTimeOffset localTime, otherTime, universalTime;

            // Define local time in local time zone
            localTime = new DateTimeOffset(new DateTime(20, 10, 31, 16, 16, 12));
            Console.WriteLine("Local time: {0}", localTime);
            Console.WriteLine();

            // Convert local time to offset 0 and assign to otherTime
            otherTime = localTime.ToOffset(TimeSpan.Zero);
            Console.WriteLine("Other time: {0}", otherTime);
            Console.WriteLine("{0} = {1}: {2}",
                              localTime, otherTime,
                              localTime.Equals(otherTime));
            Console.WriteLine("{0} exactly equals {1}: {2}",
                              localTime, otherTime,
                              localTime.EqualsExact(otherTime));
            Console.WriteLine();

            // Convert other time to UTC
            universalTime = localTime.ToUniversalTime();
            Console.WriteLine("Universal time: {0}", universalTime);
            Console.WriteLine("{0} = {1}: {2}",
                              otherTime, universalTime,
                              universalTime.Equals(otherTime));
            Console.WriteLine("{0} exactly equals {1}: {2}",
                              otherTime, universalTime,
                              universalTime.EqualsExact(otherTime));
            Console.WriteLine();
            // The example produces the following output to the console:
            //    Local time: 6/15/2007 12:00:00 PM -07:00
            //
            //    Other time: 6/15/2007 7:00:00 PM +00:00
            //    6/15/2007 12:00:00 PM -07:00 = 6/15/2007 7:00:00 PM +00:00: True
            //    6/15/2007 12:00:00 PM -07:00 exactly equals 6/15/2007 7:00:00 PM +00:00: False
            //
            //    Universal time: 6/15/2007 7:00:00 PM +00:00
            //    6/15/2007 7:00:00 PM +00:00 = 6/15/2007 7:00:00 PM +00:00: True
            //    6/15/2007 7:00:00 PM +00:00 exactly equals 6/15/2007 7:00:00 PM +00:00: True


            Console.ReadKey();
        }

        public static void TimeZoneExm01()
        {
            DateTime localDateTime, univDateTime;

            Console.WriteLine("Enter a date and time.");
            string strDateTime = Console.ReadLine();

            try
            {
                localDateTime = DateTime.Parse(strDateTime);
                univDateTime = localDateTime.ToUniversalTime();

                Console.WriteLine("{0} local time is {1} universal time.",
                                    localDateTime,
                                        univDateTime);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format.");
                return;
            }

            Console.WriteLine("Enter a date and time in universal time.");
            strDateTime = Console.ReadLine();

            try
            {
                univDateTime = DateTime.Parse(strDateTime);
                localDateTime = univDateTime.ToLocalTime();

                Console.WriteLine("{0} universal time is {1} local time.",
                                         univDateTime,
                                         localDateTime);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format.");
                return;
            }
        }

        public static void TimeZoneExm02()
        {
            DateTime dateNow = DateTime.Now;
            Console.WriteLine("The date and time are {0} UTC.", TimeZoneInfo.ConvertTimeToUtc(dateNow));
            Console.ReadKey();

        }

        public static void TimeZoneExm03()
        {
            DateTime hwTime = new DateTime(2020, 10, 29, 3, 16, 12);

            try
            {
                TimeZoneInfo hwZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
                Console.WriteLine("{0} {1} is {2} local time.",
                        hwTime,
                        hwZone.IsDaylightSavingTime(hwTime) ? hwZone.DaylightName : hwZone.StandardName,
                        TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local));

                Console.ReadKey();
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("The registry does not define the Hawaiian Standard Time zone.");
            }
            catch (InvalidTimeZoneException)
            {
                Console.WriteLine("Registry data on the Hawaiian Standard Time zone has been corrupted.");
            }
        }

        public static void TimeZone()
        { 
            DateTime arTime = new DateTime(2020, 10, 29, 3, 16, 12);
            TimeZoneInfo arZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            Console.WriteLine("{0} {1} is {2} local time.",
                        arTime,
                        arZone.IsDaylightSavingTime(arTime) ? arZone.DaylightName : arZone.StandardName,
                        TimeZoneInfo.ConvertTime(arTime, arZone, TimeZoneInfo.Local));

            Console.WriteLine(arTime);
            Console.WriteLine(arZone.IsDaylightSavingTime(arTime) ? arZone.DaylightName : arZone.StandardName);
            Console.WriteLine(TimeZoneInfo.ConvertTime(arTime, arZone, TimeZoneInfo.Local));
            Console.ReadKey();
        }

        public static void substringDate()
        {
            string[] info = { "Name: Felica Walker", "Title: Mz.", "Age: 47", "Location: Paris", "Gender: F" };
            int found = 0;

            Console.WriteLine("The initial values in the array are:");

            foreach (string s in info)
                Console.WriteLine(s);

            Console.WriteLine("\nWe want to retrieve only the key information. That is:");
            foreach (string s in info)
            {
                found = s.IndexOf(": ");
                Console.WriteLine("   {0}", s.Substring(found + 2));
            }

            Console.ReadKey();
        }

        public static void S()
        {
            string filename = "MONUSIN.P704201029151611.ENC";
            string date = filename.Substring(12, 12);

            Console.WriteLine(date);

            string formatString = "yyMMddHHmmss";
            string sample = date;
            DateTime dt = DateTime.ParseExact(sample, formatString, null);

            Console.WriteLine(dt);

            DateTime arTime = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            TimeZoneInfo arZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            Console.WriteLine(TimeZoneInfo.ConvertTime(arTime, arZone, TimeZoneInfo.Local));

            Console.ReadKey();
        }

        //Link : 

        //    https://docs.microsoft.com/en-us/dotnet/api/system.datetimeoffset.touniversaltime?view=netcore-3.1
        //    https://stackoverflow.com/questions/7908343/list-of-timezone-ids-for-use-with-findtimezonebyid-in-c
        //    https://docs.microsoft.com/es-es/dotnet/standard/datetime/converting-between-time-zones


    }
}
