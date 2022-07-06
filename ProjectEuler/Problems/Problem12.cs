namespace ProjectEuler.Problems;

public class Problem12 : Problem
{
    public Problem12() : base(12, "Highly divisible triangular number") { }

    public override object Run()
    {
        var num = 0;
        var i = 1;

        while (true)
        {
            num += i;
            i += 1;
            var divisors = 0;

            for (var divisor = 1; divisor <= num; divisor++)
            {
                if (num % divisor == 0)
                {
                    divisors += 1;
                }

                if (divisor > 10 && divisors < 10) break;
            }

            if (divisors > 500) return num;
        }
    }
}
