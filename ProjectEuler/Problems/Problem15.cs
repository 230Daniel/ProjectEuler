namespace ProjectEuler.Problems;

public class Problem15 : Problem
{
    public Problem15() : base(15, "Lattice paths") { }

    /*public override object Run()
    {
        // https://towardsdatascience.com/understanding-combinatorics-number-of-paths-on-a-grid-bddf08e28384

        var gridSize = 21;

        return Choose(2 * (gridSize - 1), gridSize - 1);
    }

    private static long Choose(int n, int r)
    {
        return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }

    private static long Factorial(int input)
    {
        var longInput = (long)input;
        var result = longInput;

        for (var i = longInput - 1; i > 0; i--)
        {
            result *= i;
        }

        return result;
    }*/

    // Alternative method below is too slow.

    public override object Run()
    {
        var gridSize = 21;
        var startingPosition = new Position(0, gridSize);
        return GetPathCount(startingPosition, gridSize) + 1;
    }

    private static ulong GetPathCount(Position position, int gridSize)
    {
        var canMoveRight = position.X < gridSize;
        var canMoveDown = position.Y > 0;

        // Is a split possible?
        var subPaths = canMoveRight && canMoveDown
            ? (ulong) 1
            : 0;

        if (canMoveRight)
        {
            subPaths += GetPathCount(position.Right(), gridSize);
        }

        if (canMoveDown)
        {
            subPaths += GetPathCount(position.Down(), gridSize);
        }

        return subPaths;
    }

    private readonly struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public Position Right()
        {
            return new Position(X + 1, Y);
        }

        public Position Down()
        {
            return new Position(X, Y - 1);
        }

        public override string ToString() => $"({X}, {Y})";
    }
}
