namespace ProjectEuler.Problems;

public class Problem17 : Problem
{
    public Problem17() : base(17, "Number letter counts") { }

    public override object Run()
    {
        var total = 0;

        for (var i = 1; i <= 1000; i++)
        {
            var result = IntegerToString(i);
            Console.WriteLine($"{i} --> {result}");
            total += result.Length;
        }

        return total;
    }

    private static Dictionary<int, string> _representations = new()
    {
        { 1, "one" },
        { 2, "two" },
        { 3, "three" },
        { 4, "four" },
        { 5, "five" },
        { 6, "six" },
        { 7, "seven" },
        { 8, "eight" },
        { 9, "nine" },
        { 10, "ten" },
        { 11, "eleven" },
        { 12, "twelve" },
        { 13, "thirteen" },
        { 14, "fourteen" },
        { 15, "fifteen" },
        { 16, "sixteen" },
        { 17, "seventeen" },
        { 18, "eighteen" },
        { 19, "nineteen" },
        { 20, "twenty" },
        { 30, "thirty" },
        { 40, "forty" },
        { 50, "fifty" },
        { 60, "sixty" },
        { 70, "seventy" },
        { 80, "eighty" },
        { 90, "ninety" }
    };

    private static string IntegerToString(int input)
    {
        var inputStr = input.ToString();
        var output = "";

        if (inputStr.Length == 4)
        {
            output += $"{_representations[GetDidget(inputStr, 0)]}thousand";
            inputStr = inputStr.Substring(1);
        }
        if (inputStr.Length == 3)
        {
            var hundredsDidget = GetDidget(inputStr, 0);
            if (hundredsDidget != 0)
            {
                output += $"{_representations[GetDidget(inputStr, 0)]}hundred";
            }
            inputStr = inputStr.Substring(1);
            if (int.Parse(inputStr) != 0) output += "and";
        }
        if (inputStr.Length == 2)
        {
            var tens = GetDidget(inputStr, 0) * 10;
            if (tens != 10 && tens != 0)
            {
                output += _representations[tens];
                inputStr = inputStr.Substring(1);
            }
        }
        if (int.Parse(inputStr) != 0)
        {
            output += _representations[int.Parse(inputStr)];
        }

        return output;
    }

    private static int GetDidget(string input, int position)
    {
        return int.Parse(input.Substring(position, 1));
    }
}
