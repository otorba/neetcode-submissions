public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        int totalSum, currMinSum, currMaxSum, maxSum, minSum;
        totalSum = currMinSum = currMaxSum = maxSum = minSum = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            var val = nums[i];

            totalSum += val;

            currMinSum = Math.Min(val, currMinSum + val);
            minSum = Math.Min(currMinSum, minSum);

            currMaxSum = Math.Max(val, currMaxSum + val);
            maxSum = Math.Max(currMaxSum, maxSum);
        }

        var output = 0;

        if (minSum == totalSum) {
            // edge case
            output = maxSum;
        } else {
            var circularMaxSum = totalSum - minSum;
            output = Math.Max(circularMaxSum, maxSum);
        }

        return output;
    }
}