namespace ProjectEuler.Problems;

public class Problem41 : Problem
{
    public Problem41() : base(41, "Pandigital prime") { }

    public override object Run()
    {
        var largestPandigitalPrime = 0;
        var previousPrimes = new List<int>();
        var digits = new int[9];

        for (var i = 2; i < 1_000_000_000; i++)
        {
            var maxDivisor = Math.Sqrt(i);

            var isPrime = true;
            foreach (var previousPrime in previousPrimes)
            {
                if (previousPrime > maxDivisor) break;
                if (i % previousPrime == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if(!isPrime) continue;
            previousPrimes.Add(i);

            var iStr = i.ToString();
            for (var j = 0; j < iStr.Length; j++)
                digits[j] = iStr[j] - '0';

            var isPandigital = true;
            for(var j = 1; j <= iStr.Length; j++)
            {
                var digitCount = 0;
                foreach (var digit in digits)
                    if (digit == j) digitCount++;

                if (digitCount != 1)
                {
                    isPandigital = false;
                    break;
                }
            }

            if (isPandigital)
            {
                Console.WriteLine($"New largest pandigital prime found: {i}");
                largestPandigitalPrime = i;
            }
        }

        return largestPandigitalPrime;
    }
}
