namespace ProjectEuler.Problems;

public class Problem38 : Problem
{
    public Problem38() : base(38, "Pandigital multiples") { }

    public override object Run()
    {
        var largest = 0;
        var digits = new int[9];
        for (var i = 2; i < 100000 / 2; i++)
        {
            var multiplier = 0;
            var totalDigits = 0;
            var isValid = true;
            Array.Clear(digits);

            while (totalDigits < 9 && isValid)
            {
                multiplier++;
                var product = i * multiplier;
                var productStartPtr = totalDigits;
                var digitsInProduct = 0;

                while (product != 0 && totalDigits < 9)
                {
                    var digit = product % 10;

                    if (digit == 0 || digits.Contains(digit))
                    {
                        isValid = false;
                        break;
                    }

                    digits[totalDigits] = digit;
                    product /= 10;
                    totalDigits++;
                    digitsInProduct++;
                }

                if (product != 0) isValid = false;

                // The method above puts digits in the wrong way around, so reverse the section of the array that was just modified
                Array.Reverse(digits, productStartPtr, digitsInProduct);
            }
            if(!isValid || multiplier < 2) continue;

            var concatenatedProduct = ReconstructInteger(digits);
            if (concatenatedProduct > largest)
            {
                largest = concatenatedProduct;
                Console.WriteLine($"Found new largest: {largest} via {i} * (1, ..., {multiplier})");
            }
        }

        return largest;
    }

    private static int ReconstructInteger(int[] digits)
    {
        var placeValue = (int) Math.Pow(10, digits.Length - 1);
        var number = 0;

        for (var i = 0; i < digits.Length; i++)
        {
            number += digits[i] * placeValue;
            placeValue /= 10;
        }

        return number;
    }
}
