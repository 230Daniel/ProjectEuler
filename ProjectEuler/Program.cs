using System.Reflection;
using ProjectEuler;

public class Program
{
    // Skipped problems so far:
    // 15 - Couldn't optimise enough

    public static void Main()
    {
        var problems = GetProblems().OrderBy(x => x.Number);

        while (true)
        {
            var problem = ChooseProblem(problems);
            Console.Clear();
            Console.WriteLine($"Running problem {problem}\n");

            var answer = problem.Run();
            Console.WriteLine($"Answer: {answer}");

            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static Problem ChooseProblem(IEnumerable<Problem> problems)
    {
        Console.Clear();
        Console.WriteLine(string.Join("\n", problems));

        while (true)
        {
            Console.Write("\nEnter a problem number or problem name: ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var integerInput))
            {
                var problem = problems.FirstOrDefault(x => x.Number == integerInput);

                if (problem is null)
                {
                    Console.WriteLine($"Problem number {integerInput} does not exist.");
                }
                else
                {
                    return problem;
                }
            }
            else
            {
                input = input.ToLower();
                var matchedProblems = problems.Where(x => x.Name.ToLower().StartsWith(input));
                var matchedCount = matchedProblems.Count();

                if (matchedCount == 1)
                {
                    return matchedProblems.First();
                }
                if (matchedCount > 1)
                {
                    Console.WriteLine("There are multiple problems which match that input:\n" +
                                      string.Join("\n", matchedProblems));
                }
                else
                {
                    Console.WriteLine("No problems match that input.");
                }
            }
        }
    }

    private static IEnumerable<Problem> GetProblems()
    {
        var assembly = Assembly.GetAssembly(typeof(Program));
        var problemTypes = assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(Problem)));

        var problems = new List<Problem>();
        foreach (var problemType in problemTypes)
            problems.Add((Problem) Activator.CreateInstance(problemType));

        return problems;
    }
}
