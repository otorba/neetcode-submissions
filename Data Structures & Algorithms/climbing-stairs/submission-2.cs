public class Solution {
    public int ClimbStairs(int n) {
        var seen = new Dictionary<int, int>();
        return Helper(n, seen);
    }

    private int Helper(int n, Dictionary<int, int> seen) {
        // base case
        if (n < 0)
            return 0;
        if (n == 0)
            return 1;

        if (seen.TryGetValue(n, out var cached)) {
            return cached;
        }

        seen[n] = Helper(n - 1, seen) + Helper(n - 2, seen);

        return seen[n];
    }
}
