namespace ProjectEuler.Problems;

public class Problem39 : Problem
{
    public Problem39() : base(39, "Integer right triangles") { }

    public override object Run()
    {
        var maxSolutions = 0;
        var maxSolutionsP = 0;

        for (var p = 3; p <= 1000; p++)
        {
            var solutions = 0;

            for (var c = 1; c <= p - 2; c++)
            {
                for (var a = 1; a < p - c; a++)
                {
                    var b = p - c - a;

                    if (a * a + b * b == c * c)
                        solutions++;
                }
            }

            if (solutions > maxSolutions)
            {
                maxSolutions = solutions;
                maxSolutionsP = p;
            }
        }

        return maxSolutionsP;
    }
}
