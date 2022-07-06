namespace ProjectEuler.Problems;

public class Problem14 : Problem
{
    public Problem14() : base(14, "Longest Collatz sequence") { }

    public override object Run()
    {
        var greatestLength = 0;
        var greatestLengthStartingNumber = -1;

        for (var i = 1; i < 1_000_000; i++)
        {
            var length = GetLengthOfSequence(i);
            if (length > greatestLength)
            {
                Console.WriteLine($"Found new greatest length: {length} with starting number {i}");
                greatestLength = length;
                greatestLengthStartingNumber = i;
            }
        }

        return greatestLengthStartingNumber;
    }

    private static int GetLengthOfSequence(long startingNumber)
    {
        var term = startingNumber;
        var length = 1;

        while (term != 1)
        {
            if (term % 2 == 0)
                term /= 2;
            else
                term = term * 3 + 1;
            length += 1;
        }

        return length;
    }
}
