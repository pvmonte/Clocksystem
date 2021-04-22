using System;

namespace UgglaGames.DeviceTimerSystem
{
    public static class DateTimeExtensions
    {
        public static DateTime AddTimerInterval(this DateTime dateTime, TimerInterval interval)
        {
            dateTime = dateTime.AddHours(interval.hours);
            dateTime = dateTime.AddMinutes(interval.minutes);
            dateTime = dateTime.AddSeconds(interval.seconds);
            return dateTime;
        }
    }
}
