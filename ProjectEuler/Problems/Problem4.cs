namespace ProjectEuler.Problems;

public class Problem4 : Problem
{
    public Problem4() : base(4, "Largest palindrome product") { }

    public override object Run()
    {
        var largest = 0;
        for (var i = 100; i < 1000; i++)
        {
            for (var j = 100; j < 1000; j++)
            {
                var product = i * j;
                if (product <= largest) continue;

                var productString = product.ToString();
                var start = productString.Substring(0, productString.Length / 2);
                var palindromicEnd = Reverse(start);

                if (productString.EndsWith(palindromicEnd))
                {
                    largest = product;
                    Console.WriteLine($"Found new largest: {i} * {j} = {productString}");
                }
            }
        }

        return largest;
    }

    private static string Reverse(string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
