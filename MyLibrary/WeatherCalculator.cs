namespace MyLibrary;

public static class WeatherCalculator
{
    public static string DetermineSeason(DateOnly date)
    {
        int month = date.Month;

        // if (month >= 3 && month <= 5)
        // {
        //     return "Spring";
        // }

        // if (month >= 6 && month <= 8)
        // {
        //     return "Summer";
        // }

        // if (month >= 9 && month <= 11)
        // {
        //     return "Autumn";
        // }

        string season = month switch
        {
            3 or 4 or 5 => "Spring",
            6 or 7 or 8 => "Summer",
            9 or 10 or 11 => "Autumn",
            _ => "Winter"
        };

        return season;
    }
}