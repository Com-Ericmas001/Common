using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Ericmas001.Common
{
    public static class DateTimeUtil
    {
        public static DateTimeOffset EasternNow()
        {
            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo utcZone = TimeZoneInfo.Utc;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTime(timeUtc, utcZone, easternZone);
        }
        public static DateTimeOffset SetEastern(this DateTime date)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTime(date, easternZone, easternZone);
        }
    }
}
