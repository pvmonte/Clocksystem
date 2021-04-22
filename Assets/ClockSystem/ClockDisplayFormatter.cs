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
    /// <returns>hh:mm:ss</returns>
    public string FormatClockDisplay(TimeSpan timeSpane)
    {        
        return FormatClockDisplay(timeSpane.Hours, timeSpane.Minutes, timeSpane.Seconds);
    }

    string FormatClockDisplay(int hours, int minutes, int seconds)
    {
        string labelHour = FormatClockPiece(hours);
        string labelMinutes = FormatClockPiece(minutes);
        string labelSeconds = FormatClockPiece(seconds);
        return $"{labelHour}:{labelMinutes}:{labelSeconds}";
    }

    string FormatClockDisplaySecondsOnly(int seconds)
    {        
        string labelSeconds = FormatClockPiece(seconds);
        return $"{labelSeconds}";
    }

    string FormatClockDisplayMinutesAndSecondsOnly(int minutes, int seconds)
    {
        string labelMinutes = FormatClockPiece(minutes);
        string labelSeconds = FormatClockPiece(seconds);
        return $"{labelMinutes}:{labelSeconds}";
    }

    string FormatClockPiece(int timePiece)
    {
        return timePiece < 10 ? $"0{timePiece}" : timePiece.ToString();
    }
}