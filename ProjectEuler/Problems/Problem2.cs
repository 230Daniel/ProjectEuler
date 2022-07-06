namespace ProjectEuler.Problems;

public class Problem2 : Problem
{
    public Problem2() : base(2, "Even Fibonacci numbers") { }

    public override object Run()
    {
        var a = 1;
        var b = 2;
        var total = 0;

        while (a < 4_000_000)
        {
            var next = a + b;
            a = b;
            b = next;
            if (a % 2 == 0)
                total += a;
        }

        return total;
    }
}
