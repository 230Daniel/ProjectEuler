namespace ProjectEuler.Problems;

public class Problem30 : InfiniteProblem
{
    public Problem30() : base(30, "Digit fifth powers") { }

    protected override object RunUntilCancelled(CancellationToken cancellationToken)
    {
        var i = 1;
        var total = 0;

        while (!cancellationToken.IsCancellationRequested)
        {
            var remaining = i;
            var nonZeroDigets = 0;
            var sum = 0;
            while (remaining > 0)
            {
                var diget = remaining % 10;
                remaining /= 10;

                if (diget != 0)
                {
                    nonZeroDigets++;
                    sum += Power(diget, 5);
                    if (sum > i) break;
                }
            }

            if (sum == i && nonZeroDigets > 1)
            {
                total += i;
                Console.WriteLine($"Found {i}, new total {total}");
            }

            i++;
        }

        return total;
    }

    private static int Power(int a, int b)
    {
        var result = a;

        for(var i = 1; i < b; i++)
        {
            result *= a;
        }

        return result;
    }
}
