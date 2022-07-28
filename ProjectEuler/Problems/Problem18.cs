namespace ProjectEuler.Problems;

public class Problem18 : Problem
{
    public Problem18() : base(18, "Maximum path sum I") { }

    public override object Run()
    {
        var triangle = GetTriangle();
        var max = TraverseTriangle(triangle, 0, 0, 0);
        return max;
    }

    private static int TraverseTriangle(int[,] triangle, int currentTotal, int rootRow, int rootColumn)
    {
        var root = triangle[rootRow, rootColumn];
        currentTotal += root;

        if (rootRow == 14) return currentTotal;

        var totalLeft = TraverseTriangle(triangle, currentTotal, rootRow + 1, rootColumn);
        var totalRight = TraverseTriangle(triangle, currentTotal, rootRow + 1, rootColumn + 1);

        return Math.Max(totalLeft, totalRight);
    }

    private static int[,] GetTriangle()
    {
        var triangleStr = @"75
                            95 64
                            17 47 82
                            18 35 87 10
                            20 04 82 47 65
                            19 01 23 75 03 34
                            88 02 77 73 07 63 67
                            99 65 04 28 06 16 70 92
                            41 41 26 56 83 40 80 70 33
                            41 48 72 33 47 32 37 16 94 29
                            53 71 44 65 25 43 91 52 97 51 14
                            70 11 33 28 77 73 17 78 39 68 17 57
                            91 71 52 38 17 14 91 43 58 50 27 29 48
                            63 66 04 68 89 53 67 30 73 16 69 87 40 31
                            04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

        var rowStrs = triangleStr.Split('\n');
        var triangle = new int[15, 15];

        for (var row = 0; row < 15; row++)
        {
            var rowStr = rowStrs[row].Trim();
            var rowNumStrs = rowStr.Split(' ');
            for (var column = 0; column < rowNumStrs.Length; column++)
            {
                triangle[row, column] = int.Parse(rowNumStrs[column]);
            }
        }

        return triangle;
    }
}
