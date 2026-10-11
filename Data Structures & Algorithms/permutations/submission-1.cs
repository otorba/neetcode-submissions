public class Solution {
    public List<List<int>> Permute(int[] nums) {
        return Helper(0, nums);
    }

    private List<List<int>> Helper(int i, int[] nums) {
        // the deepest point
        if (i >= nums.Length)
            return new() { new() };

        var perms = Helper(i + 1, nums);
        var newPerms = new List<List<int>>();

        foreach (var perm in perms) {
            foreach (var index in Enumerable.Range(0, perm.Count + 1)) {
                var newPerm = new List<int>(perm);
                newPerm.Insert(index, nums[i]);
                newPerms.Add(newPerm);
            }
        }

        return newPerms;
    }
}
