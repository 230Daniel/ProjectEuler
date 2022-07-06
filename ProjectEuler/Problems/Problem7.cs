namespace ProjectEuler.Problems;

public class Problem7 : Problem
{
    public Problem7() : base(7, "10001st prime") { }

    public override object Run()
    {
        var primeCount = 0;
        var i = 1;

        while (primeCount < 10_001)
        {
            i += 1;
            if (IsPrime(i))
                primeCount += 1;
        }

        return i;
    }

    private static bool IsPrime(int input)
    {
        if (input <= 1) return false;

        for (var i = 2; i < input / 2 + 1; i++)
        {
            if (input % i == 0) return false;
        }

        return true;
    }
}
