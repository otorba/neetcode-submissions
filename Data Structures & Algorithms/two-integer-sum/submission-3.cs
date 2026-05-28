public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var complements = new Dictionary<int, int>();  // complement by index
        for (var i = 0; i < nums.Length; i++) {
            var n = nums[i];
            if (complements.ContainsKey(n)) {
                var compIndex = complements[n];
                return new[] { compIndex, i };
            } else {
                var complement = target - n;
                complements[complement] = i;
            }
        }

        return new int[0];
    }
}
