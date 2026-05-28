public class Solution {
    public bool hasDuplicate(int[] nums) {
        var seen = new HashSet<int>();
        foreach (var n in nums) {
            if (seen.Contains(n))
                return true;
            seen.Add(n);
        }

        return false;
    }
}