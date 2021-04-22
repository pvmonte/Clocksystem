using System;

namespace UgglaGames.DeviceTimerSystem
{
    [Serializable]
    public class TimerInterval
    {
        public int hours { get; }
        public int minutes { get; }
        public int seconds { get; }

        public TimerInterval()
        {
            this.hours = 0;
            this.minutes = 0;
            this.seconds = 0;
        }

        public TimerInterval(int seconds)
        {
            this.hours = (int)Math.Floor((decimal)(seconds / 60 * 60)); ;
            this.minutes = (int)Math.Floor((decimal)(seconds / 60));
            this.seconds = seconds;
        }

        public TimerInterval(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
    }
}
