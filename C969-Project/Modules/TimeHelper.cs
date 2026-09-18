namespace C969_Project.Modules;

public static class TimeHelper
{
    public static DateTime ToLocal(DateTime utcTime)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.Local);
    }
}