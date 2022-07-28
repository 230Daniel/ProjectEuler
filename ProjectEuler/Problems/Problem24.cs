namespace ProjectEuler.Problems;

public class Problem24 : Problem
{
    public Problem24() : base(24, "Lexicographic permutations") { }

    public override object Run()
    {
        var permutation = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        for (var i = 1; i < 1_000_000; i++)
        {
            var highestPlaceChanging = permutation.Length - 2;

            var requirement = 1;
            for (var j = permutation.Length - 3; j >= 0; j--)
            {
                requirement *= permutation.Length - 1 - j;
                if (i % requirement == 0)
                    highestPlaceChanging = j;
            }

            IncrementPlace(permutation, highestPlaceChanging);
        }

        return string.Join("", permutation);
    }

    private static void IncrementPlace(int[] permutation, int placeToIncrement)
    {
        var minFollowingValue = int.MaxValue;
        var indexOfMinFollowingValue = -1;

        var oldPlaceValue = permutation[placeToIncrement];

        for (var i = placeToIncrement + 1; i < permutation.Length; i++)
        {
            var followingPlaceValue = permutation[i];
            if (followingPlaceValue > oldPlaceValue && followingPlaceValue < minFollowingValue)
            {
                indexOfMinFollowingValue = i;
                minFollowingValue = permutation[i];
            }
        }

        Swap(permutation, placeToIncrement, indexOfMinFollowingValue);
        Array.Sort(permutation, placeToIncrement + 1, permutation.Length - placeToIncrement - 1);
    }

    private static void Swap(int[] permutation, int firstIndex, int secondIndex)
    {
        var tmp = permutation[firstIndex];
        permutation[firstIndex] = permutation[secondIndex];
        permutation[secondIndex] = tmp;
    }
}
