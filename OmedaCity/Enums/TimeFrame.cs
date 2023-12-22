namespace OmedaCity.Enums;

public enum TimeFrame
{
    All,
    M3,
    M2,
    M1,
    W3,
    W2,
    W1,
    D1
}

public static class TimePeriodExtensions
{
    public static string ToStringValue(this TimeFrame timePeriod)
    {
        return timePeriod switch
        {
            TimeFrame.All => "ALL",
            TimeFrame.M3 => "3M",
            TimeFrame.M2 => "2M",
            TimeFrame.M1 => "1M",
            TimeFrame.W3 => "3W",
            TimeFrame.W2 => "2W",
            TimeFrame.W1 => "1W",
            TimeFrame.D1 => "1D",
            _ => throw new ArgumentOutOfRangeException(nameof(timePeriod), timePeriod, null)
        };
    }
}