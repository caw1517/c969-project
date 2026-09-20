namespace C969_Project.Modules;

public static class TimeHelper
{
    
    private static readonly TimeZoneInfo EasternZone =
        TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    
    public static DateTime ToUtc(DateTime local)
    {
        var localTime = DateTime.SpecifyKind(local, DateTimeKind.Unspecified);

        if (TimeZoneInfo.Local.IsInvalidTime(localTime))
        {
            throw new ArgumentException(
                "The selected local time does not exist because of a daylight saving time change.",
                nameof(local));
        }

        return TimeZoneInfo.ConvertTimeToUtc(localTime, TimeZoneInfo.Local);
    }
    
    public static DateTime ToLocal(DateTime utcTime)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.Local);
    }
    
    public static DateTime ToEastern(DateTime utcTime)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(utcTime, EasternZone);
    }
}