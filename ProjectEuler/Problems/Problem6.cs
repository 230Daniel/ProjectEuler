namespace ProjectEuler.Problems;

public class Problem6 : Problem
{
    public Problem6() : base(6, "Sum square difference") { }

    public override object Run()
    {
        var sum = 0;
        var sumOfSquares = 0;

        for (var i = 1; i <= 100; i++)
        {
            sum += i;
            sumOfSquares += i * i;
        }

        var squareOfSum = sum * sum;
        var difference = Math.Abs(sumOfSquares - squareOfSum);

        return difference;
    }
}
