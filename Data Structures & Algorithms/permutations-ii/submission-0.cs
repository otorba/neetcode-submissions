public class Solution {
    public List<List<int>> PermuteUnique(int[] nums) {
        var perms = new List<List<int>>();
        var curPerm = new List<int>();
        var used = new bool[nums.Length];

        Helper(nums, used, curPerm, perms);

        return perms;
    }

    private void Helper(int[] nums, bool[] used, List<int> curPerm, List<List<int>> perms) {
        // base case
        if (curPerm.Count == nums.Length) {
            perms.Add(new List<int>(curPerm));
            return;
        }

        var seen = new HashSet<int>();

        for (var i = 0; i < nums.Length; i++) {
            if (!IsValid(i, nums, used, seen))
                continue;

            used[i] = true;
            curPerm.Add(nums[i]);
            seen.Add(nums[i]);

            Helper(nums, used, curPerm, perms);

            used[i] = false;
            curPerm.RemoveAt(curPerm.Count - 1);
        }
    }

    private bool IsValid(int i, int[] nums, bool[] used, HashSet<int> seen) {
        if (used[i])
            return false;

        return !seen.Contains(nums[i]);
    }
}