using System.Diagnostics;

namespace ProjectEuler.Problems;

public class Problem33 : Problem
{
    public Problem33() : base(33, "Digit cancelling fractions") { }

    public override object Run()
    {
        var numProduct = 1;
        var denProduct = 1;

        for (var den = 10; den < 100; den++)
        {
            for (var num = 10; num < den; num++)
            {
                if (num == 49 && den == 98) Debugger.Break();

                if (num % 10 == 0 && den % 10 == 0) continue;

                var newNum = num;
                var newDen = den;

                if(!TryDigitCancel(ref newNum, ref newDen)) continue;

                if(newNum == 0 || newDen == 0) continue;

                var numMultiplier = (decimal) num / newNum;
                var denMultiplier = (decimal) den / newDen;
                if(numMultiplier != denMultiplier) continue;

                Console.WriteLine($"{num}/{den} --> {newNum}/{newDen}");
                numProduct *= num;
                denProduct *= den;
            }
        }

        Console.WriteLine($"Final product {numProduct}/{denProduct}");

        for (var divisor = denProduct; divisor > 1; divisor--)
        {
            if (numProduct % divisor == 0 && denProduct % divisor == 0)
            {
                numProduct /= divisor;
                denProduct /= divisor;
                break;
            }
        }

        Console.WriteLine($"Simplifies to {numProduct}/{denProduct}");
        return denProduct;
    }

    private static bool TryDigitCancel(ref int a, ref int b)
    {
        var aOne = a / 10;
        var aTwo = a % 10;
        var bOne = b / 10;
        var bTwo = b % 10;

        if (aOne == bOne)
        {
            a = aTwo;
            b = bTwo;
            return true;
        }

        if (aOne == bTwo)
        {
            a = aTwo;
            b = bOne;
            return true;
        }

        if (aTwo == bOne)
        {
            a = aOne;
            b = bTwo;
            return true;
        }

        if (aTwo == bTwo)
        {
            a = aOne;
            b = bOne;
            return true;
        }

        return false;
    }
}
