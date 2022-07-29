using System.Numerics;

namespace ProjectEuler.Problems;

public class Problem29 : Problem
{
    public Problem29() : base(29, "Distinct powers") { }

    public override object Run()
    {
        var results = new List<BigInteger>();

        for (var a = 2; a <= 100; a++)
        {
            for (var b = 2; b <= 100; b++)
            {
                var result = Power(a, b);
                var position = results.BinarySearch(result);
                if (position < 0)
                {
                    var largerPosition = ~position;
                    results.Insert(largerPosition, result);
                }
            }
        }

        return results.Count;
    }

    private static BigInteger Power(int a, int b)
    {
        var result = new BigInteger(a);

        for(var i = 1; i < b; i++)
        {
            result *= a;
        }

        return result;
    }
}
