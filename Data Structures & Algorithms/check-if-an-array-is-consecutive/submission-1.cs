public class Solution {
    public bool isConsecutive(int[] nums) {
        var set = new HashSet<int>();
        var max = int.MinValue;
        var min = int.MaxValue;

        foreach (var n in nums) {
            if (!set.Add(n))
                return false;

            max = Math.Max(n, max);
            min = Math.Min(n, min);
        }

        return max - min == nums.Length - 1;
    }
}
