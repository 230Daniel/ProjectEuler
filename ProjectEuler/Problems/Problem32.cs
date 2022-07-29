namespace ProjectEuler.Problems;

public class Problem32 : InfiniteProblem
{
    public Problem32() : base(32, "Pandigital products") { }

    protected override object RunUntilCancelled(CancellationToken cancellationToken)
    {
        var digits = new List<int>(9);
        var total = 0;
        var i = 0;

        while(!cancellationToken.IsCancellationRequested)
        {
            i++;
            digits.Clear();

            if (!TryAddDigits(digits, i)) continue;

            for (var divisor = 2; divisor <= i / 2; divisor++)
            {
                if (i % divisor != 0) continue;
                var counterpart = i / divisor;
                if(!TryAddDigits(digits, divisor, counterpart, true)) continue;

                total += i;
                Console.WriteLine($"Found new pandigital product: {counterpart} * {divisor} = {i}, New total: {total}");
                break;
            }
        }

        return total;
    }

    private static bool TryAddDigits(List<int> digits, int number, int number2 = -1, bool requireNine = false)
    {
        var startPtr = digits.Count;
        var success = true;

        for (var i = 0; i < 2 && success; i++)
        {
            var remainder = i == 0 ? number : number2;
            if(remainder == -1) continue;

            while (remainder > 0 && success)
            {
                var digit = remainder % 10;

                if (digit == 0 || digits.Contains(digit))
                    success = false;
                else
                {
                    digits.Add(digit);
                    remainder /= 10;
                }
            }
        }

        if ((!success && startPtr != digits.Count) || (requireNine && digits.Count != 9))
        {
            digits.RemoveRange(startPtr, digits.Count - startPtr);
            return false;
        }

        return success;
    }
}
