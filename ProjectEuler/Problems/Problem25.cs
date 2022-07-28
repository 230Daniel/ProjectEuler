using System.Numerics;

namespace ProjectEuler.Problems;

public class Problem25 : Problem
{
    public Problem25() : base(25, "1000-digit Fibonacci number") { }

    public override object Run()
    {
        var a = new BigInteger(1);
        var b = new BigInteger(1);
        var index = 1;

        while (true)
        {
            var c = a + b;
            a = b;
            b = c;

            index++;
            if (b.ToString().Length >= 1000)
                return index + 1;
        }
    }
}
