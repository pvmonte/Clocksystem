using System;

/// <summary>
/// Formats a time/clock Display to hh:mm:ss
/// </summary>
public struct ClockDisplayFormatter
{
    /// <summary>
    /// Formats TimeSpan in time/clock display
    /// </summary>
    /// <param name="timeSpane"></param>
    /// <returns>time display string in hh:mm:ss format</returns>
    public string FormatClockDisplay(TimeSpan timeSpane)
    {        
        return FormatClockDisplay(timeSpane.Hours, timeSpane.Minutes, timeSpane.Seconds);
    }

    /// <summary>
    /// Formats a time/clock display by given hour, minutes and seconds
    /// </summary>
    /// <param name="hours"></param>
    /// <param name="minutes"></param>
    /// <param name="seconds"></param>
    /// <returns>time display string in hh:mm:ss format</returns>
    string FormatClockDisplay(int hours, int minutes, int seconds)
    {
        string labelHour = FormatClockPiece(hours);
        string labelMinutes = FormatClockPiece(minutes);
        string labelSeconds = FormatClockPiece(seconds);
        return $"{labelHour}:{labelMinutes}:{labelSeconds}";
    }

    /// <summary>
    /// Formats a seconds display
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns>seconds string in ss format</returns>
    string FormatClockDisplaySecondsOnly(int seconds)
    {        
        string labelSeconds = FormatClockPiece(seconds);
        return $"{labelSeconds}";
    }

    /// <summary>
    /// Formats a seconds display
    /// </summary>
    /// <param name="minutes"></param>
    /// <param name="seconds"></param>
    /// <returns>time display in mm:ss format</returns>
    string FormatClockDisplayMinutesAndSecondsOnly(int minutes, int seconds)
    {
        string labelMinutes = FormatClockPiece(minutes);
        string labelSeconds = FormatClockPiece(seconds);
        return $"{labelMinutes}:{labelSeconds}";
    }

    /// <summary>
    /// Format a timer piece by the given value
    /// </summary>
    /// <param name="timePiece"></param>
    /// <returns>piece of timer in nn format, like nn:nn:nn</returns>
    string FormatClockPiece(int timePiece)
    {
        return timePiece < 10 ? $"0{timePiece}" : timePiece.ToString();
    }
}