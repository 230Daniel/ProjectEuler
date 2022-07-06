using System.Numerics;

namespace ProjectEuler.Problems;

public class Problem16 : Problem
{
    public Problem16() : base(16, "Power digit sum") { }

    public override object Run()
    {
        var twoToOneThousand = new BigInteger(2);
        for (var i = 0; i < 999; i++)
        {
            twoToOneThousand *= 2;
        }
        var stringTwoToOneThousand = twoToOneThousand.ToString();

        var total = 0;
        for (var i = 0; i < stringTwoToOneThousand.Length; i++)
        {
            total += int.Parse(stringTwoToOneThousand.Substring(i, 1));
        }

        return total;
    }
}
