public class Solution {
    public int SubarraySum(int[] nums, int k) {
        var prefix = 0;
        var freq = new Dictionary<int, int>();
        freq[0] = 1;
        var output = 0;

        for (var i = 0; i < nums.Length; i++) {
            prefix += nums[i];

            var l = prefix - k;
            freq.TryGetValue(l, out var value);
            output += value;

            freq.TryGetValue(prefix, out value);
            freq[prefix] = value + 1;
        }

        return output;
    }
}