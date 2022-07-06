namespace ProjectEuler.Problems;

public class Problem1 : Problem
{
    public Problem1() : base(1, "Multiples of 3 or 5") { }

    public override object Run()
    {
        var total = 0;
        for (var i = 0; i < 1000; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
                total += i;
        }

        return total;
    }
}
