using System;

namespace task4
{
    class Date
    {
        private DateTime date;

        public Date(DateTime date)
        {
            this.date = date;
        }

        public Date(int day, int month, int year)
        {
            this.date = new DateTime(year, month, day);
        }

        ~Date()
        {
            Console.WriteLine("called");
        }

        public override string ToString()
        {
            return date.ToString("d");
        }

        public static Date operator ++(Date d)
        {
            return new Date(d.date.AddDays(1));
        }

        public static Date operator --(Date d)
        {
            return new Date(d.date.AddDays(-1));
        }

        public static Date operator +(Date d, int day)
        {
            return new Date(d.date.AddDays(day));
        }

        public static Date operator -(Date d, int day)
        {
            return new Date(d.date.AddDays(-day));
        }
    }
}