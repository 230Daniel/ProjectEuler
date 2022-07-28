namespace ProjectEuler.Problems;

public class Problem23 : Problem
{
    public Problem23() : base(23, "Non-abundant sums") { }

    public override object Run()
    {
        var abundantNumbers = new List<int>();

        for (var i = 1; i < 28123; i++)
        {
            if (GetIsAbundant(i))
                abundantNumbers.Add(i);
        }

        var total = 0;

        for (var i = 1; i <= 28123; i++)
        {
            for (var j = 0; j < abundantNumbers.Count; j++)
            {
                var abundantNumber = abundantNumbers[j];

                if (abundantNumber >= i)
                {
                    total += i;
                    Console.WriteLine(i);
                    break;
                }

                var counterpart = i - abundantNumber;
                if (counterpart >= 12 && Search(abundantNumbers, counterpart))
                {
                    break;
                }
            }
        }

        return total;
    }

    private static bool Search(List<int> numbers, int target)
    {
        for (var i = 0; i < numbers.Count; i++)
        {
            var number = numbers[i];
            if (number == target) return true;
            if (number > target) return false;
        }
        return false;
    }

    private static bool GetIsAbundant(int number)
    {
        var total = 1;

        for (var potentialDivisor = 2; potentialDivisor < number; potentialDivisor++)
        {
            if (number % potentialDivisor == 0)
            {
                total += potentialDivisor;
                if (total > number) return true;
            }
        }

        return false;
    }
}
