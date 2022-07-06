namespace ProjectEuler.Problems;

public class Problem9 : Problem
{
    public Problem9() : base(9, "Special Pythagorean triplet") { }

    public override object Run()
    {
        for (var a = 1; a < 1000; a++)
        {
            for (var b = 1; b < (1000 - a); b++)
            {
                var c = 1000 - a - b;

                if (a * a + b * b == c * c)
                {
                    Console.WriteLine($"{a}^2 + {b}^2 = {c}^2\n" +
                                      $"{a} + {b} + {c} = 1000");
                    return a * b * c;
                }
            }
        }

        return null;
    }
}
