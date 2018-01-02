using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Time : IComparable<Time>
    {
        private int hour;
        private int minutes;
        private int seconds;

        public int Hour
        {
            get => hour;
            set
            {
                if (value >= 0 && value < 24)
                {
                    hour = value;
                }
            }
        }

        public int Minutes
        {
            get => minutes;
            set
            {
                if (value >= 0 && value < 60)
                {
                    minutes = value;
                }
            }
        }

        public int Seconds
        {
            get => seconds;
            set
            {
                if (value >= 0 && value < 60)
                {
                    seconds = value;
                }
            }
        }

        public Time(int hour = 0, int minutes = 0, int seconds = 0)
        {
            Hour = hour;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int CompareTo(Time other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var hourComparison = hour.CompareTo(other.hour);
            if (hourComparison != 0) return hourComparison;
            var minutesComparison = minutes.CompareTo(other.minutes);
            if (minutesComparison != 0) return minutesComparison;
            return seconds.CompareTo(other.seconds);
        }

        public Time addHours(int val)
        {
            return new Time((hour + val) % 24, Minutes, Seconds);
        }

        public Time addMinutes(int val)
        {
            int temp = Hour * 60 * 60 + (val + Minutes) * 60 + Seconds;
            return new Time((temp/3600)%24, (temp/60)%60, temp%60);
        }
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
