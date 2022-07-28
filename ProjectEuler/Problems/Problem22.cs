namespace ProjectEuler.Problems;

public class Problem22 : Problem
{
    public Problem22() : base(22, "Names scores") { }

    public override object Run()
    {
        var names = GetNames();
        MergeSort(names);

        var totalScore = 0;

        for (var i = 0; i < names.Length; i++)
        {
            var score = names[i].Sum(character => (character - 'A') + 1);
            score *= i + 1;
            totalScore += score;
        }

        return totalScore;
    }

    // The recursive approach stack-overflowed, so I wrote this monstrosity instead!
    // Starts by looking at every 2 elements, then every 4 elements, etc...
    private static void MergeSort(string[] arr)
    {
        var maxRequiredJumpSize = 2;
        while (maxRequiredJumpSize < arr.Length)
        {
            maxRequiredJumpSize *= 2;
        }

        var buffer = new string[arr.Length];

        for (var jumpSize = 2; jumpSize <= maxRequiredJumpSize; jumpSize *= 2)
        {
            for (var i = 0; i < arr.Length; i += jumpSize)
            {
                var actualJumpSize = Math.Min(jumpSize, arr.Length - i);
                if(actualJumpSize == 1) continue;

                var midpoint = i + (jumpSize / 2);
                var leftPtr = i;
                var rightPtr = midpoint;
                var leftPtrMax = midpoint - 1;
                var rightPtrMax = i + actualJumpSize - 1;

                for (var j = 0; j < actualJumpSize; j++)
                {
                    if (leftPtr > leftPtrMax)
                    {
                        buffer[j] = arr[rightPtr];
                        rightPtr++;
                        continue;
                    }

                    if (rightPtr > rightPtrMax)
                    {
                        buffer[j] = arr[leftPtr];
                        leftPtr++;
                        continue;
                    }

                    var left = arr[leftPtr];
                    var right = arr[rightPtr];

                    if (string.CompareOrdinal(left, right) <= 0)
                    {
                        buffer[j] = left;
                        leftPtr++;
                    }
                    else
                    {
                        buffer[j] = right;
                        rightPtr++;
                    }
                }

                for (var j = 0; j < actualJumpSize && (i + j) < arr.Length; j++)
                {
                    arr[i + j] = buffer[j];
                }
            }
        }
    }

    private static string[] GetNames()
    {
        var namesList = new List<string>();
        var names = File.ReadAllText("ProblemData/Problem22-Names.txt").Trim();

        foreach (var name in names.Split(','))
        {
            var trimmedName = name.Trim('"');
            namesList.Add(trimmedName);
        }

        return namesList.ToArray();
    }
}
