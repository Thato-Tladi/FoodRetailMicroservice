public class CurrentTimeDto
{
    private static string[] SplitDate(string date)
    {
        return date.Split("|");
    }

    public static int GetDay(string date)
    {
        return int.Parse(SplitDate(date)[2]);
    }

    public static int GetMonth(string date)
    {
        return int.Parse(SplitDate(date)[1]);
    }

    public static int GetYear(string date)
    {
        return int.Parse(SplitDate(date)[0]);
    }
}