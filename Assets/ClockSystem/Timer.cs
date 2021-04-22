using System;

namespace UgglaGames.DeviceTimerSystem
{
    [Serializable]
    public class Timer
    {
        DateTime startTime = new DateTime();
        DateTime goalTime = new DateTime();
        int intervalInSeconds;

        public Timer() { }

        public Timer(int seconds)
        {
            this.intervalInSeconds = seconds;
            this.goalTime = startTime.AddSeconds(intervalInSeconds);
        }

        public Timer(DateTime startTime, int interval)
        {
            this.startTime = startTime;
            this.intervalInSeconds = interval;
            this.goalTime = startTime.AddSeconds(interval);
        }

        public Timer(DateTime startTime, DateTime goalTime, int interval)
        {
            this.startTime = startTime;
            this.goalTime = goalTime;
            this.intervalInSeconds = interval;
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
            goalTime = startTime.AddSeconds(intervalInSeconds);
        }
    }
}
