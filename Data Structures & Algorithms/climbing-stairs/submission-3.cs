public class Solution {
    public int ClimbStairs(int n) {
        return Helper(n);
    }

    private int Helper(int n) {
        // base cases
        if (n == 1)
            return 1;
        if (n == 2)
            return 2;

        var i = 2;
        var dp = new int[] { 1, 2 };
        while (i < n) {
            var tmp = dp[1];
            dp[1] = tmp + dp[0];
            dp[0] = tmp;

            i++;
        }

        return dp[1];
    }
}
