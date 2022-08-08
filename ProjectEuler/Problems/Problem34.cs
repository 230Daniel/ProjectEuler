namespace ProjectEuler.Problems;

public class Problem34 : InfiniteProblem
{
    public Problem34() : base(34, "Digit factorials") { }

    protected override object RunUntilCancelled(CancellationToken cancellationToken)
    {
        var factorials = new []
        {
            Factorial(0),
            Factorial(1),
            Factorial(2),
            Factorial(3),
            Factorial(4),
            Factorial(5),
            Factorial(6),
            Factorial(7),
            Factorial(8),
            Factorial(9),
        };

        ulong total = 0;
        ulong i = 9;
        while (!cancellationToken.IsCancellationRequested)
        {
            i++;

            var remainder = i;
            ulong sum = 0;
            while (remainder != 0)
            {
                var digit = remainder % 10;
                remainder /= 10;
                sum += factorials[digit];
                if (sum > i) break;
            }

            if(sum != i) continue;

            total += i;
            Console.WriteLine($"Found new digit factorial number {i}, new total: {total}");
        }

        return total;
    }

    private static ulong Factorial(ulong input)
    {
        if (input == 0) return 1;

        var result = input;

        for (var i = input - 1; i > 0; i--)
            result *= i;

        return result;
    }
}
