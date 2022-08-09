namespace ProjectEuler.Problems;

public class Problem37 : Problem
{
    public Problem37() : base(37, "Truncatable primes") { }

    public override object Run()
    {
        var total = 0;

        var digits = new List<int>();
        var found = 0;
        var i = 0;
        while (found < 11)
        {
            i++;
            if (!IsPrime(i)) continue;

            digits.Clear();
            var remainder = i;
            while (remainder != 0)
            {
                digits.Insert(0, remainder % 10);
                remainder /= 10;
            }

            if (digits.Count == 1) continue;

            var allTruncationsPrime = true;
            for (var rightPtr = 0; rightPtr < digits.Count && allTruncationsPrime; rightPtr++)
            {
                var truncated = ReconstructInteger(digits, 0, rightPtr);
                if (!IsPrime(truncated))
                {
                    allTruncationsPrime = false;
                    // [00]00 this [] part isn't prime, so we can increment to the next number which changes this section
                    // In practice increment to one less, because i is incremented again at the start of the loop
                    // Turns out this optimisation is unnecessary, I fixed whatever the issue was accidentally along the way
                    // It's cool though so I'll keep it in
                    var increment = (int) Math.Pow(10, digits.Count - 1 - rightPtr);
                    i = truncated * increment + increment - 1;
                }
            }

            for (var leftPtr = 1; leftPtr < digits.Count && allTruncationsPrime; leftPtr++)
            {
                var truncated = ReconstructInteger(digits, leftPtr, digits.Count - 1);
                if (!IsPrime(truncated))
                    allTruncationsPrime = false;
            }

            if (!allTruncationsPrime) continue;

            found++;
            total += i;
            Console.WriteLine($"{i}");
        }

        return total;
    }

    private static int ReconstructInteger(List<int> digits, int leftPtr, int rightPtr)
    {
        var placeValue = (int) Math.Pow(10, rightPtr - leftPtr);
        var number = 0;

        for (var i = leftPtr; i <= rightPtr; i++)
        {
            number += digits[i] * placeValue;
            placeValue /= 10;
        }

        return number;
    }

    // wikipedia optimised primality test
    private static bool IsPrime(int input)
    {
        if (input is 2 or 3)
            return true;

        if (input <= 1 || input % 2 == 0 || input % 3 == 0)
            return false;

        for (var i = 5; i * i <= input; i += 6)
        {
            if (input % i == 0 || input % (i + 2) == 0)
                return false;
        }

        return true;
    }
}
