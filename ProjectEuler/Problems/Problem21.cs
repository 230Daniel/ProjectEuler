namespace ProjectEuler.Problems;

public class Problem21 : Problem
{
    public Problem21() : base(21, "Amicable numbers") { }

    public override object Run()
    {
        var amicableNumbers = new List<int>();

        for (var i = 1; i < 10000; i++)
        {
            if(amicableNumbers.Contains(i)) continue;

            var sumOfDivisors = SumOfDivisors(i);
            if(sumOfDivisors == i) continue;

            if (SumOfDivisors(sumOfDivisors) == i)
            {
                amicableNumbers.Add(i);
                if(!amicableNumbers.Contains(sumOfDivisors))
                    amicableNumbers.Add(sumOfDivisors);
            }
        }

        Console.WriteLine($"Found {amicableNumbers.Count} amicable numbers below 10000");
        return amicableNumbers.Sum();
    }

    private static int SumOfDivisors(int number)
    {
        var total = 1;

        for (var potentialDivisor = 2; potentialDivisor < number; potentialDivisor++)
        {
            if (number % potentialDivisor == 0)
                total += potentialDivisor;
        }

        return total;
    }
}
