namespace ProjectEuler.Problems;

public class Problem36 : Problem
{
    public Problem36() : base(36, "Double-base palindromes") { }

    public override object Run()
    {
        var total = 0;
        var digits = new List<int>();

        for (var i = 1; i < 1_000_000; i++)
        {
            var remainder = i;
            while (remainder != 0)
            {
                digits.Add(remainder % 10);
                remainder /= 10;
            }

            var palindromic = true;
            for (var j = 0; j < digits.Count / 2; j++)
            {
                if (digits[j] != digits[^(j+1)])
                {
                    palindromic = false;
                    break;
                }
            }

            digits.Clear();
            if(!palindromic) continue;

            remainder = i;
            while (remainder != 0)
            {
                digits.Add(remainder % 2);
                remainder /= 2;
            }

            for (var j = 0; j < digits.Count / 2; j++)
            {
                if (digits[j] != digits[^(j+1)])
                {
                    palindromic = false;
                    break;
                }
            }

            digits.Clear();
            if(!palindromic) continue;

            total += i;
        }

        return total;
    }
}
