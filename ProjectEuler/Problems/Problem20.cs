using System.Numerics;

namespace ProjectEuler.Problems;

public class Problem20 : Problem
{
    public Problem20() : base(20, "Factorial digit sum") { }

    public override object Run()
    {
        var result = new BigInteger(100);
        for (var i = 99; i > 0; i--)
        {
            result *= i;
        }

        Console.WriteLine($"100! = {result}");

        var total = 0;
        foreach (var digetChar in result.ToString())
        {
            // Smart solution to find difference between representations of 0 and the number in the character set
            // Courtesy of Stack Overflow, of course. questions/239103
            total += digetChar - '0';
        }

        return total;
    }
}
