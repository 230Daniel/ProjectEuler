namespace ProjectEuler.Problems;

public class Problem35 : Problem
{
    public Problem35() : base(35, "Circular primes") { }

    public override object Run()
    {
        Console.WriteLine("Finding primes below 1 million...");
        var primes = GetPrimesBelowOneMillion();
        var count = 0;

        var digits = new int[7];
        foreach (var prime in primes)
        {
            var remainder = prime;

            var digitCount = 0;
            while (remainder != 0)
            {
                digits[digitCount] = remainder % 10;
                remainder /= 10;
                digitCount++;
            }

            var digitsEndPtr = digitCount - 1;

            var allRotationsArePrime = true;
            for (var i = 1; i < digitCount; i++)
            {
                Rotate(digits, digitsEndPtr);
                var newNumber = 0;
                var placeValue = 1;

                for (var j = 0; j <= digitCount; j++)
                {
                    newNumber += digits[j] * placeValue;
                    placeValue *= 10;
                }

                if (Array.BinarySearch(primes, newNumber) < 0)
                {
                    allRotationsArePrime = false;
                    break;
                }
            }

            if (allRotationsArePrime)
            {
                count++;
                Console.WriteLine($"Found new circular prime {prime}, new count {count}");
            }
        }

        return count;
    }

    private static void Rotate(int[] digits, int endPtr)
    {
        var temp = digits[endPtr];
        for (var i = endPtr; i > 0; i--)
        {
            digits[i] = digits[i - 1];
        }
        digits[0] = temp;
    }

    private static int[] GetPrimesBelowOneMillion()
    {
        var primes = new List<int>();
        for (var i = 1; i < 1_000_000; i++)
        {
            if (IsPrime(i, primes))
                primes.Add(i);
        }

        return primes.ToArray();
    }

    private static bool IsPrime(int input, List<int> primesBelowInput)
    {
        if (input < 2) return false;
        var minimumDivisor = (input / 2) + 1;

        for (var i = 0; i < primesBelowInput.Count; i++)
        {
            var prime = primesBelowInput[i];
            if (prime > minimumDivisor) break;
            if (input % prime == 0) return false;
        }

        return true;
    }
}
