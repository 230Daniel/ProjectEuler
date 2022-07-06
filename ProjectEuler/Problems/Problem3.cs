namespace ProjectEuler.Problems;

public class Problem3 : Problem
{
    public Problem3() : base(3, "Largest prime factor") { }

    public override object Run()
    {
        var primeFactors = new List<long>();
        var factorStack = new Stack<long>();
        factorStack.Push(600851475143);

        while (factorStack.TryPop(out var factor))
        {
            if (TryFindFactorPair(factor, out var newFactorPair))
            {
                factorStack.Push(newFactorPair.Item1);
                factorStack.Push(newFactorPair.Item2);
            }
            else
            {
                primeFactors.Add(factor);
            }
        }

        Console.WriteLine($"Prime factors: {string.Join(", ", primeFactors)}");
        var largestPrimeFactor = primeFactors.Max();

        return largestPrimeFactor;
    }

    private static bool TryFindFactorPair(long input, out (long, long) factorPair)
    {
        var divisor = 2;
        while (divisor <= input / 2)
        {
            if (input % divisor == 0)
            {
                factorPair = (divisor, input / divisor);
                return true;
            }
            divisor += 1;
        }

        factorPair = default;
        return false;
    }
}
