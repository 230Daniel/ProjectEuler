namespace ProjectEuler.Problems;

public class Problem26 : Problem
{
    public Problem26() : base(26, "Reciprocal cycles") { }

    public override object Run()
    {
        var longestCycleLength = -1;
        var longestCycleLengthDenominator = -1;

        for (var i = 2; i < 1000; i++)
        {
            var cycleLength = GetCycleLength(i);
            if (cycleLength > longestCycleLength)
            {
                longestCycleLength = cycleLength;
                longestCycleLengthDenominator = i;
            }
        }

        return longestCycleLengthDenominator;
    }

    // Basically implements short division, and when we get the same result and the same carry we have found a cycle
    private static int GetCycleLength(int denominator)
    {
        var currentPlace = 1;
        var results = new List<(int, int)>();

        var place = 0;
        while (true)
        {
            var result = currentPlace / denominator;

            var carry = currentPlace % denominator;
            currentPlace = carry * 10;

            if (place < 0)
            {
                var indexOfSameResult = results.IndexOf((result, carry));
                if (indexOfSameResult != -1)
                {
                    return (-place) - indexOfSameResult;
                }
                results.Add((result, carry));
            }

            place--;

            if (currentPlace == 0) return 0;
        }
    }
}
