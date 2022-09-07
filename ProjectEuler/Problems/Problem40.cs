namespace ProjectEuler.Problems;

public class Problem40 : Problem
{
    public Problem40() : base(40, "Champernowne's constant") { }

    public override object Run()
    {
        var concatenatedPositiveIntegers = ConcatenatedPositiveIntegers(1_000_000);
        var place = 1;
        var product = 1;
        foreach (var decimalPlace in (concatenatedPositiveIntegers))
        {
            if (Math.Log10(place) % 1 == 0)
            {
                Console.WriteLine($"place {place} value {decimalPlace}");
                product *= decimalPlace;
            }
            place++;
        }
        return product;
    }

    private static IEnumerable<int> ConcatenatedPositiveIntegers(int max)
    {
        var i = 0;
        var number = 1;
        while (i <= max)
        {
            foreach (var character in number.ToString())
            {
                yield return character - '0';
                i++;
                if (i > max) break;
            }
            number++;
        }
    }
}
