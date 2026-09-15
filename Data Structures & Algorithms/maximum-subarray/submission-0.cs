public class Solution {
    public int MaxSubArray(int[] nums) {
        var currSum = 0;
        var maxSum = int.MinValue;

        foreach (var n in nums) {
            currSum = Math.Max(n, currSum + n);
            maxSum = Math.Max(maxSum, currSum);
        }

        return maxSum;

    }
}
