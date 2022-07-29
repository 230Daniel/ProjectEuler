namespace ProjectEuler.Problems;

public class Problem31 : Problem
{
    public Problem31() : base(31, "Coin sums") { }

    public override object Run()
    {
        var coins = new[] { 200, 100, 50, 20, 10, 5, 2, 1 };
        var target = 200;

        return WaysToMakeUpTarget(coins, target, 0);
    }

    private static int WaysToMakeUpTarget(int[] coins, int target, int leftPtr)
    {
        var largestCoinToUse = coins[leftPtr];

        if (leftPtr == coins.Length - 1)
        {
            if (target >= largestCoinToUse) return 1;
            return 0;
        }

        var totalWays = 0;
        for (var amount = 0; amount <= target / largestCoinToUse; amount++)
        {
            var newTarget = target - (largestCoinToUse * amount);
            if (newTarget == 0) totalWays++;
            else totalWays += WaysToMakeUpTarget(coins, newTarget, leftPtr + 1);
        }

        return totalWays;
    }
}
