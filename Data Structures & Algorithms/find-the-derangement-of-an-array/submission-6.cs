public class Solution {
    public int FindDerangement(int n) {
        // D(n) = (n-1) * (D(n-1) + D(n-2))

        var dp = new int[2];
        dp[0] = 0; // D(1) = 0
        dp[1] = 1; // D(2) = 1

        for (var i = 3; i <= n; i++) {
            var d = ((i - 1L) * (dp[1] + dp[0])) % 1000000007;
            dp[0] = dp[1];
            dp[1] = (int)d;
        }
        return n == 1 ? dp[0] : dp[1];
    }
}
