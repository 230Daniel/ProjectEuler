namespace ProjectEuler.Problems;

public class Problem28 : Problem
{
    public Problem28() : base(28, "Number spiral diagonals") { }

    public override object Run()
    {
        var size = 1001;
        var halfSize = size / 2;
        var arr = new int[size, size];

        var coordinates = new Coordinates(halfSize, halfSize);
        arr[coordinates.X, coordinates.Y] = 1;
        coordinates.X += 1;

        var number = 2;
        var direction = Direction.Right;

        while (coordinates.X != size && coordinates.Y != size)
        {
            arr[coordinates.X, coordinates.Y] = number;

            var turningDirection = ClockwiseOf(direction);
            var nextCoordinatesTurning = coordinates.GetAdjacent(turningDirection);

            if (arr[nextCoordinatesTurning.X, nextCoordinatesTurning.Y] == 0)
                direction = turningDirection;

            coordinates = coordinates.GetAdjacent(direction);
            number++;
        }

        var total = 0;
        for (var y = 0; y < size; y++)
        {
            for (var x = 0; x < size; x++)
            {
                var xFromCentre = Math.Abs(x - halfSize);
                var yFromCentre = Math.Abs(y - halfSize);

                if (xFromCentre == yFromCentre)
                    total += arr[x, y];
            }
        }

        return total;
    }

    private static Direction ClockwiseOf(Direction direction)
    {
        direction++;
        if ((int) direction == 4) direction = 0;
        return direction;
    }

    private class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinates GetAdjacent(Direction direction)
        {
            return direction switch
            {
                Direction.Right => new Coordinates(X + 1, Y),
                Direction.Down => new Coordinates(X, Y + 1),
                Direction.Left => new Coordinates(X - 1, Y),
                Direction.Up => new Coordinates(X, Y - 1),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }

    private enum Direction
    {
        Right,
        Down,
        Left,
        Up
    }
}
