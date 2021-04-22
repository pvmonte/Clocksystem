using System;

namespace UgglaGames.DeviceTimerSystem
{
    [Serializable]
    public class Timer
    {
        DateTime startTime = new DateTime();
        DateTime goalTime = new DateTime();
        TimerInterval interval = new TimerInterval();

        public Timer() { }

        public Timer(int hours, int minutes, int seconds)
        {
            this.interval = new TimerInterval(hours, minutes, seconds);
        }

        public Timer(DateTime startTime, TimerInterval interval)
        {
            this.startTime = startTime;
            this.interval = interval;
            this.goalTime = startTime.AddTimerInterval(interval);
        }

        public Timer(DateTime startTime, DateTime goalTime, TimerInterval interval)
        {
            this.startTime = startTime;
            this.goalTime = goalTime;
            this.interval = interval;
        }

        /// <summary>
        /// Returns the time left to zero in timer
        /// </summary>
        /// <returns>Time left to zero</returns>
        public TimeSpan GetTimeLeft()
        {
            TimeSpan timeLeft = goalTime - DateTime.Now;

            if (timeLeft.TotalSeconds < 0)
                return new TimeSpan(0, 0, 0);

            return timeLeft;
        }

        /// <summary>
        /// Start the timer
        /// </summary>
        public void StartTimer()
        {
            startTime = DateTime.Now;
            goalTime = startTime.AddTimerInterval(interval);
        }
    }
}
