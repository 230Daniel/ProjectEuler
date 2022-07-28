namespace ProjectEuler.Problems;

public class Problem19 : Problem
{

    public Problem19() : base(19, "Counting Sundays") { }

    public override object Run()
    {
        var dayOfWeek = 1;  // 0 to 6 Monday to Sunday
        var day = 1;        // 1-indexed
        var month = 1;      // 1-indexed
        var year = 1901;

        var daysInMonth = DaysInMonth(month, year);

        var sundays = 0;

        while (year <= 2000)
        {
            if (dayOfWeek == 6 && day == 1) sundays++;

            dayOfWeek++;
            if (dayOfWeek == 7) dayOfWeek = 0;

            day++;
            if (day > daysInMonth)
            {
                day = 1;
                month++;
                if (month == 13)
                {
                    month = 1;
                    year++;
                }
                daysInMonth = DaysInMonth(month, year);
            }
        }

        return sundays;
    }

    private static int DaysInMonth(int month, int year)
    {
        switch (month)
        {
            case 2:
                return IsLeapYear(year) ? 29 : 28;

            case 4:
            case 6:
            case 9:
            case 11:
                return 30;

            default:
                return 31;
        }
    }

    private static bool IsLeapYear(int year)
    {
        if (year % 4 == 0)
        {
            if (year % 100 == 0)
            {
                if (year % 400 == 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        return false;
    }
}
