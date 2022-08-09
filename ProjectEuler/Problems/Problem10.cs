namespace ProjectEuler.Problems;

public class Problem10 : Problem
{
    public Problem10() : base(10, "Summation of primes") { }

    public override object Run()
    {
        long total = 2;
        var primesSoFar = new List<int>(200_000) { 2 };
        for (var i = 3; i < 2_000_000; i += 2)
        {
            if (IsPrime(i, primesSoFar))
            {
                total += i;
                primesSoFar.Add(i);
            }
        }

        Console.WriteLine($"Found {primesSoFar.Count} primes below 2 million");
        return total;
    }

    private static bool IsPrime(int input, List<int> primesBelowInput)
    {
        var maximumDivisor = (input / 2) + 1;
        foreach (var prime in primesBelowInput)
        {
            if (prime > maximumDivisor) break;
            if (input % prime == 0) return false;
        }

        return true;
    }
}
