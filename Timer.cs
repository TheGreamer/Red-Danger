using System;

public class Timer
{
    private static DateTime startOfDayTimeHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 06, 00, 00, DateTimeKind.Utc);
    private static DateTime startOfNightTimeHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 00, 00, DateTimeKind.Utc);
    private static DateTime currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTimeKind.Utc);

    public static bool IsDayTime { get; } = currentTime > startOfDayTimeHour && currentTime < startOfNightTimeHour;
}