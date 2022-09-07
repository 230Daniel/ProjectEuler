namespace ProjectEuler.Problems;

public class Problem42 : Problem
{
    public Problem42() : base(42, "Coded triangle numbers") { }

    public override object Run()
    {
        var triangularNumbers = new List<int>();
        var maxTriangularNumber = 0;
        var triangularNumberIndex = -1;
        var triangularWords = 0;

        foreach (var word in GetWords())
        {
            var wordValue = 0;
            foreach (var character in word)
            {
                var charValue = character - 'A' + 1;
                wordValue += charValue;
            }

            while (maxTriangularNumber < wordValue)
            {
                triangularNumberIndex += 1;
                var newTriangularNumber = Convert.ToInt32(0.5 * triangularNumberIndex * (triangularNumberIndex + 1));
                triangularNumbers.Add(newTriangularNumber);
                maxTriangularNumber = newTriangularNumber;
            }

            if (triangularNumbers.Contains(wordValue))
            {
                Console.WriteLine($"Triangular word: {word}");
                triangularWords++;
            }
        }

        return triangularWords;
    }

    private static IEnumerable<string> GetWords()
    {
        var contents = File.ReadAllText("ProblemData/Problem42-Words.txt");
        return contents.Split(',').Select(x => x[1..^1]);
    }
}
