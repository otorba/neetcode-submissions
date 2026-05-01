// 6 - 0, 5 - 1, 4 - 2
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++) {
            var value = nums[i];
            var diff = target - value;
            if (dict.ContainsKey(value)) {
                return new int[] { dict[value], i };
                
            }

            dict[diff] = i;
        }

        return [];
    }
}
