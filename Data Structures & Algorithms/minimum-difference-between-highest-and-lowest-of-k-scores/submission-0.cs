public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        Array.Sort(nums);  // 1 2 3 3 5 6
        var l = 0;
        var r = 0;
        var min = int.MaxValue;

        while (r < nums.Length) {
            while (r - l + 1 > k) {
                l++;
            }

            if (r - l + 1 == k) {
                min = Math.Min(min, nums[r] - nums[l]);
            }

            r++;
        }

        return min;
    }
}