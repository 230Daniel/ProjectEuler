namespace ProjectEuler.Problems;

public class Problem5 : Problem
{
    public Problem5() : base(5, "Smallest multiple") { }

    public override object Run()
    {
        var number = 20;
        while (!TestNumber(number))
        {
            number += 20;
        }

        return number;
    }

    private static bool TestNumber(int number)
    {
        for (var i = 20; i > 1; i--)
        {
            if (number % i != 0) return false;
        }

        return true;
    }
}
