namespace ProjectEuler.Problems;

public class Problem27 : Problem
{
    private List<int> _knownPrimes;

    public Problem27() : base(27, "Quadratic primes")
    {
        _knownPrimes = new();
    }

    public override object Run()
    {
        var greatestConsecutivePrimes = -1;
        var productOfCoefficients = -1;

        for (var a = -999; a < 1000; a++)
        {
            for (var b = -999; b < 1000; b++)
            {
                var termNum = 1;
                var result = termNum * termNum + a * termNum + b;
                var consecutivePrimes = 0;

                while (IsPrime(result))
                {
                    consecutivePrimes++;
                    termNum++;
                    result = termNum * termNum + a * termNum + b;
                }

                if (consecutivePrimes > greatestConsecutivePrimes)
                {
                    greatestConsecutivePrimes = consecutivePrimes;
                    productOfCoefficients = a * b;
                    Console.WriteLine($"Found new best expression with {greatestConsecutivePrimes} consecutive primes: n^2 + {a} + {b}");
                }
            }
        }

        return productOfCoefficients;
    }

    private bool IsPrime(int input)
    {
        if (input <= 1) return false;
        if (_knownPrimes.Contains(input)) return true;

        for (var i = 2; i < input / 2 + 1; i++)
        {
            if (input % i == 0)
                return false;
        }

        _knownPrimes.Add(input);
        return true;
    }
}
