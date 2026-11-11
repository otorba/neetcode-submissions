public class Solution {
    public int MaxA(int n) {
        // x = numbers of A's before copying
        // k = numbers of paste operations
        // x + (x * k) = x*(k+1)

        // i = key presses producing A's
        // x = dp[i]

        // we have n - i key presses remaning
        // Ctrl+A and Ctrl+C require 2 presses, so
        // k = n - i - 2

        // => x(k+1) = dp[i] * ((n-i-2) + 1) = dp[i] * (n-i-1)

        // so d[i] always represents A's best possible sequence

        var totalMax = int.MinValue;
        var dp = new int[n + 1];

        for (var i = 1; i <= n; i++) {
            if (i <= 6)
                dp[i] = i;
            else {
                var max = 0;

                for (var j = 1; j < i - 3; j++) {
                    var cur = dp[j] * (i - j - 1);
                    max = Math.Max(cur, max);
                }

                dp[i] = max;
            }

            totalMax = Math.Max(totalMax, dp[i]);
        }

        return totalMax;
    }
}
